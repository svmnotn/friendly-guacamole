public struct Cell {
	public static Cell def = new Cell(null);
	
	public bool won;
	public bool played;
	public Player player;

  public Cell(Player player, bool won = false) {
    if (player != null) {
      this.played = true;
    } else {
      this.played = false;
    }
    this.player= player;
    this.won = won;
	}
}
