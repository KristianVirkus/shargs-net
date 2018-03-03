namespace Shargs.Options
{
    /// <summary>
    /// Represents a string option.
    /// </summary>
    public class StringOption : OptionWithValueBase<string>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StringOption"/> class.
        /// </summary>
        /// <param name="isLongOption">true if this instance is being created for a
        ///     long option specification.</param>
        /// <param name="prefix">The option prefix.</param>
        /// <param name="rawPrefix">The raw prefix text.</param>
        /// <param name="rawText">The raw option text that led to this instance creation.</param>
        /// <param name="rawValue">The raw value text.</param>
        /// <param name="parsedValue">The parsed and typed value.</param>
        public StringOption(bool isLongOption, string rawText, string prefix,
            string rawPrefix, string rawValue)
            : base(isLongOption, rawText, prefix, rawPrefix, rawValue, parse(rawValue))
        {
        }

        static string parse(string value)
        {
            return value;
        }
    }
}