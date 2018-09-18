namespace Shargs.UnitTests.Tokens.Parser
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using FluentAssertions;
    using Shargs.Tokens;

    [TestFixture]
    public class Parser_ParseGeneralTest
    {
        [Test]
        public void NullInput_ShouldThrow_ArgumentNullException()
        {
            Assert.Throws(typeof(ArgumentNullException), () => { Shargs.Tokens.Parser.Parse(null, new ParserConfig(null)); });
        }

        [Test]
        public void WhitespaceOnlyInput_Should_CreateNoTokens()
        {
            var results = Shargs.Tokens.Parser.Parse("  ", new ParserConfig(null));
        }

        [Test]
        public void NullParserConfig_ShouldThrow_ArgumentNullException()
        {
            Assert.Throws(typeof(ArgumentNullException), () => { Shargs.Tokens.Parser.Parse("test", null); });
        }

        [Test]
        public void ShortOptionsConfigAndValidInput_Should_CreateTokens()
        {
            var config = new ParserConfig(null);
            throw new NotImplementedException();
        }
    }
}
