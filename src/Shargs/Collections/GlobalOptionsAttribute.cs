namespace Shargs.Collections
{
    using System;

    /// <summary>
    /// Tags a property as global options container.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public sealed class GlobalOptionsAttribute : Attribute
    {
    }
}