namespace Shargs.Mapping
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Tags a verb branch property to require one of the named
    /// groups' properties of the referenced type to be present
    /// in the input.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class OneOfGroupAttribute : Attribute, IMappableAttribute
    {
        #region Properties

        /// <summary>
        /// Gets the name of the property group of which one property
        /// value must be set from the input.
        /// </summary>
        public string Name { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="OneOfGroupAttribute"/> class.
        /// </summary>
        /// <param name="name">The name of the property group of which
        ///     one property value must be set from the input.</param>
        public OneOfGroupAttribute(string name)
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
        }

        #endregion
    }
}
