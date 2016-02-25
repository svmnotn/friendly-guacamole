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
}
