using ScreensBlackout.Interfaces;
using System.Windows.Forms;

namespace ScreensBlackout.EventHandlers
{
    /// <summary>
    /// Sets up event handlers for a form with a focus on cursor visibility management.
    /// </summary>
    /// <seealso cref="ScreensBlackout.EventHandlers.BlackoutFormBaseEventHandlerSetup" />
    public class BlackoutFormWithCursorEventHandlerSetup : BlackoutFormBaseEventHandlerSetup
    {
        private readonly ICursorAutoHideTimer _cursorHider;

        /// <summary>
        /// Initializes a new instance of the <see cref="BlackoutFormWithCursorEventHandlerSetup"/> class.
        /// </summary>
        /// <param name="cursorHider">The cursor hider.</param>
        /// <param name="form">The form.</param>
        /// <param name="closeAction">The close action.</param>
        public BlackoutFormWithCursorEventHandlerSetup(ICursorAutoHideTimer cursorHider, Form form, Action closeAction) : base(form, closeAction)
        {
            _cursorHider = cursorHider;

            InitializeComponents();
        }

        /// <summary>
        /// Setups the custom event handlers.
        /// </summary>
        protected override void SetupCustomEventHandlers()
        {
            Form.MouseMove += (sender, args) => _cursorHider.ResetTimer();
        }

        /// <summary>
        /// Initializes the components.
        /// </summary>
        private void InitializeComponents()
        {
            _cursorHider.StartTimer();
        }
    }
}
