using System;
using System.Collections.Generic;


public class Tile
{
	// 
	public Tuple<int, int> position { get; private set; }
	public TileType type { get; private set; }
	public float difficulty;


	public TileContent content { get; private set; }


	//----------------------------------------------------------------------------------------------------------------------------//
	// Constructor


	public Tile(Tuple<int, int> tilePos, TileType tileType, float tileDifficulty, TileContent tileContent)
	{
		position = tilePos;
		type = tileType;
		difficulty = tileDifficulty;
		content = tileContent;
	}


	// Add more later on here
	public void TileExplored()
	{
		type = TileType.Explored;
	}



}


public class TileContent
{
	public List<ExpeditionEnemy> enemies;
	//Loot

	public TileContent(List<ExpeditionEnemy> enemies = null)
	{
		this.enemies = enemies ?? new List<ExpeditionEnemy>();
	}
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
	Explored,
}
