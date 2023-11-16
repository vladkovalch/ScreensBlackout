using ScreensBlackout.Enums;
using ScreensBlackout.Interfaces;
using System.Drawing;
using System.Windows.Forms;

namespace ScreensBlackout.Tests.Factiries
{
    public interface IScreenBlackoutFormOverlayBuilder
    {
        IScreenBlackoutFormOverlayBuilder BasedOnScreenBounds(Rectangle screenBounds);
        IScreenBlackoutFormOverlayBuilder WithWindowOnStartActivation();
        IScreenBlackoutFormOverlayBuilder WithClosureHandling(ClosureHandlingOptions closeBehaviorOptions, Action closeAction);
        IScreenBlackoutFormOverlayBuilder WithCursorAutoHide(ICursorAutoHideBehavior cursorAutoHideBehavior);
        Form Build();
    }
}