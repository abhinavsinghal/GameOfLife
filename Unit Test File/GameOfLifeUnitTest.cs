using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameOfLife;
using NUnit.Framework;

namespace GameOfLifeUnitTest
{
    /// <summary>
    /// Unit tests are written based on familiar and common patterns on this algorithm e.g. Blinker or Block.
    /// Test Results should match expected pattern formations.
    /// NUnit Assertions are based on these result matches.
    /// For this application, NUnits have been provided for public methods only.
    /// </summary>
    [TestFixture]
    class GameOfLifeUnitTest
    {
        [SetUp]
        public void Init()
        {
            //No code required here
        }

        /// <summary>
        /// Building Blinker Pattern and then assert if values in map are correct or not.
        /// Each iteration of the algorithm is called directly and then the values of the resulting map
        /// are compared with the expected results.
        /// If they match, the test has passed.
        /// This is done for a total of 1 iteration, ensuring the map is generated properly.
        /// This nunit case will test out both public methods (buildMap and buildMapForNextIteration) for the Map class.
        /// These two methods will internally test out the private class methods.
        /// </summary>
        [Test]
        public void AssertBlinkerPattern()
        {
            Map map = new Map(5, 5); //A 5 x 5 array is enough for unit testing
            map.buildMap();

            //Building a blinker in two iterations by initializing values
            //* is alive cell, . is dead cell
            // Initial Setup
            // . . . . .
            // . . * . .
            // . . * . .
            // . . * . .
            // . . . . .
            // After 1st Iteration
            // . . . . .
            // . . . . .
            // . * * * .
            // . . . . .
            // . . . . .
            map.currentList.Where(x => x.X == 1 && x.Y == 2).First().Value = true; //Access and set co-ordinates
            map.currentList.Where(x => x.X == 2 && x.Y == 2).First().Value = true; //Access and set co-ordinates
            map.currentList.Where(x => x.X == 3 && x.Y == 2).First().Value = true; //Access and set co-ordinates

            //Run 2 iterations to test the results
            bool firstIterationResult = true;

            map.buildMapForNextIteration();

            //First Iteration
            firstIterationResult = map.currentList.Where(x => x.X == 2 && x.Y == 1).First().Value &&
                map.currentList.Where(x => x.X == 2 && x.Y == 2).First().Value &&
                map.currentList.Where(x => x.X == 2 && x.Y == 3).First().Value;

            Assert.AreEqual(firstIterationResult, true);
        }

        /// <summary>
        /// This will be the negative test for blinker pattern.
        /// Build a Blinker Pattern and then assert if values in map are correct or not.
        /// Each iteration of the algorithm is called directly and then the values of the resulting map
        /// are compared with the expected results.
        /// If they match, the test has passed.
        /// This is done for a total of 1 iteration, ensuring the map is generated properly.
        /// This nunit case will test out both public methods (buildMap and buildMapForNextIteration) for the Map class.
        /// </summary>
        [Test]
        public void AssertBlinkerPatternNegativeTest()
        {
            Map map = new Map(5, 5); //A 5 x 5 array is enough for unit testing
            map.buildMap();

            //Building a blinker in two iterations by initializing values
            //* is alive cell, . is dead cell
            // Initial Setup
            // . . . . .
            // . . * . .
            // . . * . .
            // . . * . .
            // . . . . .
            // After 1st Iteration
            // . . . . .
            // . . . . .
            // . * * * .
            // . . . . .
            // . . . . .
            map.currentList.Where(x => x.X == 1 && x.Y == 2).First().Value = true; //Access and set co-ordinates
            map.currentList.Where(x => x.X == 2 && x.Y == 2).First().Value = true; //Access and set co-ordinates
            map.currentList.Where(x => x.X == 3 && x.Y == 2).First().Value = true; //Access and set co-ordinates

            //Run 2 iterations to test the results
            bool firstIterationResult = true;

            map.buildMapForNextIteration();

            //First Iteration
            firstIterationResult = map.currentList.Where(x => x.X == 2 && x.Y == 1).First().Value &&
                map.currentList.Where(x => x.X == 2 && x.Y == 2).First().Value &&
                map.currentList.Where(x => x.X == 2 && x.Y == 4).First().Value; //Changed 3 to 4 in Y co-ordinate
            Assert.AreEqual(firstIterationResult, false);
        }

