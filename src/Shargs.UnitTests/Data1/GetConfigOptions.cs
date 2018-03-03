using Shargs.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shargs.UnitTests.Data1
{
    class GetConfigOptions
    {
        [OpenValuesList]
        public IEnumerable<string> Keys { get; set; }
    }
}
