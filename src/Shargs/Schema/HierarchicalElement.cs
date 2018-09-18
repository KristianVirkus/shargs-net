namespace Shargs.Schema
{
    using System.Collections.Generic;

    /// <summary>
    /// Implements a basic hierarchical element.
    /// </summary>
    public abstract class HierarchicalElement: IHierarchicalElement
    {
        /// <summary>
        /// Gets the child elements.
        /// </summary>
        public IList<IHierarchicalElement> Children { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="HierarchicalElement"/> class.
        /// </summary>
        public HierarchicalElement()
        {
            this.Children = new List<IHierarchicalElement>();
        }
    }
}
