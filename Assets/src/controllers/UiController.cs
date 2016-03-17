using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class UiController : MonoBehaviour {
  public GameController c;
  public Text player;

  void Start () {
    Click ();
    c.game.PlayerSwitch += Click;
  }

  public void Click() {
    player.text = "Current Player: '" + c.Current.type + "' Score: " + c.Current.score;
  }
}
