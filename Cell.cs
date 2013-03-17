
namespace GameOfLife
{
    /// <summary>
    /// This class is the placeholder for every individual cell on a grid.
    /// It consists of the co-ordinates of the cell on teh grid and the state i.e. dead or alive
    /// </summary>
    class Cell
    {
        public int X { get; set; } //X-coordinate
        public int Y { get; set; } //Y-coordinate
        public bool Value { get; set; }  //Dead or Alive
    }
}
