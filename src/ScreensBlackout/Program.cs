﻿// This application is designed to black out screens in multi-screen setups.
// It's intentionally created to be re-opened when needed through specific triggers
// such as a Windows shortcut keybind or a macro pad.
using ScreensBlackout.Factories;
using ScreensBlackout.Helpers;
using ScreensBlackout.Interfaces;
using System.Windows.Forms;

namespace ScreensBlackOut
{
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    public class Program
    {
        private static readonly IScreenBasedFormFactory _screenBasedFormFactory = new ScreenBlackoutFormFactory();

        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (!SingleInstanceAppHelper.EnsureSingleInstance())
            {
                return; // All instances including this one are terminated if another instance is running.
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Creating a new form for each screen that will be used to black them out.
            CreateAndShowBlackoutOverlayForms();

            Application.Run();

            // Release the mutex when the application is closing.
            SingleInstanceAppHelper.ReleaseMutex();
        }

        /// <summary>
        /// Creates and displays a black overlay over each window on the screen.
        /// </summary>
        private static void CreateAndShowBlackoutOverlayForms()
        {
            foreach (var screen in Screen.AllScreens)
            {
                var blackOutForm = _screenBasedFormFactory.CreateFrom(screen);

                blackOutForm.Show();
            }
        }
    }
}
