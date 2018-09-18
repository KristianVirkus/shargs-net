namespace Shargs.Tokens
{
    using Shargs.Collections;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    /// <summary>
    /// Represents a parser configuration.
    /// </summary>
    public class ParserConfig
    {
        #region --- Properties ---

        /// <summary>
        /// Gets the command line options schema.
        /// </summary>
        public Schema.Schema Schema { get; }

        #endregion

        #region --- Constructors ---

        /// <summary>
        /// Initializes a new instance of the <see cref="ParserConfig"/> class.
        /// </summary>
        /// <param name="schema">The command line options schema to use
        ///     as reference when parsing.</param>
        public ParserConfig(Schema.Schema schema)
        {
            if (schema == null) throw new ArgumentNullException(nameof(schema));
            this.Schema = schema;
        }

        #endregion

        #region --- Static methods ---

        #endregion
    }
}
