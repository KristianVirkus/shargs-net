namespace Shargs.Mapping
{
    using Shargs.Schema;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    /// <summary>
    /// Tags a property as verb branch.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = true)]
    public sealed class VerbAttribute : Attribute, IMappableAttribute
    {
        #region Properties

        /// <summary>
        /// Gets the name identifying the verb branch.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the quotation marks which are considered quotation marks around the
        /// verb name.
        /// </summary>
        public string[] QuotationMarks { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="VerbAttribute"/> class.
        /// </summary>
        /// <param name="name">The name identifying the verb branch.</param>
        public VerbAttribute(string name, string QuotationMarks = "'|\"")
        {
            this.Name = name;
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
            if ((node?.SchemaElements?.OfType<Verb>().Any() == true)
                && (node?.Property.PropertyType.GetTypeInfo().IsValueType == true))
            {
                throw new NodeModelValidationException();
            }
        }

        #endregion
    }
}
