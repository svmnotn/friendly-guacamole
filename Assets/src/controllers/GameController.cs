using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {
  public Game game;

  public Player Current {
    get { return game.curr; }
  }

  void Awake () {
    var players = new Queue<Player>();
    // TODO CONFIGS
    players.Enqueue (new Player("X"));
    players.Enqueue (new Player("O"));
    game = new Game (players);
  }
}
