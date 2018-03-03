namespace Shargs.Tokens
{
    using System.Collections.Generic;

    /// <summary>
    /// Represents the parser results.
    /// </summary>
    public class ParserResults
    {
        /// <summary>
        /// Gets the parsed tokens.
        /// </summary>
        public IEnumerable<TokenParsingResult> Tokens { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ParserResults"/> class.
        /// </summary>
        /// <param name="tokens">The parsed tokens.</param>
        public ParserResults(IEnumerable<TokenParsingResult> tokens)
        {
            this.Tokens = tokens;
        }
    }
}
