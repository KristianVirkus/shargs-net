namespace Shargs.Errors
{
    using Shargs.Mapping;
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Represents a verb mapping error.
    /// </summary>
    public class VerbMappingError : MappingMessage
    {
        public VerbAttribute Verb { get; }
        public VerbMappingErrorReason Reason { get; }

        public VerbMappingError(VerbAttribute verb, VerbMappingErrorReason reason)
        {
            this.Verb = verb;
            this.Reason = reason;
        }
    }
}
