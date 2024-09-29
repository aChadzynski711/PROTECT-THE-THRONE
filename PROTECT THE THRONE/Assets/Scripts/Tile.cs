using System;


public class Tile
{
	// 
	public Tuple<int, int> position { get; private set; }
	public TileType type { get; private set; }
	public float difficulty;
	public bool isExplored = false;


	//----------------------------------------------------------------------------------------------------------------------------//
	// Constructor


	public Tile(Tuple<int, int> tilePos, TileType tileType, float tileDifficulty, bool explored)
	{
		position = tilePos;
		type = tileType;
		difficulty = tileDifficulty;
		isExplored = explored;
	}



	// Helper Functions
	public bool ContainsEnemies()
	{
		return type == TileType.EnemyPopulated;
	}


	// Add more later on here




}


public enum TileType
{
	Start,
	Empty,
	EnemyPopulated,
	AvoidableBarricade,
	UnavoidableBarricade,
	Scavengable,
	MinorLoot,
	MajorLoot,
}
