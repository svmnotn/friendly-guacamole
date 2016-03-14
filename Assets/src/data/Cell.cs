public struct Cell {
	public static Cell def = new Cell();
	
	public bool won;
	public bool played;
	public string type;

	public Cell(string type) {
		this.played = true;
		this.type = type;
	}
}
