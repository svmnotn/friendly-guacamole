using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class MapController : MonoBehaviour {
  public GameController c;
  public GameObject grid;
  public Color won;

  void Start () {
    c.game.GridAdded += CreateGrid;
    c.game.AddGrid (new Vector());
  }

  public void Click(Button b) {
    var posGrid = GridFromButton (b);
    var posCell = FromOrdinal (b);
    b.GetComponentInChildren<Text> ().text = c.Current.type;
    b.interactable = false;
    c.game.Play (posGrid, posCell);
  }

  void CreateGrid (Vector pos) {
    var newGrid = (GameObject) Instantiate (grid, pos.World, Quaternion.identity);
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
    
  Vector GridFromButton (Button b) {
    return Vector.FromWorld(GetGridTransform(b).position);
  }

  Vector FromOrdinal(Button b){
    var i = int.Parse (b.transform.name);
    switch (i) {
    case 0: 
      return new Vector (0,0);
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
