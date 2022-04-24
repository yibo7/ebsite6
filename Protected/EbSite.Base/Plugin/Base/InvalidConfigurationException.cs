using System;
using System.Collections.Generic;
using System.Text;

namespace EbSite.Base.Plugin.Base
{
    /// <summary>
    /// Represents errors that occur while decoding the Provider's Configuration String.
    /// </summary>
    public class InvalidConfigurationException : Exception
    {

        /// <summary>
        /// Initializes a new instance of the <b>InvalidConfigurationException</b> class.
        /// </summary>
        public InvalidConfigurationException() : base() { }

        /// <summary>
        /// Initializes a new instance of the <b>InvalidConfigurationException</b> class.
        /// </summary>
        /// <param name="message">The error message.</param>
        public InvalidConfigurationException(string message) : base(message) { }

        /// <summary>
        /// Initializes a new instance of the <b>InvalidConfigurationException</b> class.
        /// </summary>
        /// <param name="message">The error message.</param>
        /// <param name="innerException">The inner Exception.</param>
        public InvalidConfigurationException(string message, Exception innerException) : base(message, innerException) { }

        /// <summary>
        /// Initializes a new instance of the <b>InvalidConfigurationException</b> class.
        /// </summary>
        /// <param name="info">The serialization info.</param>
        /// <param name="context">The streaming context.</param>
        public InvalidConfigurationException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context) { }

    }
}
