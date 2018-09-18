namespace Shargs.Mapping
{
    using System;

    /// <summary>
    /// Represents a node model validation exception.
    /// </summary>
    class NodeModelValidationException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NodeModelValidationException"/> class.
        /// </summary>
        public NodeModelValidationException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NodeModelValidationException"/> class.
        /// </summary>
        /// <param name="message">The exception message.</param>
        public NodeModelValidationException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NodeModelValidationException"/> class.
        /// </summary>
        /// <param name="message">The exception message.</param>
        /// <param name="innerException">The inner exception.</param>
        public NodeModelValidationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
