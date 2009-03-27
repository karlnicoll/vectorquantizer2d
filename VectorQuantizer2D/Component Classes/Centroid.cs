using System;
using System.Collections.Generic;
using System.Text;

namespace VectorQuantizer2D
{
    /// <summary>
    /// A centroid that can be used in a 2-dimensional vector quantizer
    /// </summary>
    /// <typeparam name="VectorValue">The type that will be returned as the centroids value</typeparam>
    public class Centroid<VectorValue> : ITwoDimensionalVector
    {
        //==================================================================================
        #region Data Structures



        #endregion

        //==================================================================================
        #region Enumerations



        #endregion

        //==================================================================================
        #region Constants


        #endregion

        //==================================================================================
        #region Events



        #endregion

        //==================================================================================
        #region Private Variables

        /// <summary>
        /// The value that this centroid represents
        /// </summary>
        private VectorValue representativeValue;
        /// <summary>
        /// The coordinates of the centroid
        /// </summary>
        private Vector2D coords;

        #endregion

        //==================================================================================
        #region Constructors/Destructors

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="Coords">The co-ordinates of this centroid</param>
        /// <param name="Val">The value that the centroid represents</param>
        public Centroid(Vector2D Coords, VectorValue Val)
        {
            coords = Coords;
            representativeValue = Val;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="XValue">The X-coordinate of the vector</param>
        /// <param name="YValue">The Y-coordinate of the vector</param>
        /// <param name="Val">The value that this centroid represents</param>
        public Centroid(double XValue, double YValue, VectorValue Val)
            : this(new Vector2D(XValue, YValue), Val)
        { }

        #endregion

        //==================================================================================
        #region Public Properties

        #region TwoDimensionalVector Members

        /// <summary>
        /// Gets or sets the X coordinate of this centroid
        /// </summary>
        public double X
        {
            get { return coords.X; }
            set { coords.X = value; }
        }

        /// <summary>
        /// Gets or sets the Y coordinate of this centroid
        /// </summary>
        public double Y
        {
            get { return coords.Y; }
            set { coords.Y = value; }
        }

        /// <summary>
        /// Gets or sets the value that this centroid represents
        /// </summary>
        public VectorValue Value
        {
            get { return representativeValue; }
            set { representativeValue = value; }
        }

        /// <summary>
        /// Gets the coordinates of this centroid
        /// </summary>
        /// <returns>A 2-dimensional vector representing the coordinates of this centroid</returns>
        public Vector2D GetCoords()
        {
            return coords;
        }

        #endregion

        #endregion

        //==================================================================================
        #region Public Methods

        /// <summary>
        /// Returns a string representation of this instance
        /// </summary>
        public override string ToString()
        {
            return "[Centroid: " + Value.ToString() + Environment.NewLine + "X=" + X.ToString() + Environment.NewLine + "Y=" + Y.ToString();
        }

        /// <summary>
        /// Gets the type of the value that this centroid represents
        /// </summary>
        public System.Type GetValueType()
        {
            return typeof(VectorValue);
        }

        #endregion

        //==================================================================================
        #region Private/Protected Methods



        #endregion
    }
}
