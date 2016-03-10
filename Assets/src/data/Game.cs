using System.Collections.Generic;

public class Game {
  List<Player> players;
  Player curr;
  Dictionary<Vector, Grid> map;

  public Game(List<Player> players) {
    this.players = players;
    curr = players.ToArray () [0];
    map = new Dictionary<Vector, Grid> ();
    map.Add (new Vector (0, 0), new Grid ());
  }
  
  public Winner Check(Vector click) {
    var gridV = ClickToGrid(click);
    var grid = FromGridVector(gridV);
    
    // TODO: Check if there is a winner 
    
    return new Winner();
  }
  
  Vector ClickToGrid(Vector click) {
    var x = click.x % 3;
    var y = click.y % 3;
    return new Vector(x,y);
  }
  
  Grid FromGridVector(Vector click) {
    Grid grid = null;
    map.TryGetValue(click, grid);
    return grid;
  }
}
