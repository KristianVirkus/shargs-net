namespace Shargs.Collections
{
    using System;

    /// <summary>
    /// Tags a property as verb.
    /// </summary>
    /// <remarks>
    /// The tagged property should be of a type containing the
    /// logically related options.
    /// </remarks>
    [AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = true)]
    public sealed class VerbAttribute : Attribute
    {
        #region --- Properties ---

        /// <summary>
        /// Gets the name identifying the verb.
        /// </summary>
        public string Name { get; }

        #endregion

        #region --- Constructors ---

        /// <summary>
        /// Initializes a new instance of the <see cref="VerbAttribute"/> class.
        /// </summary>
        /// <param name="name">The verb name.</param>
        public VerbAttribute(string name)
        {
            this.Name = name;
        }

        #endregion
    }
}