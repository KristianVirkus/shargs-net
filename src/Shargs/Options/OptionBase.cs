namespace Shargs.Options
{
    /// <summary>
    /// Serves as an option base implementation.
    /// </summary>
    public abstract class OptionBase: IOption
    {
        #region --- Properties ---

        /// <summary>
        /// Gets whether the long form of the option has been used.
        /// </summary>
        public bool IsLongOption { get; }

        /// <summary>
        /// Gets the raw option text.
        /// </summary>
        public string RawText { get; }

        /// <summary>
        /// Gets the used option prefix.
        /// </summary>
        public string Prefix { get; }

        /// <summary>
        /// Gets the raw prefix text.
        /// </summary>
        public string RawPrefix { get; }

        #endregion

        #region --- Constructors ---

        /// <summary>
        /// Initializes a new instance of the <see cref="OptionBase"/> class.
        /// </summary>
        /// <param name="isLongOption">true if this instance is being created for a
        ///     long option specification.</param>
        /// <param name="rawText">The raw option text that led to this instance creation.</param>
        /// <param name="prefix">The option prefix.</param>
        /// <param name="rawPrefix">The raw prefix text.</param>
        internal OptionBase(bool isLongOption, string rawText, string prefix,
            string rawPrefix)
        {
            this.IsLongOption = isLongOption;
            this.RawText = rawText;
            this.Prefix = prefix;
            this.RawPrefix = rawPrefix;
        }

        #endregion
    }
}