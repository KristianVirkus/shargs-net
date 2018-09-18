namespace Shargs.UnitTests.Mapping
{
    using NUnit.Framework;
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Shargs.Mapping;
    using Shargs.Errors;

    [TestFixture]
    public class MapTest
    {
        class FlatType
        {
            [ShortOption('n')]
            [LongOption("name")]
            public string Name { get; set; }

            [ShortOption('v')]
            [LongOption("value")]
            public int Value { get; set; }
        }

        [Test]
        public void MapFlatType_Should_Map()
        {
            IEnumerable<MappingMessage> messages;
            var map = Map.Build(typeof(FlatType), out messages);
            IEnumerable<MapNode> mapNodes;
            map.Cache.TryGetValue(typeof(FlatType), out mapNodes).Should().BeTrue();
            var shortOptName = mapNodes.Where(x => x.Property.Name == "Name").Single().SchemaElements.OfType<Schema.ShortOption>().Single();
            shortOptName.Character.Should().Be('n');
            shortOptName.Prefixes.Should().Contain("-");
            shortOptName.Prefixes.Should().Contain("/");
            var longOptName = mapNodes.Where(x => x.Property.Name == "Name").Single().SchemaElements.OfType<Schema.LongOption>().Single();
            longOptName.Name.Should().Be("name");
            longOptName.Prefixes.Should().Contain("--");
            longOptName.Prefixes.Should().Contain("/");
            var shortOptValue = mapNodes.Where(x => x.Property.Name == "Value").Single().SchemaElements.OfType<Schema.ShortOption>().Single();
            shortOptValue.Character.Should().Be('v');
            shortOptValue.Prefixes.Should().Contain("-");
            shortOptValue.Prefixes.Should().Contain("/");
            var longOptValue = mapNodes.Where(x => x.Property.Name == "Value").Single().SchemaElements.OfType<Schema.LongOption>().Single();
            longOptValue.Name.Should().Be("value");
            longOptValue.Prefixes.Should().Contain("--");
            longOptValue.Prefixes.Should().Contain("/");
        }

        class GetterOnlyType
        {
            [ShortOption('n')]
            [LongOption("name")]
            public string Name { get; private set; }
        }

        [Test]
        public void MapFlatTypeReadOnlyProperty_Should_NotMap()
        {
            IEnumerable<MappingMessage> messages;
            var map = Map.Build(typeof(GetterOnlyType), out messages);
            IEnumerable<MapNode> mapNodes;
            map.Cache.TryGetValue(typeof(GetterOnlyType), out mapNodes).Should().BeTrue();
            var shortOptName = mapNodes.Where(x => x.Property.Name == "Name").Any().Should().BeFalse();
        }

        class PrivatePropertyType
        {
            [ShortOption('n')]
            [LongOption("name")]
            private string Name { get; set; }
        }

        [Test]
        public void MapFlatTypePrivateProperty_Should_NotMap()
        {
            IEnumerable<MappingMessage> messages;
            var map = Map.Build(typeof(PrivatePropertyType), out messages);
            IEnumerable<MapNode> mapNodes;
            map.Cache.TryGetValue(typeof(PrivatePropertyType), out mapNodes).Should().BeTrue();
            var shortOptName = mapNodes.Where(x => x.Property.Name == "Name").Any().Should().BeFalse();
        }

        class NoAttributesPropertyType
        {
            public string Name { get; set; }
        }

        [Test]
        public void MapFlatTypeNoAttributesProperty_Should_NotMap()
        {
            IEnumerable<MappingMessage> messages;
            var map = Map.Build(typeof(NoAttributesPropertyType), out messages);
            IEnumerable<MapNode> mapNodes;
            map.Cache.TryGetValue(typeof(NoAttributesPropertyType), out mapNodes).Should().BeTrue();
            mapNodes.Count().Should().Be(0);
        }

        class NoParameterlessConstructorPropertyType
        {
            [ShortOption('n')]
            [LongOption("name")]
            public string Name { get; private set; }

            public NoParameterlessConstructorPropertyType(int i)
            {
                throw new InvalidOperationException();
            }

            private NoParameterlessConstructorPropertyType()
            {
                throw new InvalidOperationException();
            }
        }

        // property type has no parameterless constructor
        [Test]
        public void MapFlatTypeNoParameterlessConstructor()
        {
            IEnumerable<MappingMessage> messages;
            var map = Map.Build(typeof(NoParameterlessConstructorPropertyType), out messages);
            IEnumerable<MapNode> mapNodes;
            map.Cache.TryGetValue(typeof(NoParameterlessConstructorPropertyType), out mapNodes).Should().BeTrue();
            mapNodes.Count().Should().Be(0);
        }

        class VerbOnValueTypeAndStringPropertyType
        {
            [Verb("verba")]
            public int VerbA { get; set; }

            [Verb("verbb")]
            public string VerbB { get; set; }
        }

        [Test]
        public void MapFlatTypeVerbAttributesOnValueTypeAndString_Should_NotMap()
        {
            IEnumerable<MappingMessage> messages;
            var map = Map.Build(typeof(VerbOnValueTypeAndStringPropertyType), out messages);
            (from x in messages
             where x is VerbMappingError
                && ((VerbMappingError)x).Verb.Name == "verba"
                && ((VerbMappingError)x).Reason == VerbMappingErrorReason.UnsupportedPropertyType
             select x).Count().Should().Be(1);
            (from x in messages
             where x is VerbMappingError
                && ((VerbMappingError)x).Verb.Name == "verbb"
                && ((VerbMappingError)x).Reason == VerbMappingErrorReason.UnsupportedPropertyType
             select x).Count().Should().Be(1);
            IEnumerable < MapNode > mapNodes;
            map.Cache.TryGetValue(typeof(VerbOnValueTypeAndStringPropertyType), out mapNodes).Should().BeTrue();
            mapNodes.Count().Should().Be(0);
        }


        // same option on different properties should fail to validate

        // property of Option<T> type
        // property auto value conversion to int, bool
    }
}
