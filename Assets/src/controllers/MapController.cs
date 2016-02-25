using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MapController : MonoBehaviour {
   Game game;

  void Start () {
    var players = new List<Player>();
    // TODO Take in all the players
    players.Add (new Player("X"));
    players.Add (new Player("O"));
    game = new Game (players);
  }

  void Update () {
    Win ();
  }

  void Win() {
    var win = game.check ();
    if (win.win) {
      //TODO Win Game
    }
  }
}
