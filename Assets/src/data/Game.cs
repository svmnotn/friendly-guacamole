using System.Collections.Generic;
using System;
// TODO REMOVE
using UnityEngine;

public class Game {
  Queue<Player> players;
  public Player curr;
  public Action PlayerSwitch;
  public Action<Vector> GridAdded;
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

  public void Play(Vector grid, Vector cell) {
    var g = GetGrid (grid);
    var c = g.grid [cell.x, cell.y];
    if (!c.played) {
      c = new Cell (curr);
      Next ();
      g.grid[cell.x, cell.y] = c;
    }

    Check (grid, cell);
  }

  void Next() {
    curr = players.Dequeue ();
    players.Enqueue (curr);
    if (PlayerSwitch != null)
      PlayerSwitch ();
  }

  bool Check(Vector grid, Vector cell) {
    
    // TODO: Check if there is a winner 
    
    return false;
  }
    
  Grid GetGrid(Vector click) {
    Grid grid;
    map.TryGetValue(click, out grid);
    return grid;
  }
}
