using ScreensBlackout.Enums;
using ScreensBlackout.Interfaces;
using System.Drawing;
using System.Windows.Forms;

namespace ScreensBlackout.Tests.Factiries
{
    /// <summary>
    /// Defines the contract for a blackout form overlay builder.
    /// </summary>
    public interface IScreenBlackoutFormOverlayBuilder
    {
        IScreenBlackoutFormOverlayBuilder BasedOnScreenBounds(Rectangle screenBounds);
        IScreenBlackoutFormOverlayBuilder WithWindowOnStartActivation();
        IScreenBlackoutFormOverlayBuilder WithClosureHandling(ClosureHandlingOptions closeBehaviorOptions, Action closeAction);
        IScreenBlackoutFormOverlayBuilder WithCursorAutoHide(ICursorAutoHideBehavior cursorAutoHideBehavior);
        Form Build();
    }
}