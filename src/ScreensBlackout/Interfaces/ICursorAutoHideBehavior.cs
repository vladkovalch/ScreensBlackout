namespace ScreensBlackout.Interfaces
{
    /// <summary>
    /// Defines the behavior for auto-hiding the cursor in a screen blackout form overlay.
    /// </summary>
    public interface ICursorAutoHideBehavior
    {
        /// <summary>
        /// Applies the automatic hide behavior.
        /// </summary>
        void ApplyAutoHideBehavior();

        /// <summary>
        /// Handles user activity.
        /// </summary>
        void OnUserActivity();
    }
}
