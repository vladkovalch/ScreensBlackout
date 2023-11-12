namespace ScreensBlackout.Tests.Utilities
{
    internal class EventTriggerForm : Form
    {
        public void TriggerKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
        }

        public void TriggerMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
        }
    }
}
