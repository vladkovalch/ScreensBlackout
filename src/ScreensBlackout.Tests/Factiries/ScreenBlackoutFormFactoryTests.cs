using ScreensBlackout.Factories;

namespace ScreensBlackout.Tests.Factiries
{
    internal class ScreenBlackoutFormFactoryTests
    {
        private ScreenBlackoutFormFactory _factory;
        private Screen _testScreen;

        [SetUp]
        public void SetUp()
        {
            _factory = new ScreenBlackoutFormFactory();
            _testScreen = Screen.PrimaryScreen;
        }

        [Test]
        public void CreateFrom_ShouldCreateNonNullFormInstance()
        {
            // Act
            var resultForm = _factory.CreateFrom(_testScreen);

            // Assert
            Assert.That(resultForm, Is.Not.Null);
        }
    }
}
