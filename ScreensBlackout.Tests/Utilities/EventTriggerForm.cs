namespace ScreensBlackout.Tests.Utilities
{
    [System.ComponentModel.DesignerCategory("")]
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
