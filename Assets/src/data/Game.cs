using System.Collections.Generic;
using System;
// TODO REMOVE
using UnityEngine;

public class Game {
  Queue<Player> players;
  public Player curr;
  public Action PlayerSwitch;
  public Action<Vector> GridAdded;
  public Action<Vector, Vector> CellWon;
  Dictionary<Vector, Grid> map;

  public Game(Queue<Player> players) {
    this.players = players;
    Next ();
    map = new Dictionary<Vector, Grid> ();
  }

  public void AddGrid(Vector pos) {
    map.Add (pos, new Grid ());
    if (GridAdded != null)
      GridAdded (pos);
  }

  public void RemoveGrid(Vector pos) {
    //TODO FIX LAZY
    map.Clear ();
  }

  public bool Play(Vector grid, Vector cell) {
    var g = GetGrid (grid);
    var c = g.grid [cell.x, cell.y];

    c = new Cell (curr);
    g.grid[cell.x, cell.y] = c;

    return Check (grid, cell);
  }

  void Next() {
    curr = players.Dequeue ();
    players.Enqueue (curr);
    if (PlayerSwitch != null)
      PlayerSwitch ();
  }

  bool Check(Vector grid, Vector cell) {
    var g = GetGrid (grid);

    for (int i = 0; i < g.grid.GetLength (0); i++) {
      var c1 = g.grid [i, 0].player != null ? g.grid [i, 0].player.type : null;
      var c2 = g.grid [i, 1].player != null ? g.grid [i, 1].player.type : null;
      var c3 = g.grid [i, 2].player != null ? g.grid [i, 2].player.type : null;

      if (c1 != null && c1 == c2 && c2 == c3) {
        return true;
      }
    }
    
    for (int i = 0; i < g.grid.GetLength (1); i++) {
      var c1 = g.grid [0, i].player != null ? g.grid [0, i].player.type : null;
      var c2 = g.grid [1, i].player != null ? g.grid [1, i].player.type : null;
      var c3 = g.grid [2, i].player != null ? g.grid [2, i].player.type : null;

      if (c1 != null && c1 == c2 && c2 == c3) {
        return true;
      }
    }

		var c1 = g.grid[1,1].player != null ? g.grid[1,1].player.type : null;
		if (c1 != null){
			// TL
			var c2 = g.grid[0,0].player != null ? g.grid[0,0].player.type : null;
			var c3 = g.grid[2,2].player != null ? g.grid[2,2].player.type : null;
			if (c2 != null && c3 != null && c1 == c2 && c2 == c3){
				return true;
			}
			// TR
			c2 = g.grid[2,0].player != null ? g.grid[2,0].player.type : null;
			c3 = g.grid[0,2].player != null ? g.grid[0,2].player.type : null;
			if (c2 != null && c3 != null && c1 == c2 && c2 == c3){
				return true;
			}
		}

    Next ();
    return false;
  }
    
  Grid GetGrid(Vector click) {
    Grid grid;
    map.TryGetValue(click, out grid);
    return grid;
  }
}
