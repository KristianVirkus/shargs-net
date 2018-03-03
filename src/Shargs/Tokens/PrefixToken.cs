namespace Shargs.Tokens
{
    /// <summary>
    /// Represents a prefix token.
    /// </summary>
    public class PrefixToken : IToken
    {
        /// <summary>
        /// Gets the prefix.
        /// </summary>
        public string Prefix { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PrefixToken"/> class.
        /// </summary>
        /// <param name="prefix">The prefix.</param>
        public PrefixToken(string prefix)
        {
            this.Prefix = prefix;
        }
    }
}
