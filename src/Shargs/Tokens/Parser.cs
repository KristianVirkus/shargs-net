namespace Shargs.Tokens
{
    using System;

    /// <summary>
    /// Implements a parser to split command line arguments into tokens.
    /// </summary>
    public static class Parser
    {
        /// <summary>
        /// Parses command line arguments.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <param name="config">The parser configuration.</param>
        /// <returns></returns>
        public static ParserResults Parse(string args, ParserConfig config)
        {
            if (args == null) throw new ArgumentNullException("args");
            if (config == null) throw new ArgumentNullException("config");

            var result = new ParserResults(null);



            return result;
        }
    }
}
