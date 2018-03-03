namespace Shargs.Options
{
    /// <summary>
    /// Common interface of all command line option implementations.
    /// </summary>
    public interface IOption
    {
        /// <summary>
        /// Gets whether the long form of the option has been used.
        /// </summary>
        bool IsLongOption { get; }

        /// <summary>
        /// Gets the raw option text.
        /// </summary>
        string RawText { get; }

        /// <summary>
        /// Gets the used option prefix.
        /// </summary>
        string Prefix { get; }

        /// <summary>
        /// Gets the raw prefix text.
        /// </summary>
        string RawPrefix { get; }
    }

    /// <summary>
    /// Common interface of all command line option implementations with
    /// a specific option value.
    /// </summary>
    public interface IOption<T>: IOption
    {
        /// <summary>
        /// Gets the raw value text.
        /// </summary>
        string RawValue { get; }

        /// <summary>
        /// Gets the option's value.
        /// </summary>
        T Value { get; }
    }
}