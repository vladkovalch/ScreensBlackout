using ScreensBlackout.Behaviors;
using ScreensBlackout.Builders;
using ScreensBlackout.Enums;
using ScreensBlackout.Interfaces;
using System.Windows.Forms;

namespace ScreensBlackout.Factories
{
    /// <summary>
    /// A factory for creating <see cref="Form"/> instances related to the screens blackout functionality.
    /// </summary>
    /// <seealso cref="ScreensBlackout.Interfaces.IScreenBasedFormFactory" />
    public class ScreenBlackoutFormFactory : IScreenBasedFormFactory
    {
        private readonly ICursorAutoHideBehavior _delayedCursorAutoHideBehavior = new DelayedCursorAutoHideBehavior();

        /// <summary>
        /// Creates from.
        /// </summary>
        /// <param name="screen">The screen.</param>
        /// <returns>
        /// A fully constructed <see cref="Form"/> object based on screen bounds, with window on startup activation, cursor autohide and closure handling functionality.
        /// </returns>
        public Form CreateFrom(Screen screen)
        {
            var blackoutFormOverlayBuilder = new ScreenBlackoutFormOverlayBuilder();

            return blackoutFormOverlayBuilder.BasedOnScreenBounds(screen.Bounds)
                                             .WithWindowOnStartActivation()
                                             .WithCursorAutoHide(_delayedCursorAutoHideBehavior)
                                             .WithClosureHandling((ClosureHandlingOptions)~0, Application.Exit)
                                             .Build();
        }
    }
}
