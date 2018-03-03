namespace Shargs.Collections
{
    using System;

    /// <summary>
    /// Tags a property as global options container.
    /// </summary>
    /// <remarks>
    /// The tagged property must be of <see cref="IOption"/> type.
    /// </remarks>
    [AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = true)]
    public sealed class GlobalOptionsAttribute : Attribute
    {
    }
}