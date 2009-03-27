using System;
using System.Collections.Generic;
using System.Text;

namespace VectorQuantizer2D
{
    /// <summary>
    /// Represents a 2-dimensional vector that can be quantized
    /// </summary>
    public class Vector2D : ITwoDimensionalVector
    {

        //==================================================================================
        #region Data Structures



        #endregion

        //==================================================================================
        #region Enumerations



        #endregion

        //==================================================================================
        #region Constants

        /// <summary>
        /// The default value for X
        /// </summary>
        private const double DEFAULT_VALUE_X = 0D;

        /// <summary>
        /// The default value for Y
        /// </summary>
        private const double DEFAULT_VALUE_Y = 0D;

        #endregion

        //==================================================================================
        #region Events



        #endregion

        //==================================================================================
        #region Private Variables

        /// <summary>
        /// The value of X for this vector
        /// </summary>
        private double x;

        /// <summary>
        /// The value of Y for this vector
        /// </summary>
        private double y;

        #endregion

        //==================================================================================
        #region Constructors/Destructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        public Vector2D()
            : this(DEFAULT_VALUE_X, DEFAULT_VALUE_Y)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="Xvalue">The value of X in this vector</param>
        /// <param name="Yvalue">The value of Y in this vector</param>
        public Vector2D(double Xvalue, double Yvalue)
        {
            x = Xvalue;
            y = Yvalue;
        }

        #endregion

        //==================================================================================
        #region Public Properties

        #region TwoDimensionalVector Members

        /// <summary>
        /// Gets or sets the X value of this instance
        /// </summary>
        public double X
        {
            get { return x; }
            set { x = value; }
        }

        /// <summary>
        /// Gets or sets the value of Y for this vector
        /// </summary>
        public double Y
        {
            get { return y; }
            set { y = value; }
        }

        #endregion

        #endregion

        //==================================================================================
        #region Public Methods

        public override string ToString()
        {
            return "X=" + x.ToString() + "\tY=" + y.ToString();
        }

        #endregion

        //==================================================================================
        #region Private/Protected Methods



        #endregion
    }
}
