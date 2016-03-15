using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class MapController : MonoBehaviour {
  Game game;
  public GameObject grid;

  void Start () {
    var players = new List<Player>();
    // TODO CONFIGS
    players.Add (new Player("X"));
    players.Add (new Player("O"));
    game = new Game (players);
    var pos = new Vector ();
    Grid tmp;
    game.map.TryGetValue (pos, out tmp);
    CreateGrid (pos, tmp);
  }

  public void Click(Button b) {
    // TODO Game.
  }

  public void CreateGrid (Vector pos, Grid g) {
    var newGrid = (GameObject) Instantiate (grid, GridToWorld(pos), Quaternion.identity);
    var bttns = newGrid.GetComponentsInChildren<Button>();
    int i = 0;
    foreach (var b in bttns) {
      b.onClick.AddListener(() => Click(b));
      b.GetComponentInChildren<Text> ().text = "" + i;
      b.transform.name = "" + i++;
      b.GetComponentInChildren<Text> ().text = g.TypeAt (FromOrdinal (b.transform.name));
    }
  }

  public Vector3 GridToWorld (Vector p) {
    return new Vector3 (p.x * 3, p.y * 3, 0);
  }

  public Vector GridFromWorld (Vector3 p) {
    return new Vector ((int)p.x / 3, (int)p.y / 3);
  }

  public Vector FromOrdinal(string s){
    var i = int.Parse (s);
    switch (i) {
    case 0: 
      return new Vector ();
    case 1:
      return new Vector (0,1);
    case 2:
      return new Vector (0,2);
    case 3:
      return new Vector (1,0);
    case 4:
      return new Vector (1,1);
    case 5:
      return new Vector (1,2);
    case 6:
      return new Vector (2,0);
    case 7:
      return new Vector (2,1);
    case 8:
      return new Vector (2,2);
    }
    return new Vector ();
  }
}
