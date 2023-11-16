using Moq;
using ScreensBlackout.Builders;
using ScreensBlackout.Enums;
using ScreensBlackout.Interfaces;
using ScreensBlackout.Tests.Utilities;

namespace ScreensBlackout.Tests.Builders
{
    internal class ScreenBlackoutFormOverlayBuilderTests
    {
        private ScreenBlackoutFormOverlayBuilder _builder;

        [SetUp]
        public void SetUp()
        {
            _builder = new ScreenBlackoutFormOverlayBuilder();
        }

        [Test]
        public void BasedOnScreenBounds_SetsOverlayBoundsCorrectly()
        {
            // Arrange
            var builder = new ScreenBlackoutFormOverlayBuilder();
            var screenBounds = new Rectangle(0, 0, 1920, 1080);

            // Act
            builder.BasedOnScreenBounds(screenBounds);
            var form = builder.Build();

            // Assert
            Assert.That(form.Bounds, Is.EqualTo(screenBounds));
        }

        [Test]
        public void WithWindowOnStartActivation_SetsFlag()
        {
            // Act
            var result = _builder.WithWindowOnStartActivation();

            // Assert
            Assert.That(result.GetPrivateFieldValue<bool>("_shouldBringWindowToFrontOnLoad"), Is.True);
        }

        [Test]
        public void WithClosureHandling_SetsCloseBehaviorAndAction()
        {
            // Arrange
            var closeBehaviorOptions = (ClosureHandlingOptions)~0;
            Action closeAction = () => { };

            // Act
            var result = _builder.WithClosureHandling(closeBehaviorOptions, closeAction);

            _builder.Build();

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(result.GetPrivateFieldValue<ClosureHandlingOptions?>("_closeBehaviorOptions"), Is.EqualTo(closeBehaviorOptions));
                Assert.That(result.GetPrivateFieldValue<Action>("_closeAction"), Is.EqualTo(closeAction));
            });
        }

        [Test]
        public void WithCursorAutoHide_SetsCursorAutoHideBehavior()
        {
            // Arrange
            var mockCursorAutoHideBehavior = new Mock<ICursorAutoHideBehavior>();

            // Act
            var result = _builder.WithCursorAutoHide(mockCursorAutoHideBehavior.Object);

            _builder.Build();

            // Assert
            Assert.That(result.GetPrivateFieldValue<ICursorAutoHideBehavior>("_cursorAutoHideBehavior"), Is.EqualTo(mockCursorAutoHideBehavior.Object));
        }

        [Test]
        public void Build_WithoutCallingOtherMethods_ConstructsDefaultForm()
        {
            // Arrange
            var builder = new ScreenBlackoutFormOverlayBuilder();

            // Act
            var form = builder.Build();

            // Assert
            Assert.That(form, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(form.FormBorderStyle, Is.EqualTo(FormBorderStyle.None));
                Assert.That(form.WindowState, Is.EqualTo(FormWindowState.Maximized));
                Assert.That(form.BackColor, Is.EqualTo(Color.Black));
                Assert.That(form.TopMost, Is.True);
                Assert.That(form.StartPosition, Is.EqualTo(FormStartPosition.Manual));
                Assert.That(form.KeyPreview, Is.True);
            });
        }
    }
}
