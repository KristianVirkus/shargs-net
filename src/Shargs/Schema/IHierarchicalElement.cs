namespace Shargs.Schema
{
    using System.Collections.Generic;

    /// <summary>
    /// Common interface of all hierarchical elements.
    /// </summary>
    public interface IHierarchicalElement: IElement
    {
        /// <summary>
        /// Gets the child elements.
        /// </summary>
        IList<IHierarchicalElement> Children { get; }
    }
}
