using System.Runtime.InteropServices;

namespace ScreensBlackout.Interop
{
    public static class NativeMethods
    {
        /// <summary>
        /// Sets the foreground window.
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        /// <summary>
        /// Shows the cursor.
        /// </summary>
        /// <param name="show">if set to <c>true</c> [show].</param>
        [DllImport("user32.dll")]
        public static extern void ShowCursor(bool show);

        /// <summary>
        /// Brings the window to front.
        /// </summary>
        /// <param name="windowHandle">The window handle.</param>
        public static void BringWindowToFront(IntPtr windowHandle)
        {
            SetForegroundWindow(windowHandle);
        }
    }
}
