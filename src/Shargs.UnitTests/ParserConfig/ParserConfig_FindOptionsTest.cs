namespace Shargs.UnitTests.ParserConfig
{
    using FluentAssertions;
    using NUnit.Framework;
    using Shargs.Tokens;
    using Shargs.UnitTests.Data1;
    using System;
    using System.Linq;

    [TestFixture]
    public class ParserConfig_FindOptionsTest
    {
        [Test]
        public void FromNullObject_ShouldThrow_ArgumentNullException()
        {
            Assert.Throws(typeof(ArgumentNullException), () => { ParserConfig.FindOptions(null as object[]); });
        }

        [Test]
        public void FromNullType_ShouldThrow_ArgumentNullException()
        {
            Assert.Throws(typeof(ArgumentNullException), () => { ParserConfig.FindOptions(null as Type[]); });
        }

        [Test]
        public void FromTypeWithOptionAttributes_Should_FindAllOptions()
        {
            var results = ParserConfig.FindOptions(typeof(ProcessOptions));
            results.Count().Should().Be(2);
            var inputOption = (from x in results where x.ShortOptions.Single().Character == 'i' select x).Single();
            inputOption.Type.Should().Be(typeof(ProcessOptions));
            inputOption.Property.Should().NotBeNull();
            inputOption.ShortOptions.Count().Should().Be(1);
            inputOption.ShortOptions.Single().Character.Should().Be('i');
            inputOption.ShortOptions.Single().Prefixes.Should().Contain(new[] { "-", "/" });
            inputOption.ShortOptions.Single().OptionValueSeparators.Should().Contain(new[] { ":", "=" });
            inputOption.ShortOptions.Single().QuotationMarks.Should().Contain(new[] { "\"" });
            inputOption.LongOptions.Count().Should().Be(1);
            inputOption.LongOptions.Single().Name.Should().Be("input");
            inputOption.LongOptions.Single().Prefixes.Should().Contain(new[] { "--", "/" });
            inputOption.LongOptions.Single().OptionValueSeparators.Should().Contain(new[] { ":", "=" });
            inputOption.LongOptions.Single().QuotationMarks.Should().Contain(new[] { "\"" });
            inputOption.OpenValuesList.Should().BeNull();
            var outputOption = (from x in results where x.ShortOptions.Single().Character == 'o' select x).Single();
            outputOption.Type.Should().Be(typeof(ProcessOptions));
            outputOption.Property.Should().NotBeNull();
            outputOption.ShortOptions.Count().Should().Be(1);
            outputOption.ShortOptions.Single().Character.Should().Be('o');
            outputOption.ShortOptions.Single().Prefixes.Should().Contain(new[] { "-", "/" });
            outputOption.ShortOptions.Single().OptionValueSeparators.Should().Contain(new[] { "", " ", "=", ":" });
            outputOption.ShortOptions.Single().QuotationMarks.Should().Contain(new[] { "\"" });
            outputOption.LongOptions.Count().Should().Be(1);
            outputOption.LongOptions.Single().Name.Should().Be("output");
            outputOption.LongOptions.Single().Prefixes.Should().Contain(new[] { "--", "/" });
            outputOption.LongOptions.Single().OptionValueSeparators.Should().Contain(new[] { "", " ", "=", ":" });
            outputOption.LongOptions.Single().QuotationMarks.Should().Contain(new[] { "'", "\"" });
            outputOption.OpenValuesList.Should().BeNull();
        }

        [Test]
        public void FromTypeWithOpenValuesAttribute_Should_FindOpenValuesListProperty()
        {
            var results = ParserConfig.FindOptions(typeof(GetConfigOptions));
            results.Count().Should().Be(1);
            results.Single().Type.Should().Be(typeof(GetConfigOptions));
            results.Single().Property.Should().NotBeNull();
            results.Single().ShortOptions.Count().Should().Be(0);
            results.Single().LongOptions.Count().Should().Be(0);
            results.Single().OpenValuesList.QuotationMarks.Should().Contain(new[] { "'", "\"" });
        }
    }
}
