namespace Shargs.Schema
{
    using System.Collections.Generic;

    /// <summary>
    /// Represents an open values collection.
    /// </summary>
    public class OpenValueCollection : Element
    {
        static readonly string[] DefaultQuotationMarks = new[] { "\"", "'" };

        /// <summary>
        /// Gets the list of quotation mark characters for the
        /// recognition of multiple tokens belonging together.
        /// </summary>
        public IEnumerable<string> QuotationMarks { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="OpenValueCollection"/> class.
        /// </summary>
        /// <param name="QuotationMarks">Quotation mark characters for the
        ///     recognition of multiple tokens belonging together.</param>
        public OpenValueCollection(IEnumerable<string> QuotationMarks = default(IEnumerable<string>))
        {
            this.QuotationMarks = QuotationMarks ?? DefaultQuotationMarks;
        }
    }
}
