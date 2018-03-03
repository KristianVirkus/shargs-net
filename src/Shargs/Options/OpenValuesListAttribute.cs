namespace Shargs.Options
{
    using System;

    /// <summary>
    /// Tags a property as taking all command line arguments which cannot be
    /// assigned a specific option.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public sealed class OpenValuesListAttribute : Attribute
    {
        #region --- Properties ---

        /// <summary>
        /// Gets the quotation marks which are considered quotation marks around the
        /// option value.
        /// </summary>
        public string[] QuotationMarks { get; }

        #endregion

        #region --- Constructors ---

        /// <summary>
        /// Initializes a new instance of the <see cref="OpenValuesListAttribute"/> class.
        /// </summary>
        /// <param name="QuotationMarks">The characters found in open values list
        ///     which are considered quotation marks around an open value. Separate
        ///     multiple quotation marks by pipe characters.</param>
        public OpenValuesListAttribute(string QuotationMarks = "'|\"")
        {
            this.QuotationMarks = QuotationMarks.Split('|');
        }

        #endregion
    }
}
