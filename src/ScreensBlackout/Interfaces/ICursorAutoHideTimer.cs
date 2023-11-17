namespace ScreensBlackout.Interfaces
{
    /// <summary>
    /// Defines the contract for a cursor hiding mechanism.
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public interface ICursorAutoHideTimer : IDisposable
    {
        /// <summary>
        /// Starts the timer.
        /// </summary>
        void StartTimer();

        /// <summary>
        /// Resets the timer.
        /// </summary>
        void ResetTimer();

        /// <summary>
        /// Gets or sets the timer interval milliseconds for hiding the cursor.
        /// </summary>
        /// <value>
        /// The timer interval milliseconds.
        /// </value>
        public int TimerIntervalMilliseconds { get; set; }
    }
}
