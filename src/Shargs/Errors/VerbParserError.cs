namespace Shargs.Errors
{
    /// <summary>
    /// Represents a verb parser error.
    /// </summary>
    public class VerbParserError
    {
        #region --- Properties ---

        /// <summary>
        /// Gets the character position the error was detected.
        /// </summary>
        public int Position { get; }

        /// <summary>
        /// Gets the specific error.
        /// </summary>
        public Errors Error { get; }

        #endregion

        #region --- Constructors ---

        /// <summary>
        /// Initializes a new instance of the <see cref="VerbParserError"/> class.
        /// </summary>
        /// <param name="position">The character position the error was detected.</param>
        /// <param name="error">The specific error.</param>
        public VerbParserError(int position, Errors error)
        {
            this.Position = position;
            this.Error = error;
        }

        #endregion

        #region --- Nested types ---

        /// <summary>
        /// Enumeration of error alternatives.
        /// </summary>
        public enum Errors
        {
            /// <summary>
            /// No error.
            /// </summary>
            None = 0,

            /// <summary>
            /// Verb expected because there are no global options defined (or matched)
            /// and there are no open values expected at this point.
            /// </summary>
            VerbExpected = 1,
        }

        #endregion
    }
}
