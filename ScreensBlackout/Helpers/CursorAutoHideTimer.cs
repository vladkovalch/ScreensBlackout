using ScreensBlackout.Interfaces;
using ScreensBlackout.Interop;
using Timer = System.Windows.Forms.Timer;

namespace ScreensBlackout.Helpers
{
    /// <summary>
    /// Used to start a 3-minute timer to hide the mouse cursor.
    /// </summary>
    public class CursorAutoHideTimer : ICursorAutoHideTimer
    {
        private Timer? _timer;
        private bool _cursorVisible = true;

        /// <summary>
        /// Gets or sets the timer interval milliseconds for hiding the cursor.
        /// </summary>
        /// <value>
        /// The timer interval milliseconds.
        /// </value>
        public int TimerIntervalMilliseconds { get; set; } = 3000; // 3 seconds

        /// <summary>
        /// Initializes a new instance of the <see cref="CursorAutoHideTimer"/> class.
        /// </summary>
        public CursorAutoHideTimer()
        {
            _timer = new Timer
            {
                Interval = TimerIntervalMilliseconds
            };

            _timer.Tick += OnTimerTick;
        }

        /// <summary>
        /// Starts the timer.
        /// </summary>
        public void StartTimer()
        {
            _timer!.Start();
        }

        /// <summary>
        /// Resets the timer.
        /// </summary>
        public void ResetTimer()
        {
            if (!_cursorVisible)
            {
                NativeMethods.ShowCursor(true);
                _cursorVisible = true;
            }

            _timer!.Stop();
            _timer.Start();
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_timer != null)
                {
                    _timer.Dispose();
                    _timer = null;
                }
            }
        }

        /// <summary>
        /// Called when [timer tick].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void OnTimerTick(object? sender, EventArgs e)
        {
            if (_cursorVisible)
            {
                NativeMethods.ShowCursor(false);
                _cursorVisible = false;
            }

            _timer!.Stop();
        }
    }
}
