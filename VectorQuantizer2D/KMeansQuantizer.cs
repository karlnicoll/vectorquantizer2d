using System;
using System.Collections.Generic;
using System.Text;

namespace VectorQuantizer2D
{

    /// <summary>
    /// A class that quantizes points in a two-dimensioal area
    /// </summary>
    /// <typeparam name="CodebookType">The data type of the centroid values</typeparam>
    public class KMeansQuantizer<CodebookType>
        where CodebookType : IComparable
    {

        //==================================================================================
        #region Data Structures



        #endregion

        //==================================================================================
        #region Enumerations



        #endregion

        //==================================================================================
        #region Constants

        private const int DEFAULT_CENTROID_LIST_CAPACITY = 8;

        #endregion

        //==================================================================================
        #region Events



        #endregion

        //==================================================================================
        #region Private Variables

        /// <summary>
        /// The codebook
        /// </summary>
        private List<Centroid<CodebookType>> centroids;

        #endregion

        //==================================================================================
        #region Constructors/Destructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        public KMeansQuantizer()
            : this(null)
        { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="Centroids">The centroids</param>
        public KMeansQuantizer(IEnumerable<Centroid<CodebookType>> InitialCodebook)
        {
            //Initialize the codebook
            centroids = new List<Centroid<CodebookType>>(DEFAULT_CENTROID_LIST_CAPACITY);

            //Add values to the codebook if applicable
            SetCodebook(InitialCodebook);
        }

        #endregion

        //==================================================================================
        #region Public Properties

        /// <summary>
        /// Gets or sets the codebook for this quantizer
        /// </summary>
        public List<Centroid<CodebookType>> Codebook
        {
            get { return centroids; }
            set { centroids = value; }
        }

        #endregion

        //==================================================================================
        #region Public Methods

        /// <summary>
        /// Clears the codebook and creates a new one using the given codebook
        /// </summary>
        /// <param name="NewCodebook"></param>
        public void SetCodebook(IEnumerable<Centroid<CodebookType>> NewCodebook)
        {
            centroids = new List<Centroid<CodebookType>>();

            if (NewCodebook != null)
                centroids.AddRange(NewCodebook);
        }

        /// <summary>
        /// Quantizes vectors using the codebook
        /// </summary>
        /// <param name="Vectors">The vectors to quantize</param>
        /// <returns>An array containing the code values that correspond to what the vectors were quantized to</returns>
        public CodebookType[] Quantize(ITwoDimensionalVector[] Vectors)
        {
            //INITIAL CHECKS
            //==============

            //Empty Codebook check
            if (centroids.Count == 0)
            {
                throw new EmptyCodebookException();
            }

            //Empty vector list check
            if (Vectors == null || Vectors.Length == 0)
            {
                throw new NullReferenceException("There are no vectors to quantize");
            }



            //VARIABLE DECLARATION
            //====================

            //Infinite loop protection
            List<int> CurrentChanges = new List<int>(Vectors.Length);   //Holds the changes that were made in the present iteration
            List<int> PreviousChanges;                                  //Holds the changes that were made in the previous iteration

            //A duplicate codebook so that centroid changes do not persist between quanizations
            Centroid<CodebookType>[] centroidsCopy = centroids.ToArray();

            //The centroid for the currently examined vector
            CodebookType curVectorQuantizedValue;

            //Returned values
            //CodebookType[] categorizations = System.Collections.Enumerable.Repeat(true, result.TotalPages + 1).ToArray()


            CodebookType[] quantizedValues = new CodebookType[Vectors.Length];  //Holds the results

            //Change detection variables
            bool changeMade = true;             //When TRUE means that a change was made this iteration, when FALSE, no changes to the quantization was made
            bool firstIteration = true;         //Is set to true throughout the first iteration of the algoithm loop, and false afterwards




            //ALGORITHM
            //=========

            while (changeMade)
            {
                changeMade = (firstIteration ? true : false);   //Sets the default value of "changeMade". If this is the first run of the loop, this is obviously true, so set it so.

                //Make the changes made in the last iteration the previous changes,
                //and any changes made during THIS iteration get stored in the CurrentChanges list
                PreviousChanges = CurrentChanges;
                CurrentChanges = new List<int>(Vectors.Length);

                //Loop through the input vectors
                for (int vectorIndex = 0; vectorIndex < Vectors.Length; vectorIndex++)
                {

                    //Quantize the input vector
                    curVectorQuantizedValue = QuantizeVector(Vectors[vectorIndex], centroidsCopy);


                    //If this is the first run, we need to just store the quantized value, comparison is not necessary
                    if (firstIteration)
                    {
                        //Add the change to the list of changes and change the codebook value of the current vector
                        CurrentChanges.Add(vectorIndex);
                        quantizedValues[vectorIndex] = curVectorQuantizedValue;

                        //NOT NEEDED, changeMade is automatically TRUE on the first run
                        //changeMade = true;    
                    }


                    //Check to see if the centroid representing the current vector has changed
                    else
                    {
                        //If a change has occured, then add this vector's index to the list of changes and set the categorization for this vector
                        if (curVectorQuantizedValue.CompareTo(quantizedValues[vectorIndex]) != 0)
                        {
                            CurrentChanges.Add(vectorIndex);
                            quantizedValues[vectorIndex] = curVectorQuantizedValue;
                            changeMade = true;
                        }

                    }
                    

                    
                }

                //Check to see if the changes made this time match the changes made last time.
                //If so, the loop has bugged out (as it often may), and we need to exit the loop
                if (InfiniteLoopCheck(CurrentChanges, PreviousChanges) == true)
                {
                    changeMade = false;
                }

                //If the loop is still good to continue, then we need to move the centroids to
                //the average of the points that are in their respective partitions
                else
                {
                    centroidsCopy = AdjustCentroidsToVectorAverage(centroidsCopy, Vectors, quantizedValues);
                }

            }


            //FINALIZATION
            //============

            //Return the quantized vectors' values
            return quantizedValues;

           
        }

        /// <summary>
        /// Makes the coordinates of the centroids the average of the vectors that fall in the partition of the centroid
        /// </summary>
        /// <param name="Cents">The centroids whos coordinates need adjusting</param>
        /// <param name="Vectors">The vectors that were input into the quantizer that have now been quantized</param>
        /// <param name="Categorizations">The quantized values of the respective vectors</param>
        /// <returns>The centroids, adjusted to be the average of the vectors that are inside their respective partitions</returns>
        /// <remarks>Note that if a centroid does not have any vectors in it's partition will not move. This is to prevent
        /// centroids from occupying the 0,0 coordinate and scewing the results</remarks>
        private Centroid<CodebookType>[] AdjustCentroidsToVectorAverage(Centroid<CodebookType>[] Cents, ITwoDimensionalVector[] Vectors, CodebookType[] Categorizations)
        {
            //The returned centroids
            Centroid<CodebookType>[] retVal = new Centroid<CodebookType>[Cents.Length];

            //Temporary variables
            Vector2D newCoords;     //The new coordinates of the centroid we are checking
            bool centroidValueUsed; //Tells us inside the loop whether or not a centroid has any vectors inside its partition
            int checkIndex;         //Used as a loop controller when checking the categorizations array for the current centroids value
            int childVectors = 0;   //Used to determine how many vectors fall inside the current centroid's partition

            //Loop through each centroid and relocate it.
            for (int centroidIndex = 0; centroidIndex < Cents.Length; centroidIndex++)
            {
                //Check to see if the centroid's value exists in the array.
                checkIndex = 0;
                centroidValueUsed = false;
                while (checkIndex < Categorizations.Length && !centroidValueUsed)
                {
                    if (Cents[centroidIndex].Value.CompareTo(Categorizations[checkIndex]) == 0)
                    {
                        centroidValueUsed = true;
                    }
                    else
                    {
                        checkIndex++;
                    }
                }

                //Set the new centroid to be the same as the old centroid if the centroid was not used
                if (!centroidValueUsed)
                {
                    retVal[centroidIndex] = Cents[centroidIndex];
                }

                //If the centroid WAS used, adjust it to be the average of the vectors in it's partition
                else
                {
                    //Reset the variables that we need now
                    childVectors = 0;
                    newCoords = new Vector2D(0D, 0D);

                    for (int vectorIndex = 0; vectorIndex < Vectors.Length; vectorIndex++)
                    {
                        if (Categorizations[vectorIndex].CompareTo(Cents[centroidIndex].Value) == 0)
                        {
                            //Increment how many vectors are inside this centroid's partition
                            childVectors++;

                            //Add the X and Y coordinates of the child vector to this centroids new coordinates
                            newCoords.X += Vectors[vectorIndex].X;
                            newCoords.Y += Vectors[vectorIndex].Y;

                        }

                    }

                    //Average out the Coordinates
                    newCoords.X /= childVectors;
                    newCoords.Y /= childVectors;

                    //Add the adjusted centroid to the returned array
                    retVal[centroidIndex] = new Centroid<CodebookType>(newCoords, Cents[centroidIndex].Value);
                }
               
            }

            //Return the adjusted centroids.
            return retVal;
        }

        #endregion

        //==================================================================================
        #region Private/Protected Methods

        /// <summary>
        /// Checks the last made changes and the previous changes to ensure that the infinite loop condition
        /// (where the same set of vectors are just changing over and over) is not in effect.
        /// </summary>
        /// <param name="CurrentChanges">The changes that were made in the current iteration</param>
        /// <param name="PreviousChanges">The changes that were made in the last iteration</param>
        /// <returns>TRUE if the changes match those made last time, FALSE if the changes have not occured</returns>
        private bool InfiniteLoopCheck(List<int> CurrentChanges, List<int> PreviousChanges)
        {

            bool ChangesMatch = true;       //TRUE by default, but sets to FALSE if a change is found in either list that doesn't match one in the other list
            int i = 0;                      //Loop controller

            //Compare the current changes to the previous changes
            while (i < CurrentChanges.Count && ChangesMatch)
            {
                if (!PreviousChanges.Contains(CurrentChanges[i]))
                {
                    ChangesMatch = false;
                }
                else
                {
                    i++;
                }
            }

            //Reset loop controller
            i = 0;

            //Compare the previous changes to the current changes
            while (i < PreviousChanges.Count && ChangesMatch)
            {
                if (!CurrentChanges.Contains(PreviousChanges[i]))
                {
                    ChangesMatch = false;
                }
                else
                {
                    i++;
                }
            }

            //Return whether or not the changes are the same
            return ChangesMatch;

        }

        /// <summary>
        /// Quantizes a vector using the given centroids
        /// </summary>
        /// <param name="Vector">The vector to quantize</param>
        /// <param name="Centroids"></param>
        private CodebookType QuantizeVector(ITwoDimensionalVector Vector ,IEnumerable<Centroid<CodebookType>> Centroids)
        {
            IEnumerator<Centroid<CodebookType>> firstCentroid = Centroids.GetEnumerator();
            firstCentroid.MoveNext();
            CodebookType retVal = firstCentroid.Current.Value;    //The value returned to the caller

            //Temporary storage variables
            double closestDistance = double.MaxValue;     //Holds the closest distance between the current vector and a centroid found so far
            double currentDistance = double.MaxValue;     //Holds the distance between the current vector and the current centroid


            //Loop through each centroid in an attempt to quantize the vector
            foreach (Centroid<CodebookType> curCentroid in centroids)
            {
                //Get the distance between the vector and the centroid
                currentDistance = GetEuclideanDistance(Vector, curCentroid);

                //If the centroid is the close to the vector, then classify the vector as this code vector
                if (currentDistance < closestDistance)
                {
                    retVal = curCentroid.Value;
                    closestDistance = currentDistance;
                }
            }

            //Return the codebook value that was obtained
            return retVal;
        }

        /// <summary>
        /// Finds the Euclidean distance between two vectors in a 2 dimensional Euclidean space
        /// </summary>
        /// <param name="InputVector">The vector</param>
        /// <param name="CodeVector">The code vector to get the distance to</param>
        /// <returns>A double representing the distance between the input vector and the code vector</returns>
        private double GetEuclideanDistance(ITwoDimensionalVector InputVector, ITwoDimensionalVector CodeVector)
        {
            //A little bit of Pythagoras Theorem to get the line between the points
            //---------------------------------------------------------------------

            //Get the vertical and horizontal line lengths
            /* NOTE:    It doesn't matter if these values are negative now, they get
             *          squared later on, and squaring a number always makes it positive
             */
            double vert = CodeVector.Y - InputVector.Y;
            double hori = CodeVector.X - InputVector.X;

            //Get the hypoteneus according to pythagoras theorem (this is the euclidean distance)
            return Math.Sqrt((vert * vert) + (hori * hori));


        }

        #endregion
    }
}
