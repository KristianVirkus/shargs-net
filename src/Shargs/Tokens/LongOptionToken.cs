namespace Shargs.Tokens
{
    /// <summary>
    /// Represents a long option.
    /// </summary>
    public class LongOptionToken : IToken
    {
        /// <summary>
        /// Gets the option name.
        /// </summary>
        public string Option { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="LongOptionToken"/> class.
        /// </summary>
        /// <param name="option">The option name.</param>
        public LongOptionToken(string option)
        {
            this.Option = option;
        }
    }
}
