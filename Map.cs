using System;
using System.Collections.Generic;
using System.Linq;

namespace GameOfLife
{
    /// <summary>
    /// This class is the map (or grid) for the Game of Life.
    /// It consists of a list that is a collection of cells.
    /// The size of the map i.e. rows and columns is defined by the user.
    /// </summary>
    class Map
    {
        private readonly int columnCount;  //Total columns in grid
        private readonly int rowCount; //Total rows in grid

        private List<Cell> map = new List<Cell>(); //Map collection of cells

        //Sets row and column count
        public Map(int row, int column)
        {
            this.rowCount = row;
            this.columnCount = column;
        }

        /// <summary>
        /// Build initial map.
        /// Create the collection with rows, columns and initializes values to false.
        /// </summary>
        public void buildMap()
        {
            try
            {
                Cell cell; //Individual cells
                for (int i = 0; i < rowCount; i++)
                {
                    for (int j = 0; j < columnCount; j++)
                    {
                        cell = new Cell { X = i, Y = j, Value = false };
                        map.Add(cell);
                    }
                }
            }
            catch (Exception)
            {
                //Handle Exceptions
            }
        }


        /// <summary>
        /// Build map for each iteration.
        /// Loop through the list, identify cells that will live or die after an iteration.
        /// </summary>
        public void buildMapForNextIteration()
        {
            try
            {
                List<Cell> newMap = new List<Cell>();

                foreach (Cell cell in map)
                {
                    int totalLiveCount = GetLiveNeighbourCells(cell);
                    bool aliveAfterIteration = false;
                    if (cell.Value && (totalLiveCount == 2 || totalLiveCount == 3))
                    {
                        aliveAfterIteration = true;
                    }
                    else if (!cell.Value && totalLiveCount == 3)
                    {
                        aliveAfterIteration = true;
                    }
                    newMap.Add(new Cell { X = cell.X, Y = cell.Y, Value = aliveAfterIteration });
                }
                map = newMap;
            }
            catch (Exception)
            {
                //Handle Exceptions
            }
        }

        /// <summary>
        /// Get a count of live cells.
        /// Assume here that every cell (except for boundary ones) has a 3x3 matrix surrounding it.
        /// Boundary conditions are checked for every cell.
        /// </summary>
        /// <param name="currentCell"></param>
        /// <returns></returns>
        private int GetLiveNeighbourCells(Cell currentCell)
        {
            int totalLiveCount = 0;
            int x = currentCell.X;
            int y = currentCell.Y;

            if (x != 0 && y != 0 && map.Where(cell => cell.X == x - 1 && cell.Y == y - 1).First().Value) totalLiveCount++;  //Top left cell
            if (x != 0 && map.Where(cell => cell.X == x - 1 && cell.Y == y).First().Value) totalLiveCount++;  //Top center cell
            if (x != 0 && y < columnCount - 1 && map.Where(cell => cell.X == x - 1 && cell.Y == y + 1).First().Value) totalLiveCount++;  //Top right cell

            if (y != 0 && map.Where(cell => cell.X == x && cell.Y == y - 1).First().Value) totalLiveCount++;  //Middle left cell
            if (y < columnCount - 1 && map.Where(cell => cell.X == x && cell.Y == y + 1).First().Value) totalLiveCount++;  //Middle right cell

            if (x < rowCount - 1 && y != 0 && map.Where(cell => cell.X == x + 1 && cell.Y == y - 1).First().Value) totalLiveCount++;  //Bottom left cell
            if (x < rowCount - 1 && map.Where(cell => cell.X == x + 1 && cell.Y == y).First().Value) totalLiveCount++;  //Bottom center cell
            if (x < rowCount - 1 && y < columnCount - 1 && map.Where(cell => cell.X == x + 1 && cell.Y == y + 1).First().Value) totalLiveCount++;  //Bottom right cell

            return totalLiveCount;
        }

        #region Properties

        /// <summary>
        /// Readonly property to get the current list.
        /// </summary>
        public List<Cell> currentList
        {
            get { return map; }
        }

        #endregion
    }
}
