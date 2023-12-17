using ScreensBlackout.Enums;
using ScreensBlackout.Interfaces;
using ScreensBlackout.Interop;
using ScreensBlackout.Tests.Factiries;
using System.Drawing;
using System.Windows.Forms;

namespace ScreensBlackout.Builders
{
    /// <summary>
    /// Builder class for creating a screen blackout form overlay.
    /// </summary>
    public class ScreenBlackoutFormOverlayBuilder : IScreenBlackoutFormOverlayBuilder
    {
        private ICursorAutoHideBehavior? _cursorAutoHideBehavior;

        private Action? _closeAction;
        private ClosureHandlingOptions? _closeBehaviorOptions;
        private Rectangle? _overlayBounds;
        private bool _shouldBringWindowToFrontOnLoad;

        private readonly Form _formInstance;

        /// <summary>
        /// Initializes a new instance of the <see cref="ScreenBlackoutFormOverlayBuilder"/> class.
        /// </summary>
        public ScreenBlackoutFormOverlayBuilder()
        {
            _formInstance = new Form()
            {
                FormBorderStyle = FormBorderStyle.None,
                WindowState = FormWindowState.Maximized,
                BackColor = Color.Black,
                TopMost = true,
                StartPosition = FormStartPosition.Manual,
                KeyPreview = true
            };
        }

        /// <summary>
        /// Sets overlay's screen bounds based on the screen.
        /// </summary>
        /// <param name="screen">The screen.</param>
        /// <returns>
        /// An instance of <see cref="ScreenBlackoutFormOverlayBuilder"/>.
        /// </returns>
        public IScreenBlackoutFormOverlayBuilder BasedOnScreenBounds(Rectangle screenBounds)
        {
            _overlayBounds = screenBounds;

            return this;
        }

        /// <summary>
        /// Toggles on the window on start activation behavior.
        /// </summary>
        /// <returns>
        /// An instance of <see cref="ScreenBlackoutFormOverlayBuilder"/>.
        /// </returns>
        public IScreenBlackoutFormOverlayBuilder WithWindowOnStartActivation()
        {
            _shouldBringWindowToFrontOnLoad = true;

            return this;
        }

        /// <summary>
        /// Sets the form closure behavior.
        /// </summary>
        /// <param name="closeBehaviorOptions">The close behavior options.</param>
        /// <param name="closeAction">The close action.</param>
        /// <returns>
        /// An instance of <see cref="ScreenBlackoutFormOverlayBuilder"/>.
        /// </returns>
        public IScreenBlackoutFormOverlayBuilder WithClosureHandling(ClosureHandlingOptions closeBehaviorOptions, Action closeAction)
        {
            _closeBehaviorOptions = closeBehaviorOptions;
            _closeAction = closeAction;

            return this;
        }

        /// <summary>
        /// Sets the cursor automatic hide behavior.
        /// </summary>
        /// <param name="cursorAutoHideStrategy">The cursor automatic hide behavior.</param>
        /// <returns>
        /// An instance of <see cref="ScreenBlackoutFormOverlayBuilder"/>.
        /// </returns>
        public IScreenBlackoutFormOverlayBuilder WithCursorAutoHide(ICursorAutoHideBehavior cursorAutoHideBehavior)
        {
            _cursorAutoHideBehavior = cursorAutoHideBehavior;

            return this;
        }

        /// <summary>
        /// Constructs and returns a <see cref="Form"/> instance based on the specified configurations.
        /// </summary>
        /// <returns>
        /// A fully constructed <see cref="Form"/> object with set configurations applied.
        /// </returns>
        public Form Build()
        {
            BuildOverlayBounds();
            BuildWindowActivationBehavior();
            BuildCursorAutoHideBehavior();
            BuildCloseBehavior();

            return _formInstance;
        }

        /// <summary>
        /// Builds the overlay bounds.
        /// </summary>
        private void BuildOverlayBounds()
        {
            if (_overlayBounds.HasValue)
            {
                _formInstance.Bounds = _overlayBounds.Value;
            }
        }

        /// <summary>
        /// Builds the window activation behavior.
        /// </summary>
        private void BuildWindowActivationBehavior()
        {
            if (_shouldBringWindowToFrontOnLoad)
            {
                _formInstance.Load += (sender, e) =>
                {
                    NativeMethods.BringWindowToFront(_formInstance.Handle);
                };
            }
        }

        /// <summary>
        /// Builds the cursor automatic hide behavior.
        /// </summary>
        private void BuildCursorAutoHideBehavior()
        {
            if (_cursorAutoHideBehavior != null)
            {
                _formInstance.MouseMove += (sender, args) => _cursorAutoHideBehavior.OnUserActivity();
                _formInstance.Shown += (sender, args) => _cursorAutoHideBehavior.ApplyAutoHideBehavior();
            }
        }

        /// <summary>
        /// Builds the close behavior.
        /// </summary>
        private void BuildCloseBehavior()
        {
            if (_closeAction != null && _closeBehaviorOptions.HasValue)
            {
                if (_closeBehaviorOptions.Value.HasFlag(ClosureHandlingOptions.KeyPress))
                {
                    _formInstance.KeyDown += (sender, args) => _closeAction?.Invoke();
                }

                if (_closeBehaviorOptions.Value.HasFlag(ClosureHandlingOptions.MouseClick))
                {
                    _formInstance.MouseUp += (sender, args) => _closeAction?.Invoke();
                }
            }
        }
    }
}
