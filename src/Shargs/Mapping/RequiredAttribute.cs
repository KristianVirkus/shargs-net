namespace Shargs.Mapping
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Tags a property to be required in the input.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class RequiredAttribute : Attribute, IMappableAttribute
    {
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
