using System.Diagnostics;

namespace ScreensBlackout.Helpers
{
    /// <summary>
    /// Manages the running instances of the application, ensuring that only one instance is active.
    /// If a second instance is launched, it terminates all instances.
    /// </summary>
    public class SingleInstanceAppHelper
    {
        private const string MutexName = "ScreensBlackout.SingleInstanceMutex";
        private static Mutex? _mutex;

        /// <summary>
        /// Ensures the single instance or terminates all if another instance is started.
        /// </summary>
        /// <returns>
        /// <c>True</c> if this is the first instance, otherwise <c>false</c>. All instances are terminated if <c>false</c>.
        /// </returns>
        public static bool EnsureSingleInstance()
        {
            _mutex = new Mutex(true, MutexName, out bool createdNew);

            if (!createdNew)
            {
                // If another instance is running, terminate all instances including this one.
                TerminateAllInstances();

                return false;
            }

            return true;
        }

        /// <summary>
        /// Releases the mutex.
        /// </summary>
        public static void ReleaseMutex()
        {
            _mutex?.ReleaseMutex();
        }

        /// <summary>
        /// Terminates all application instances, including the current one.
        /// </summary>
        private static void TerminateAllInstances()
        {
            string currentProcessName = Process.GetCurrentProcess().ProcessName;

            foreach (var process in Process.GetProcessesByName(currentProcessName))
            {
                if (process.Id != Environment.ProcessId)
                {
                    process.Kill();
                }
            }

            Environment.Exit(0);
        }
    }
}
