namespace Shargs.Mapping
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Tags a property that must not be set from the command line
    /// along with other properties belonging to the same named group.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class MutualExclusionGroupAttribute : Attribute, IMappableAttribute
    {
        #region Properties

        /// <summary>
        /// Gets the group name for mutually exclusive properties.
        /// </summary>
        public string Name { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MutualExclusionGroupAttribute"/> class.
        /// </summary>
        /// <param name="name">The group name for mutually exclusive properties.</param>
        public MutualExclusionGroupAttribute(string name)
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
