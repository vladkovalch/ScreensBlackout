using System.Windows.Forms;

namespace ScreensBlackout.Interfaces
{
    /// <summary>
    /// Defines the contract for a factory that creates <see cref="Form"/> instances based on screen parameters.
    /// </summary>
    public interface IScreenBasedFormFactory
    {
        /// <summary>
        /// Creates a <see cref="Form" /> instance with bounds set based on screen parameters.
        /// </summary>
        /// <param name="screen">The screen.</param>
        /// <returns>
        /// A <see cref="Form" /> instance.
        /// </returns>
        Form CreateFrom(Screen screen);
    }
}
