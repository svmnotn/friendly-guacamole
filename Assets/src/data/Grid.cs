public class Grid {
  Cell[,] grid = {
    {Cell.def, Cell.def, Cell.def},
    {Cell.def, Cell.def, Cell.def},
    {Cell.def, Cell.def, Cell.def}
  };

  public bool play(Vector pos, Player p) {
    if (grid [pos.x, pos.y].played) {
      return false;
    }

    grid [pos.x, pos.y] = new Cell(p.type);
    return true;
  }

  public Cell cell(Vector pos) {
    return grid [pos.x, pos.y];
  }
}
