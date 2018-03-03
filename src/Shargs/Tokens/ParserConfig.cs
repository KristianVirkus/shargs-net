namespace Shargs.Tokens
{
    using Shargs.Collections;
    using Shargs.Options;
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
        /// Gets the known options for known verbs.
        /// </summary>
        public Dictionary<string, IEnumerable<Option>> VerbOptions { get; }

        /// <summary>
        /// Gets whether verbs and options are considered case-sensitive.
        /// </summary>
        public bool IsCaseSensitive { get; }

        #endregion

        #region --- Constructors ---

        /// <summary>
        /// Initializes a new instance of the <see cref="ParserConfig"/> class.
        /// </summary>
        /// <param name="verbOptions">The known options (value) per known verb (key.)</param>
        /// <param name="IsCaseSensitive">true if verbs and options are considered
        ///     case-sensitive, false to ignore cases.</param>
        public ParserConfig(Dictionary<string, IEnumerable<Option>> verbOptions,
            bool IsCaseSensitive = false)
        {
            this.VerbOptions = verbOptions;
            this.IsCaseSensitive = IsCaseSensitive;
        }

        #endregion

        #region --- Static methods ---

        /// <summary>
        /// Finds all options in objects' type definitions.
        /// </summary>
        /// <param name="objs">The objects.</param>
        /// <returns>List of all options found in <paramref name="objs"/>.</returns>
        public static IEnumerable<Option> FindOptions(params object[] objs)
        {
            if (objs == null) throw new ArgumentNullException("objs");
            return FindOptions((from x in objs where x != null select x.GetType()).ToArray());
        }

        /// <summary>
        /// Finds all options in type definitions.
        /// </summary>
        /// <param name="types">The types.</param>
        /// <returns>List of all options found in <paramref name="types"/>.</returns>
        public static IEnumerable<Option> FindOptions(params Type[] types)
        {
            if (types == null) throw new ArgumentNullException("types");

            var results = new List<Option>();
            foreach (var type in (from x in types where x != null select x).Distinct())
            {
                foreach (var propInfo in type.GetProperties(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public))
                {
                    // Find all options in property's attributes.
                    var shortOptions = new List<ShortOptionAttribute>();
                    var longOptions = new List<LongOptionAttribute>();

                    var shortOptionAtts = propInfo.GetCustomAttributes(typeof(ShortOptionAttribute), false).OfType<ShortOptionAttribute>();
                    foreach (var att in shortOptionAtts)
                    {
                        shortOptions.Add(att);
                    }

                    var longOptionAtts = propInfo.GetCustomAttributes(typeof(LongOptionAttribute), false).OfType<LongOptionAttribute>();
                    foreach (var att in longOptionAtts)
                    {
                        longOptions.Add(att);
                    }

                    var openValuesListAtts = propInfo.GetCustomAttributes(typeof(OpenValuesListAttribute), false).OfType<OpenValuesListAttribute>();
                    if (openValuesListAtts.Count() > 1)
                    {
                        throw new InvalidOperationException(string.Format("Multiple OpenValuesListAttributes on property \"{0}\" of type \"{1}\".", propInfo.Name, type.Name));
                    }

                    // Create cacheable object.
                    var cachedOption = new Option(type, propInfo,
                        openValuesListAtts.SingleOrDefault(), shortOptions, longOptions);
                    results.Add(cachedOption);
                }
            }

            return results;
        }

        /// <summary>
        /// Finds all verbs in objects' type definitions.
        /// </summary>
        /// <param name="objs">The objects.</param>
        /// <returns>List of all verbs found in <paramref name="objs"/>.</returns>
        public static IEnumerable<Verb> FindVerbs(params object[] objs)
        {
            if (objs == null) throw new ArgumentNullException("objs");
            return FindVerbs((from x in objs where x != null select x.GetType()).ToArray());
        }

        /// <summary>
        /// Finds all verbs in type definitions.
        /// </summary>
        /// <param name="types">The types.</param>
        /// <returns>List of all verbs found in <paramref name="types"/>.</returns>
        public static IEnumerable<Verb> FindVerbs(params Type[] types)
        {
            if (types == null) throw new ArgumentNullException("types");

            var results = new List<Verb>();
            foreach(var type in (from x in types where x != null select x).Distinct())
            {
                foreach (var propInfo in type.GetProperties(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public))
                {
                    // Find all verbs in property's attributes.
                    var globalOptionsAtts = propInfo.GetCustomAttributes(typeof(GlobalOptionsAttribute), false).OfType<GlobalOptionsAttribute>();
                    var isGlobalOptions = globalOptionsAtts.Any();

                    var verbAtts = propInfo.GetCustomAttributes(typeof(VerbAttribute), false).OfType<VerbAttribute>();
                    results.Add(new Verb(type, propInfo, verbAtts, isGlobalOptions));
                }
            }

            return results;
        }

        #endregion

        #region --- Nested types ---

        /// <summary>
        /// Represents an option.
        /// </summary>
        public class Option
        {
            /// <summary>
            /// Gets the type the option was found in. Can be null for
            /// manually prepared option or if not mappable.
            /// </summary>
            internal Type Type { get; }

            /// <summary>
            /// Gets the property the option was found for. Can be null for
            /// manually prepared option or if not mappable.
            /// </summary>
            internal PropertyInfo Property { get; }

            /// <summary>
            /// Gets the short options.
            /// </summary>
            public IEnumerable<ShortOptionAttribute> ShortOptions { get; }

            /// <summary>
            /// Gets the long options.
            /// </summary>
            public IEnumerable<LongOptionAttribute> LongOptions { get; }

            /// <summary>
            /// Gets if the property is a list for open values.
            /// </summary>
            internal OpenValuesListAttribute OpenValuesList { get; }

            /// <summary>
            /// Initializes a new instance of the <see cref="Option"/> class.
            /// </summary>
            /// <param name="type">The type the option was found in. Can be null for
            ///     manually prepared option or if not mappable.</param>
            /// <param name="property">The property the option was found for. Can be null
            ///     for manually prepared option or if not mappable.</param>
            /// <param name="openValuesList">true if the <paramref name="property"/> is a list
            ///     for open values.</param>
            /// <param name="shortOptions">The short options.</param>
            /// <param name="longOptions">The long options.</param>
            internal Option(Type type, PropertyInfo property, OpenValuesListAttribute openValuesList,
                IEnumerable<ShortOptionAttribute> shortOptions, IEnumerable<LongOptionAttribute> longOptions)
                : this(shortOptions, longOptions)
            {
                this.Type = type;
                this.Property = property;
                this.OpenValuesList = openValuesList;
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="Option"/> class.
            /// </summary>
            /// <param name="shortOptions">The short options.</param>
            /// <param name="longOptions">The long options.</param>
            public Option(IEnumerable<ShortOptionAttribute> shortOptions,
                IEnumerable<LongOptionAttribute> longOptions)
            {
                this.ShortOptions = shortOptions;
                this.LongOptions = longOptions;
            }
        }

        /// <summary>
        /// Represents a verb.
        /// </summary>
        public class Verb
        {
            /// <summary>
            /// Gets the type the verb was found in. Can be null
            /// for manually prepared verb or if not mappable.
            /// </summary>
            internal Type Type { get; }

            /// <summary>
            /// Gets the property the verb was found for. Can be null
            /// for manually prepared verb or if not mappable.
            /// </summary>
            internal PropertyInfo Property { get; }

            /// <summary>
            /// Gets the verbs.
            /// </summary>
            public IEnumerable<VerbAttribute> Verbs { get; }

            /// <summary>
            /// Gets whether this does not represent a verb but a global
            /// options container.
            /// </summary>
            public bool IsGlobalOptions { get; }

            /// <summary>
            /// Initializes a new instance of the <see cref="Verb"/> class.
            /// </summary>
            /// <param name="type">The type the option was found in. Can be null for
            ///     manually prepared option or if not mappable.</param>
            /// <param name="property">The property the option was found for. Can be null
            ///     for manually prepared option or if not mappable.</param>
            /// <param name="verbs">The verbs.</param>
            /// <param name="isGlobalOptions">true if the <paramref name="property"/> is a container
            ///     for global options, false if it is a regular option.</param>
            internal Verb(Type type, PropertyInfo property,
                IEnumerable<VerbAttribute> verbs, bool isGlobalOptions)
                : this(verbs, isGlobalOptions)
            {
                this.Type = type;
                this.Property = property;
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="Verb"/> class.
            /// </summary>
            /// <param name="verbs">The verbs.</param>
            /// <param name="isGlobalOptions">true if the <paramref name="property"/> is a container
            ///     for global options, false if it is a regular option.</param>
            public Verb(IEnumerable<VerbAttribute> verbs, bool isGlobalOptions)
            {
                this.Verbs = verbs;
                this.IsGlobalOptions = isGlobalOptions;
            }
        }

        #endregion
    }
}
