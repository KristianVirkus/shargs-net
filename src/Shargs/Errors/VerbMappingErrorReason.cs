namespace Shargs.Errors
{
    public enum VerbMappingErrorReason
    {
        Unknown = 0,

        /// <summary>
        /// The property type is not supported. It must not be a value type
        /// but an object.
        /// </summary>
        UnsupportedPropertyType = 1,
    }
}
