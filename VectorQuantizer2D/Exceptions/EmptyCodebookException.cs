using System;
using System.Collections.Generic;
using System.Text;

namespace VectorQuantizer2D
{
    /// <summary>
    /// Thrown when a quantization is attempted with an empty codebook
    /// </summary>
    class EmptyCodebookException : ApplicationException
    {
        //==================================================================================
        #region Data Structures



        #endregion

        //==================================================================================
        #region Enumerations



        #endregion

        //==================================================================================
        #region Constants

        private const string DEFAULT_MESSAGE = "Quantization Fails: Codebook contains no vectors.";

        #endregion

        //==================================================================================
        #region Events



        #endregion

        //==================================================================================
        #region Private Variables

        #endregion

        //==================================================================================
        #region Constructors/Destructors

        /// <summary>
        /// Constructor
        /// </summary>
        public EmptyCodebookException()
            : this(DEFAULT_MESSAGE)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="Message">The message to describe what has happened</param>
        public EmptyCodebookException(string Message)
            : base(Message)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="Message">The message to describe what has happened</param>
        /// <param name="InnerException">The exception that led to this exception</param>
        public EmptyCodebookException(string Message, Exception InnerException)
            : base(Message, InnerException)
        {
        }

        #endregion

        //==================================================================================
        #region Public Properties


        #endregion

        //==================================================================================
        #region Public Methods


        #endregion

        //==================================================================================
        #region Private/Protected Methods



        #endregion
    }
}
