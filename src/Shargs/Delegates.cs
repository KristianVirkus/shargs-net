namespace Shargs
{
    using Shargs.Options;

    /// <summary>
    /// Delegate to have a part of the command line be processed for the
    /// next option.
    /// </summary>
    /// <param name="optionCollection">The object containing options to be
    ///     completed by this delegate implementation.</param>
    /// <param name="remainingCmdLine">The remaining command line to
    ///     process.</param>
    /// <returns>The </returns>
    public delegate IOption IdentifyOptionDelegate(object optionCollection, string remainingCmdLine);
}
