namespace Shargs.Schema
{
    using System.Collections.Generic;

    /// <summary>
    /// Represents a basic option.
    /// </summary>
    public abstract class Option : Element
    {
        internal const bool DefaultIsCaseSensitive = false;

        /// <summary>
        /// Get the prefixes considered for option recognition.
        /// </summary>
        public IEnumerable<string> Prefixes { get; }

        /// <summary>
        /// Gets whether the option name is case-sensitive (true.)
        /// </summary>
        public bool IsCaseSensitive { get; }

        /// <summary>
        /// Quotation mark characters for the
        /// recognition of multiple tokens belonging together.
        /// </summary>
        public IEnumerable<string> QuotationMarks { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Option"/> class.
        /// </summary>
        /// <param name="prefixes">The prefixes considered for option recognition.</param>
        /// <param name="isCaseSensitive">true if the <paramref name="name"/>
        ///     is case-sensitive, false if it is case-insensitive.</param>
        /// <param name="quotationMarks">Quotation mark characters for the
        ///     recognition of multiple tokens belonging together.</param>
        public Option(IEnumerable<string> prefixes, bool isCaseSensitive, IEnumerable<string> quotationMarks)
        {
            this.Prefixes = prefixes;
            this.IsCaseSensitive = isCaseSensitive;
            this.QuotationMarks = quotationMarks;
        }
    }
}
