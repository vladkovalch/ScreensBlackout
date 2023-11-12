using Moq;
using ScreensBlackout.EventHandlers;
using ScreensBlackout.Interfaces;
using ScreensBlackout.Tests.Utilities;

namespace ScreensBlackout.Tests.EventHandlers
{
    internal class BlackoutFormWithCursorEventHandlerSetupTests
    {
        private bool _callbackInvoked;

        [TearDown]
        public void TearDown()
        {
            _callbackInvoked = false;
        }

        [Test]
        public void Setup_ShouldAssignCloseActionOnKeyDown()
        {
            // Arrange
            var testableForm = new EventTriggerForm();
            var cursorHiderMock = new Mock<ICursorAutoHideTimer>(MockBehavior.Loose);

            var action = new Action(() => _callbackInvoked = true);
            var eventHandlerSetup = new BlackoutFormWithCursorEventHandlerSetup(cursorHiderMock.Object, testableForm, action);

            // Act
            eventHandlerSetup.Setup();

            testableForm.TriggerKeyDown(new KeyEventArgs(Keys.Escape));

            // Assert
            Assert.That(_callbackInvoked, Is.True);
        }

        [Test]
        public void Setup_ShouldAssignCloseActionOnMouseUp()
        {
            // Arrange
            var testableForm = new EventTriggerForm();
            var cursorHiderMock = new Mock<ICursorAutoHideTimer>(MockBehavior.Loose);

            var action = new Action(() => _callbackInvoked = true);
            var eventHandlerSetup = new BlackoutFormWithCursorEventHandlerSetup(cursorHiderMock.Object, testableForm, action);

            // Act
            eventHandlerSetup.Setup();

            testableForm.TriggerMouseUp(new MouseEventArgs(MouseButtons.Left, 1, 1, 1, 0));

            // Assert
            Assert.That(_callbackInvoked, Is.True);
        }
    }
}
