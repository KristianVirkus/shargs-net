namespace Shargs.Mapping
{
    using System;

    /// <summary>
    /// Denotes a option property's descriptive text.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = true)]
    public sealed class OptionDescription : Attribute
    {
        #region --- Properties ---

        /// <summary>
        /// Gets the descriptive text.
        /// </summary>
        public string Text { get; }

        /// <summary>
        /// Gets the text language code.
        /// </summary>
        /// <remarks>Is null for default language. Must be a full IETF 5646 language tag,
        ///     or only the first part of it.</remarks>
        public string LanguageCode { get; }

        #endregion

        #region --- Constructors ---

        /// <summary>
        /// Initializes a new instance of the <see cref="OptionDescription"/> class.
        /// </summary>
        /// <param name="text">The descriptive text.</param>
        /// <param name="LanguageCode">The text language code. Must be a full IETF 5646
        ///     language tag, or only the first part of it.</param>
        public OptionDescription(string text, string LanguageCode = null)
        {
            this.Text = text;
            this.LanguageCode = LanguageCode;
        }

        #endregion
    }
}
