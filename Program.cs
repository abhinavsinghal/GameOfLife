using System;
using System.Collections.Generic;
using System.Linq;

namespace GameOfLife
{

    /// <summary>
    /// Building Game of Life.
    /// This is the entry program.
    /// There are two additional classes - Map (for the Game of Life Map grid) and Cell (representing every individual cell on the map).
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //Read console input
                Console.Write("Enter grid row count : ");  //Grid size - row count
                int row = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter grid column count : "); //Grid size - column count
                int column = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter grid iteration count : "); //Grid size - iterations for running game
                int iteration = Convert.ToInt32(Console.ReadLine());

                //Initialize the map
                Map map = new Map(row, column);
                map.buildMap();

                //Initializing values using random series
                //Since this is the first and a random seed, cells are associated dead or alive randomly and do not follow any Game of Life rules
                //Next iterations will follow the rules defined by Conway for the Game of Life.
                Random random = new Random();
                foreach (Cell cell in map.currentList)
                {
                    cell.Value = random.Next(0, 3) == 1 ? true : false;
                }

                Console.WriteLine();
                Console.WriteLine("Every iteration (except the first) will follow the Game of Life rules for a random start seed");
                Console.WriteLine("'*' indicates an alive cell. '.' is a dead cell");
                Console.WriteLine();

                //Run the iterations while simaltaneously doing a print.
                //Every iteration (except the first) will follow the Game of Life rules
                for (int iterationCount = 0; iterationCount < iteration; iterationCount++)
                {
                    int columnCount = 0;
                    foreach (Cell cell in map.currentList)
                    {
                        Console.Write(cell.Value ? " * " : " . ");
                        columnCount++;
                        if (columnCount == column)
                        {
                            Console.WriteLine();
                            columnCount = 0;
                        }
                    }
                    Console.ReadLine();
                    map.buildMapForNextIteration();
                }
            }
            catch (Exception)
            {
                //Handle exception using any logging mechanism
            }
        }
    }
}
