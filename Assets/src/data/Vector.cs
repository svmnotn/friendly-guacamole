using UnityEngine;

public struct Vector {
  public int x;
  public int y;

  public Vector(int x, int y) {
    this.x = x;
    this.y = y;
  }

  public Vector3 World {
    get {
      return new Vector3 (x * 3, y * 3, 0);
    }
  }

  public static Vector FromWorld (Vector3 p) {
    return new Vector (((int)p.x / 3), ((int)p.y / 3));
  }
}
