namespace Shargs.Mapping
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Reflection;

    /// <summary>
    /// Represents type/property mapping results.
    /// </summary>
    public class Map
    {
        #region Properties

        /// <summary>
        /// Gets the root type.
        /// </summary>
        public Type RootType { get; }

        /// <summary>
        /// Gets the cached map nodes.
        /// </summary>
        public IReadOnlyDictionary<Type, IEnumerable<MapNode>> Cache { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Map"/> class.
        /// </summary>
        /// <param name="rootType">The root type.</param>
        /// <param name="cache">The cached map nodes.</param>
        internal Map(Type rootType, IDictionary<Type, IList<MapNode>> cache)
        {
            this.RootType = rootType;
            this.Cache = new ReadOnlyDictionary<Type, IEnumerable<MapNode>>(cache.ToDictionary(x => x.Key, x => x.Value.AsEnumerable<MapNode>()));
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Builds a type/property map from a <paramref name="type"/> type
        /// by browsing its properties.
        /// </summary>
        /// <remarks>Only browses public instance properties' types recursively
        ///     and stops recursion as soon as a such a type does not contain
        ///     any mapping-related tagged properties.</remarks>
        /// <param name="type">The type.</param>
        /// <param name="messages">Outputs the list to complete with messages generated
        ///     while mapping.</param>
        /// <returns>The type mappings.</returns>
        public static Map Build(Type type, out IEnumerable<MappingMessage> messages)
        {
            var mappedTypes = new Dictionary<Type, IList<MapNode>>();
            var messageList = new List<MappingMessage>();
            build(type, mappedTypes, messageList);
            messages = messageList;
            return new Map(type, mappedTypes);
        }

        /// <summary>
        /// Builds a type/property map from a <paramref name="type"/> type
        /// by browsing its properties.
        /// </summary>
        /// <remarks>Only browses public instance properties' types recursively
        ///     and stops recursion as soon as a such a type does not contain
        ///     any mapping-related tagged properties.</remarks>
        /// <param name="type">The type.</param>
        /// <param name="mappedTypes">The dictionary to complete with processed
        ///     types and their node mappings.</param>
        /// <param name="messages">The list to complete with messages generated
        ///     while mapping.</param>
        /// <exception cref="System.ArgumentNullException">Thrown if
        ///     <paramref name="type"/> is null.</exception>
        static void build(Type type, IDictionary<Type, IList<MapNode>> mappedTypes, IList<MappingMessage> messages)
        {
            if (type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            // Make sure they are not null.
            mappedTypes = mappedTypes ?? new Dictionary<Type, IList<MapNode>>();
            messages = messages ?? new List<MappingMessage>();

            // Avoid circles.
            if (mappedTypes.ContainsKey(type))
            {
                return;
            }

            var mappableAttributes = new[] {
                typeof(ShortOptionAttribute),
                typeof(LongOptionAttribute),
                typeof(VerbAttribute),
                typeof(OpenValuesListAttribute),
                typeof(RequiredAttribute),
                typeof(OneOfGroupAttribute),
                typeof(MutualExclusionGroupAttribute),
            };

            mappedTypes.Add(type, new List<MapNode>());
            // Find all properties with public getter and setter?
            foreach (var prop in from x in type.GetRuntimeProperties()
                                 where x.GetMethod.IsPublic && (x.SetMethod?.IsPublic ?? false)
                                 select x)
            {
                try
                {
                    var atts = (from x in prop.GetCustomAttributes()
                                where mappableAttributes.Contains(x.GetType())
                                select x).OfType<IMappableAttribute>();
                    if (!atts.Any()) continue; // Also not recurse into this type.

                    var nodeModel = new MapNode(prop);
                    foreach (var att in atts)
                    {
                        var moreMessages = att.PopulateMapNode(atts, nodeModel);
                        foreach (var msg in moreMessages ?? new MappingMessage[0]) messages.Add(msg);
                    }

                    try
                    {
                        // Use attributes again to validate the current node model.
                        foreach (var att in atts)
                        {
                            att.ValidateNodeModel(nodeModel);
                        }
                    }
                    catch (NodeModelValidationException ex)
                    {
                        // TODO Include exception as MappingMessage.
                        messages.Add(new MappingMessage() /* TODO */);
                    }

                    mappedTypes[type].Add(nodeModel);

                    // Recurse into property's type if not yet done.
                    if (!mappedTypes.ContainsKey(prop.DeclaringType))
                    {
                        build(prop.DeclaringType, mappedTypes, messages);
                    }
                }
                catch (Exception ex)
                {
                    // TODO Include exception as MappingMessage.
                }
            }
        }

        /// <summary>
        /// Creates a <see cref="Schema.Schema"/> from the type mappings.
        /// </summary>
        /// <returns>The schema.</returns>
        public Schema.Schema CreateSchema()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
