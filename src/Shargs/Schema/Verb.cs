namespace Shargs.Schema
{
    /// <summary>
    /// Represents a verb.
    /// </summary>
    /// <remarks>Any verb is potentially capable of expecting
    ///     specific other options and even other more specific
    ///     verbs.</remarks>
    public class Verb : HierarchicalElement
    {
        /// <summary>
        /// Gets whether the option name is case-sensitive (true.)
        /// </summary>
        public bool IsCaseSensitive { get; }

        /// <summary>
        /// Gets the long option name.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Verb"/> class.
        /// </summary>
        /// <param name="name">The long name.</param>
        /// <param name="IsCaseSensitive">true if the <paramref name="name"/>
        ///     is case-sensitive, false if it is case-insensitive.</param>
        public Verb(string name, bool IsCaseSensitive = false)
            : base()
        {
            this.Name = name;
            this.IsCaseSensitive = IsCaseSensitive;
        }
    }
}
