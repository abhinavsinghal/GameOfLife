This program generates and displays output based on Conway's Game Of Life paradigm.

The following four criteria need to be met to create the Game of Life grid -
    Any live cell with fewer than two live neighbours dies, as if caused by under-population.
    Any live cell with two or three live neighbours lives on to the next generation.
    Any live cell with more than three live neighbours dies, as if by overcrowding.
    Any dead cell with exactly three live neighbours becomes a live cell, as if by reproduction.


In the program, a console is used to input row, column sizes.
The iterations to be run for the cycle are taken as input as well.

A random seed is used to generate the grid initially.

Code in this program was initially compiled using framework 4.5.
To run the program, open the csproj file in Visual Studio.

There is a set of nunit test cases in a class file attached to the project.
Once the program compiles successfully, nunit.exe can be attached to the dll and test cases can be run using Nunit UI.

Keeping with the object oriented paradigm, two classes Map and Cell have been used.
Map stores information related to the grid used to generate the Game of Life.
Cell stores information related to a cell within the grid i.e. the x,y co-ordinates and also the value for that cell i.e. whether the cell is dead or alive.