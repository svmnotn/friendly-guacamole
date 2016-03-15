﻿public class Grid {
  Cell[,] grid;
  
  public Grid() {
	  grid = new Cell[,] {
      {Cell.def, Cell.def, Cell.def},
      {Cell.def, Cell.def, Cell.def},
      {Cell.def, Cell.def, Cell.def}
		};
	}

  public Grid(Cell[,] grid) {
    this.grid = grid;
  }

  public bool Play(Vector pos, Player p) {
    if (Played (pos) || p == null) {
      return false;
    }
    grid [pos.x, pos.y] = new Cell(p);
    return true;
  }

  public Cell GetCell(Vector pos) {
    return grid [pos.x, pos.y];
  }

  public string TypeAt(Vector pos) {
    var cell = GetCell (pos);
    if (!cell.played) {
      return "";
    }
    return cell.player.type;
  }

  public bool Played(Vector pos) {
    return GetCell (pos).played;
  }
}
