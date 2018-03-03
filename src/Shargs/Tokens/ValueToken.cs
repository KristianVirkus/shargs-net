namespace Shargs.Tokens
{
    /// <summary>
    /// Represents a value token.
    /// </summary>
    public class ValueToken : IToken
    {
        /// <summary>
        /// Gets the value.
        /// </summary>
        public string Value { get; }

        /// <summary>
        /// Gets whether the value is quoted.
        /// </summary>
        public bool IsQuoted { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ValueToken"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="isQuoted">true if the value is quoted, false otherwise.</param>
        public ValueToken(string value, bool isQuoted)
        {
            this.Value = value;
            this.IsQuoted = isQuoted;
        }
    }
}
