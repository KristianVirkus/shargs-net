using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shargs.UnitTests.Data1
{
    class ArgsRoot
    {
        [Collections.GlobalOptions]
        public GlobalOptions Global { get; set; }

        [Collections.Verb("process")]
        public ProcessOptions Process { get; set; }

        //[Collections.Verb("get-config")]
        //public GetConfigOptions Get { get; set; }
    }
}
