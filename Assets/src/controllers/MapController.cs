using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class MapController : MonoBehaviour {
  public GameController c;
  public GameObject grid;
  public Color won;
  Dictionary<Vector, List<Button>> gridsBttns;

  void Start () {
    gridsBttns = new Dictionary<Vector, List<Button>> ();
    c.game.GridAdded += CreateGrid;
    c.game.CellWon += WinCell;
    c.game.AddGrid (new Vector());
  }

  public void Click(Button b) {
    var posGrid = GridFromButton (b);
    var posCell = FromOrdinal (b);
    b.GetComponentInChildren<Text> ().text = c.Current.type;
    b.interactable = false;
    if (c.game.Play (posGrid, posCell)) {
      c.Current.score += 1;
      DestroyImmediate (GetGridTransform (b).gameObject);
      c.game.RemoveGrid (new Vector ());
      gridsBttns.Clear ();
      c.game.AddGrid (new Vector());
    }
  }

  void CreateGrid (Vector pos) {
    var btns = new List<Button>();
    var newGrid = (GameObject) Instantiate (grid, pos.World, Quaternion.identity);
    var bttns = newGrid.GetComponentsInChildren<Button>();

    int i = 0;
    foreach (var b in bttns) {
      var btn = b;
      b.onClick.AddListener(() => Click(btn));
      b.transform.name = "" + i++;
      btns.Add(b);
    }

    gridsBttns.Add (pos, btns);
  }

  void WinCell (Vector grid, Vector cell) {
    var i = ToOrdinal (cell);
    var bttns = gridsBttns[grid];

    foreach (var b in bttns) {
      if (b.transform.name == "" + i) {
        var c = b.colors;
        c.disabledColor = won;
        b.colors = c;
        return;
      }
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

  int ToOrdinal(Vector p){
    if (p.x == 0) {
      if (p.y == 0) {
        return 0;
      } else if (p.y == 1) {
        return 1;
      } else if (p.y == 2) {
        return 2;
      }
    } else if (p.x == 1) {
      if (p.y == 0) {
        return 3;
      } else if (p.y == 1) {
        return 4;
      } else if (p.y == 2) {
        return 5;
      }
    } else if (p.x == 2) {
      if (p.y == 0) {
        return 6;
      } else if (p.y == 1) {
        return 7;
      } else if (p.y == 2) {
        return 8;
      }
    }
    return 0;
  }
}
