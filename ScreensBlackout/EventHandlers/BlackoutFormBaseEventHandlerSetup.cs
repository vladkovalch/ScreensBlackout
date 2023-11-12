using System.Windows.Forms;

namespace ScreensBlackout.EventHandlers
{
    /// <summary>
    /// Provides a template method pattern for setting up event handlers on a <see cref="Form"/> instance.
    /// </summary>
    public abstract class BlackoutFormBaseEventHandlerSetup
    {
        protected readonly Form Form;
        protected readonly Action CloseAction;

        /// <summary>
        /// Initializes a new instance of the <see cref="BlackoutFormBaseEventHandlerSetup"/> class.
        /// </summary>
        /// <param name="form">The form.</param>
        /// <param name="closeAction">The close action.</param>
        public BlackoutFormBaseEventHandlerSetup(Form form, Action closeAction)
        {
            Form = form;
            CloseAction = closeAction;
        }

        /// <summary>
        /// Initializes the form's event handlers.
        /// </summary>
        public void InitializeEventHandlers()
        {
            Form.KeyDown += (sender, args) => CloseAction();
            Form.MouseUp += (sender, args) => CloseAction();

            SetupCustomEventHandlers();
        }

        /// <summary>
        /// Setups the custom event handlers.
        /// </summary>
        protected abstract void SetupCustomEventHandlers();
    }
}
