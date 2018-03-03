namespace Shargs.UnitTests.ParserConfig
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using FluentAssertions;
    using Shargs.Tokens;
    using Shargs.UnitTests.Data1;

    [TestFixture]
    public class ParserConfig_FindVerbsTest
    {
        [Test]
        public void FromNullObject_ShouldThrow_ArgumentNullException()
        {
            Assert.Throws(typeof(ArgumentNullException), () => { ParserConfig.FindVerbs(null as object[]); });
        }

        [Test]
        public void FromNullType_ShouldThrow_ArgumentNullException()
        {
            Assert.Throws(typeof(ArgumentNullException), () => { ParserConfig.FindVerbs(null as Type[]); });
        }

        [Test]
        public void FromTypeWithVerbAttributesAndGlobalOptions_Should_FindVerbs()
        {
            var results = ParserConfig.FindVerbs(typeof(ArgsRoot));
            results.Count().Should().Be(3);
            var globalOptions = (from x in results where x.IsGlobalOptions select x).Single();
            globalOptions.IsGlobalOptions.Should().BeTrue();
            globalOptions.Verbs.Count().Should().Be(0);
            var processVerb = (from x in results where x.Verbs.Any() && x.Verbs.Single().Name == "process" select x).Single();
            processVerb.Type.Should().NotBeNull();
            processVerb.Property.Should().NotBeNull();
            processVerb.Verbs.Single().Name.Should().Be("process");
            var getConfigVerb = (from x in results where x.Verbs.Any() && x.Verbs.Single().Name == "get-config" select x).Single();
            getConfigVerb.Type.Should().NotBeNull();
            getConfigVerb.Property.Should().NotBeNull();
            getConfigVerb.Verbs.Single().Name.Should().Be("get-config");
        }
    }
}
