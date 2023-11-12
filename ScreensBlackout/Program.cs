// This application is designed to black out screens in multi-screen setups.
// It's intentionally created to be re-opened when needed through specific triggers
// such as a Windows shortcut keybind or a macro pad.
using ScreensBlackout.EventHandlers;
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
        private static ICursorAutoHideTimer _cursorHider = new CursorAutoHideTimer();
        private static IScreenBasedFormFactory _screenBasedFormFactory = new BlackoutFormFactory();

        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Creating a new form for each screen that will be used to black them out.
            foreach (var screen in Screen.AllScreens)
            {
                CreateAndShowBlackoutForm(screen);
            }

            Application.Run();
        }

        /// <summary>
        /// Creates the and show blackout form.
        /// </summary>
        /// <param name="screen">The screen.</param>
        private static void CreateAndShowBlackoutForm(Screen screen)
        {
            var blackOutForm = _screenBasedFormFactory.CreateFrom(screen);

            var eventHandlerSetup = new BlackoutFormWithCursorEventHandlerSetup(_cursorHider, blackOutForm, Application.Exit);
            eventHandlerSetup.InitializeEventHandlers();

            blackOutForm.Show();
        }
    }
}
