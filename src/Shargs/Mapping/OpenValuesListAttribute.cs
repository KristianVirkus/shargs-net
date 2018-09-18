namespace Shargs.Mapping
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Tags a property as taking all command line arguments which cannot be
    /// assigned a specific option.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public sealed class OpenValuesListAttribute : Attribute, IMappableAttribute
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
            this.QuotationMarks = QuotationMarks.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
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
        }

        #endregion
    }
}
