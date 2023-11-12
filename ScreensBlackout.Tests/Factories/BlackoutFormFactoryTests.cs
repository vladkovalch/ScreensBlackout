using ScreensBlackout.Factories;

namespace ScreensBlackout.Tests.Factories
{
    internal class BlackoutFormFactoryTests
    {
        [Test]
        public void CreateForm_ShouldCreateFormWithValidPropertiesSet()
        {
            // Arrange
            var screen = Screen.PrimaryScreen;
            var blackoutFormFactory = new BlackoutFormFactory();

            // Act
            var form = blackoutFormFactory.CreateFrom(screen);

            // Assert
            Assert.That(form, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(form.WindowState, Is.EqualTo(FormWindowState.Maximized));
                Assert.That(form.FormBorderStyle, Is.EqualTo(FormBorderStyle.None));
                Assert.That(form.StartPosition, Is.EqualTo(FormStartPosition.Manual));
                Assert.That(form.TopMost, Is.EqualTo(true));
            });
        }

        [Test]
        public void CreateForm_ShouldCreateFormWithSetBounds_WhenScreenIsValid()
        {
            // Arrange
            var screen = Screen.PrimaryScreen;
            var blackoutFormFactory = new BlackoutFormFactory();

            // Act
            var form = blackoutFormFactory.CreateFrom(screen);

            // Assert
            Assert.That(form, Is.Not.Null);
            Assert.That(form.Bounds, Is.EqualTo(screen.Bounds));
        }
    }
}
