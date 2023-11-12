using ScreensBlackout.Interfaces;
using System.Windows.Forms;

namespace ScreensBlackout.Factories
{
    /// <summary>
    /// A factory for creating <see cref="Form"/> instances related to the screens blackout functionality.
    /// </summary>
    /// <seealso cref="ScreensBlackOut.Interfaces.IScreenBasedFormFactory" />
    public class BlackoutFormFactory : IScreenBasedFormFactory
    {
        /// <summary>
        /// Creates a <see cref="Form" /> instance with bounds set based on screen parameters.
        /// </summary>
        /// <param name="screen">The screen.</param>
        /// <returns>
        /// A <see cref="Form" /> instance.
        /// </returns>
        public Form CreateFrom(Screen screen)
        {
            var formInstance = new Form()
            {
                FormBorderStyle = FormBorderStyle.None,
                WindowState = FormWindowState.Maximized,
                BackColor = System.Drawing.Color.Black,
                TopMost = true,
                StartPosition = FormStartPosition.Manual,
                KeyPreview = true
            };

            if (screen != null)
            {
                formInstance.Bounds = screen.Bounds;
            }

            formInstance.Shown += (sender, args) =>
            {
                formInstance.Activate();
            };

            return formInstance;
        }
    }
}