        /// <summary>
        /// This will be a unit test for Block pattern.
        /// Build a Block Pattern and then assert if values in map are correct or not.
        /// Each iteration of the algorithm is called directly and then the values of the resulting map
        /// are compared with the expected results.
        /// If they match, the test has passed.
        /// This is done for a total for the 2nd iteration, ensuring the map is generated properly.
        /// This nunit case will test out both public methods (buildMap and buildMapForNextIteration) for the Map class.
        /// </summary>
        [Test]
        public void AssertBlockPattern()
        {
            Map map = new Map(4, 4); //A 4 x 4 array is enough for unit testing
            map.buildMap();

            //Building a block in two iterations by initializing values
            //* is alive cell, . is dead cell
            // Initial
            // . . . . 
            // . * * . 
            // . * * . 
            // . . . .
            // After 1st Iteration
            // . . . . 
            // . * * . 
            // . * * . 
            // . . . .
            // After 2nd Iteration
            // . . . . 
            // . * * . 
            // . * * . 
            // . . . .
            map.currentList.Where(x => x.X == 1 && x.Y == 1).First().Value = true; //Access and set co-ordinates
            map.currentList.Where(x => x.X == 1 && x.Y == 2).First().Value = true; //Access and set co-ordinates
            map.currentList.Where(x => x.X == 2 && x.Y == 1).First().Value = true; //Access and set co-ordinates
            map.currentList.Where(x => x.X == 2 && x.Y == 2).First().Value = true; //Access and set co-ordinates

            //Run two iterations
            map.buildMapForNextIteration();
            map.buildMapForNextIteration();

            bool iterationsResult = true;

            iterationsResult = map.currentList.Where(x => x.X == 1 && x.Y == 1).First().Value &&
                map.currentList.Where(x => x.X == 1 && x.Y == 2).First().Value &&
                map.currentList.Where(x => x.X == 2 && x.Y == 1).First().Value &&
                map.currentList.Where(x => x.X == 2 && x.Y == 2).First().Value;

            Assert.AreEqual(iterationsResult, true);
        }

        /// <summary>
        /// This will be the negative test for Block pattern.
        /// Build a Block Pattern and then assert if values in map are correct or not.
        /// Each iteration of the algorithm is called directly and then the values of the resulting map
        /// are compared with the expected results.
        /// If they match, the test has passed.
        /// This is done for a total for the 2nd iteration, ensuring the map is generated properly.
        /// This nunit case will test out both public methods (buildMap and buildMapForNextIteration) for the Map class.
        /// </summary>
        [Test]
        public void AssertBlockPatternNegativeTest()
        {
            Map map = new Map(4, 4); //A 4 x 4 array is enough for unit testing
            map.buildMap();

            //Building a blinker in two iterations by initializing values
            //* is alive cell, . is dead cell
            // Initial
            // . . . . 
            // . * * . 
            // . * * . 
            // . . . .
            // After 1st Iteration
            // . . . . 
            // . * * . 
            // . * * . 
            // . . . .
            // After 2nd Iteration
            // . . . . 
            // . * * . 
            // . * * . 
            // . . . .
            map.currentList.Where(x => x.X == 1 && x.Y == 1).First().Value = true; //Access and set co-ordinates
            map.currentList.Where(x => x.X == 1 && x.Y == 2).First().Value = true; //Access and set co-ordinates
            map.currentList.Where(x => x.X == 2 && x.Y == 1).First().Value = true; //Access and set co-ordinates
            map.currentList.Where(x => x.X == 2 && x.Y == 2).First().Value = true; //Access and set co-ordinates

            //Run two iterations
            map.buildMapForNextIteration();
            map.buildMapForNextIteration();

            bool iterationsResult = true;

            iterationsResult = map.currentList.Where(x => x.X == 1 && x.Y == 1).First().Value &&
                map.currentList.Where(x => x.X == 1 && x.Y == 2).First().Value &&
                map.currentList.Where(x => x.X == 2 && x.Y == 1).First().Value &&
                map.currentList.Where(x => x.X == 3 && x.Y == 2).First().Value;  //X Co-ordinate changed to 3 instead of 2

            Assert.AreEqual(iterationsResult, false);
        }
    }
}
