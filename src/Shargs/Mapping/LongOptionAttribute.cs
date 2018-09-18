namespace Shargs.Mapping
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Tags a property as long option value.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = true)]
    public sealed class LongOptionAttribute : Attribute, IMappableAttribute
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
        /// Gets whether the name is case-sensitive.
        /// </summary>
        public bool IsCaseSensitive { get; }

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
        /// <param name="IsCaseSensitive">true if the <paramref name="name"/> is
        ///     considered case-sensitive, false if it is case-insensitive.</param>
        /// <param name="OptionValueSeparators">The tokens separating
        ///     the option character from the option value. An empty token
        ///     (either "" or e.g. ":||=") represents no separation between
        ///     option and value. Separate multiple separators by pipe characters.
        ///     Thus pipe characters are not allowed in option value separators.</param>
        /// <param name="QuotationMarks">The characters found after option value separators
        ///     which are considered quotation marks around the option value. Separate
        ///     multiple quotation marks by pipe characters.</param>
        public LongOptionAttribute(string name, string Prefix = "--|/", bool IsCaseSensitive = false,
            string OptionValueSeparators = "| |=|:", string QuotationMarks = "'|\"")
        {
            this.Name = name;
            this.Prefixes = (Prefix ?? "").Split('|');
            this.IsCaseSensitive = IsCaseSensitive;
            this.OptionValueSeparators = (OptionValueSeparators ?? "").Split('|');
            this.QuotationMarks = (QuotationMarks ?? "").Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
        }

        #endregion

        #region IMappableAttribute implementation

        /// <summary>
        /// Populates a map <paramref name="node"/> from <paramref name="attributes"/>.
        /// </summary>
        /// <param name="attributes">The mappable attribute instances.</param>
        /// <param name="node">The target map node.</param>
        /// <returns>Messages generated while populating.</returns>
        public IEnumerable<MappingMessage> PopulateMapNode(IEnumerable<IMappableAttribute> attributes, MapNode node)
        {
            var ownAttributes = attributes.OfType<LongOptionAttribute>();
            foreach (var att in ownAttributes)
            {
                node.SchemaElements.Add(new Schema.LongOption(att.Name, att.Prefixes, att.IsCaseSensitive, att.QuotationMarks));
            }

            return null;
        }

        /// <summary>
        /// Validates the <paramref name="node"/> model taking all its
        /// properties into account.
        /// </summary>
        /// <param name="node">The node model to validate.</param>
        /// <exception cref="NodeModelValidationException">Thrown if
        ///     <paramref name="node"/> contains invalid information.</exception>
        public void ValidateNodeModel(MapNode node)
        {
            // if has verb, fail
            // if has openvaluecollection, fail
        }

        #endregion
    }
}