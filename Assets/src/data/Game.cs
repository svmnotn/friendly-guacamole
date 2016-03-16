using System.Collections.Generic;
using UnityEngine;
public class Game {
  Queue<Player> players;
  public Player curr;
  public Dictionary<Vector, Grid> map;

  public Game(Queue<Player> players) {
    this.players = players;
    Next ();
    map = new Dictionary<Vector, Grid> ();
    map.Add (new Vector (), new Grid ());
  }

  public Cell Play(Vector grid, Vector cell) {
    var g = FromGridVector (grid);
    var c = g.grid [cell.x, cell.y];
    if (!c.played) {
      c = new Cell (curr);
      Next ();
      g.grid[cell.x, cell.y] = c;
    }
    return c;
  }

  void Next() {
    curr = players.Dequeue ();
    players.Enqueue (curr);
  }

  public Winner Check(Vector click) {
    
    // TODO: Check if there is a winner 
    
    return new Winner();
  }
    
  public Grid FromGridVector(Vector click) {
    Grid grid;
    map.TryGetValue(click, out grid);
    return grid;
  }

  public Cell Cell(Vector grid, Vector cell) {
    return FromGridVector(grid).grid[cell.x,cell.y];
  }
}
