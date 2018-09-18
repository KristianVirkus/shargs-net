namespace Shargs.Schema
{
    using System.Collections.Generic;

    /// <summary>
    /// Represents a short option.
    /// </summary>
    public class ShortOption : Option
    {
        static readonly string[] DefaultPrefixes = new[] { "-", "/" };

        /// <summary>
        /// The character identifying the option (aka option name.)
        /// </summary>
        public char Character { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ShortOption"/> class.
        /// </summary>
        /// <param name="character">The character identifying the option (aka option name.)</param>
        /// <param name="Prefixes">The prefixes considered for option recognition.</param>
        /// <param name="IsCaseSensitive">true if the <paramref name="name"/>
        ///     is case-sensitive, false if it is case-insensitive.</param>
        /// <param name="QuotationMarks">Quotation mark characters for the
        ///     recognition of multiple tokens belonging together.</param>
        public ShortOption(char character, IEnumerable<string> Prefixes = default(IEnumerable<string>),
            bool IsCaseSensitive = Option.DefaultIsCaseSensitive,
            IEnumerable<string> QuotationMarks = default(IEnumerable<string>))
            : base(Prefixes ?? DefaultPrefixes, IsCaseSensitive, QuotationMarks)
        {
            this.Character = character;
        }
    }
}
