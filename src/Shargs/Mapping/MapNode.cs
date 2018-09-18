namespace Shargs.Mapping
{
    using Shargs.Schema;
    using System.Collections.Generic;
    using System.Reflection;

    /// <summary>
    /// Represents a map node used for modelling only.
    /// </summary>
    public class MapNode
    {
        #region Properties

        /// <summary>
        /// Gets the property information.
        /// </summary>
        public PropertyInfo Property { get; }

        /// <summary>
        /// Gets the generated schema elements.
        /// </summary>
        public IList<IElement> SchemaElements { get; set; } = new List<IElement>();

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MapNode"/> class.
        /// </summary>
        /// <param name="property">The property.</param>
        public MapNode(PropertyInfo property)
        {
            this.Property = property;
        }

        #endregion
    }
}