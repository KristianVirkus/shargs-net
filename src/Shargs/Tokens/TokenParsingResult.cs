namespace Shargs.Tokens
{
    using System.Collections.Generic;

    /// <summary>
    /// Represents a token parsing result.
    /// </summary>
    public class TokenParsingResult
    {
        /// <summary>
        /// Gets the token.
        /// </summary>
        public IToken Token { get; }

        /// <summary>
        /// Gets the messages related to this token.
        /// </summary>
        public IEnumerable<ParserMessage> Messages { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TokenParsingResult"/> class.
        /// </summary>
        /// <param name="token"></param>
        /// <param name="messages"></param>
        public TokenParsingResult(IToken token, IEnumerable<ParserMessage> messages)
        {
            this.Token = token;
            this.Messages = messages;
        }
    }
}
