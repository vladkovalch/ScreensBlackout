namespace ScreensBlackout.Enums
{
    /// <summary>
    /// Enumeration for the various closure handling options for a screen blackout form overlay.
    /// </summary>
    [Flags]
    public enum ClosureHandlingOptions
    {
        /// <summary>
        /// Any key press.
        /// </summary>
        KeyPress = 0,

        /// <summary>
        /// The mouse click.
        /// </summary>
        MouseClick = 1,

        /// <summary>
        /// All available options.
        /// </summary>
        All = ~0
    }
}
