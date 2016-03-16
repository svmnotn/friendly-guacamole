using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class MapController : MonoBehaviour {
  Game game;
  public GameObject grid;
  public Color won;
  public Text player;

  void Start () {
    var players = new Queue<Player>();
    // TODO CONFIGS
    players.Enqueue (new Player("X"));
    players.Enqueue (new Player("O"));
    game = new Game (players);
    var pos = new Vector ();
    Grid tmp;
    game.map.TryGetValue (pos, out tmp);
    CreateGrid (pos, tmp);
    player.text = "Current Player: '" + game.curr.type + "' Score: " + game.curr.score;
  }

  public void Click(Button b) {
    var posGrid = GridFromButton (b);
    var posCell = FromOrdinal (b);
    var cell = game.Play (posGrid, posCell);
    b.GetComponentInChildren<Text> ().text = cell.player.type;
    b.interactable = false;

    if (cell.won) {
      var colors = b.colors;
      colors.disabledColor = won;
      b.colors = colors;
    }
    player.text = "Current Player: '" + game.curr.type + "' Score: " + game.curr.score;
  }
    
  void CreateGrid (Vector pos, Grid g) {
    var newGrid = (GameObject) Instantiate (grid, GridToWorld(pos), Quaternion.identity);
    var bttns = newGrid.GetComponentsInChildren<Button>();
    int i = 0;
    foreach (var b in bttns) {
      var btn = b;
      b.onClick.AddListener(() => Click(btn));
      b.transform.name = "" + i++;
    }
  }

  Transform GetGridTransform(Button b) {
    return b.transform.parent.parent.parent;
  }

  Vector3 GridToWorld (Vector p) {
    return new Vector3 (p.x * 3, p.y * 3, 0);
  }

  Vector GridFromWorld (Vector3 p) {
    return new Vector ((int)p.x / 3, (int)p.y / 3);
  }

  Vector GridFromButton (Button b) {
    return GridFromWorld(GetGridTransform(b).position);
  }

  Vector FromOrdinal(Button b){
    var i = int.Parse (b.transform.name);
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
