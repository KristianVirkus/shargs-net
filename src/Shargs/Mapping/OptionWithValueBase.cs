namespace Shargs.Mapping
{
    /// <summary>
    /// Serves as an option with value base implementation.
    /// </summary>
    /// <typeparam name="T">The value type.</typeparam>
    public class OptionWithValueBase<T> : OptionBase, IOption<T>
    {
        #region --- Properties ---

        /// <summary>
        /// Gets the raw value text.
        /// </summary>
        public string RawValue { get; }

        /// <summary>
        /// Gets the value the option has been initialised with.
        /// </summary>
        public T Value { get; protected set; }

        #endregion

        #region --- Constructors ---

        /// <summary>
        /// Initializes a new instance of the <see cref="OptionBase"/> class.
        /// </summary>
        /// <param name="isLongOption">true if this instance is being created for a
        ///     long option specification.</param>
        /// <param name="prefix">The option prefix.</param>
        /// <param name="rawPrefix">The raw prefix text.</param>
        /// <param name="rawText">The raw option text that led to this instance creation.</param>
        /// <param name="rawValue">The raw value text.</param>
        /// <param name="parsedValue">The parsed and typed value.</param>
        public OptionWithValueBase(bool isLongOption, string rawText, string prefix,
            string rawPrefix, string rawValue, T parsedValue)
            : base(isLongOption, rawText, prefix, rawPrefix)
        {
            this.RawValue = rawValue;
            var value = parsedValue;
        }

        #endregion
    }
}
