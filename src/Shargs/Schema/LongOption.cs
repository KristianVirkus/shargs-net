namespace Shargs.Schema
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Represents a long option.
    /// </summary>
    public class LongOption : Option
    {
        static readonly string[] DefaultPrefixes = new[] { "--", "/" };

        /// <summary>
        /// Gets the long option name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="LongOption"/> class.
        /// </summary>
        /// <param name="name">The long name.</param>
        /// <param name="Prefixes">The prefixes considered for option recognition.</param>
        /// <param name="IsCaseSensitive">true if the <paramref name="name"/>
        ///     is case-sensitive, false if it is case-insensitive.</param>
        /// <param name="QuotationMarks">Quotation mark characters for the
        ///     recognition of multiple tokens belonging together.</param>
        public LongOption(string name, IEnumerable<string> Prefixes = default(IEnumerable<string>),
            bool IsCaseSensitive = false, IEnumerable<string> QuotationMarks = default(IEnumerable<string>))
            : base(Prefixes ?? DefaultPrefixes, IsCaseSensitive, QuotationMarks)
        {
            this.Name = name;
        }
    }
}
