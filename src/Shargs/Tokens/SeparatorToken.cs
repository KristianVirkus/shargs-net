namespace Shargs.Tokens
{
    /// <summary>
    /// Represents a separator token.
    /// </summary>
    public class SeparatorToken : IToken
    {
        /// <summary>
        /// Gets the raw text.
        /// </summary>
        public string RawText { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SeparatorToken"/>.
        /// </summary>
        /// <param name="rawText">The raw text.</param>
        public SeparatorToken(string rawText)
        {
            this.RawText = rawText;
        }
    }
}
