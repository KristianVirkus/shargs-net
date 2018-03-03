namespace Shargs.Tokens
{
    /// <summary>
    /// Represents a short option.
    /// </summary>
    public class ShortOptionToken: IToken
    {
        /// <summary>
        /// Gets the option name.
        /// </summary>
        public string Option { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ShortOptionToken"/> class.
        /// </summary>
        /// <param name="option">The option name.</param>
        public ShortOptionToken(string option)
        {
            this.Option = option;
        }
    }
}
