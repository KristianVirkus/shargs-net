namespace Shargs.Options
{
    using System;

    /// <summary>
    /// Tags a property as long option value.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = true)]
    public sealed class LongOptionAttribute : Attribute
    {
        #region --- Properties ---

        /// <summary>
        /// Gets the name identifying the option.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the introducing prefixes.
        /// </summary>
        public string[] Prefixes { get; }

        /// <summary>
        /// Gets the tokens separating the option character from the option value.
        /// </summary>
        public string[] OptionValueSeparators { get; }

        /// <summary>
        /// Gets the quotation marks which are considered quotation marks around the
        /// option value.
        /// </summary>
        public string[] QuotationMarks { get; }

        #endregion

        #region --- Constructors ---

        /// <summary>
        /// Initializes a new instance of the <see cref="LongOptionAttribute"/> class.
        /// </summary>
        /// <param name="name">The long option name.</param>
        /// <param name="Prefix">The prefixes introducing the option. Separate
        ///     multiple prefixes by pipe characters. Pipe characters are thus not
        ///     allowed in prefixes.</param>
        /// <param name="OptionValueSeparators">The tokens separating
        ///     the option character from the option value. An empty token
        ///     (either "" or e.g. ":||=") represents no separation between
        ///     option and value. Separate multiple separators by pipe characters.
        ///     Thus pipe characters are not allowed in option value separators.</param>
        /// <param name="QuotationMarks">The characters found after option value separators
        ///     which are considered quotation marks around the option value. Separate
        ///     multiple quotation marks by pipe characters.</param>
        public LongOptionAttribute(string name, string Prefix = "--|/",
            string OptionValueSeparators = "| |=|:", string QuotationMarks = "'|\"")
        {
            this.Name = name;
            this.Prefixes = (Prefix ?? "").Split('|');
            this.OptionValueSeparators = (OptionValueSeparators ?? "").Split('|');
            this.QuotationMarks = (QuotationMarks ?? "").Split('|');
        }

        #endregion
    }
}