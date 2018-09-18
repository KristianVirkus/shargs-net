namespace Shargs.Mapping
{
    using Shargs.Tokens;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    static class Mapper<T>
    {
        //public static MappingResults Map(ParserResults parserResults, T destination,
        //    bool DontApplyDefaultValues = false, Func<IToken, T, TokenMappingResult> CustomMapCallback = null)
        //{
        //    CustomMapCallback = (_token, _dest) => null;

        //    var results = new MappingResults();
        //    return results;
        //}

        // TODO Consider multiple inputs separated by "--" -> return IEnumerable<Mapping>
    }
}
