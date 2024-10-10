using System;
using System.Collections.Generic;
using UnityEngine;

public class ExpeditionTileMapGenerator : MonoBehaviour
{
	// Dictionary to store each and every tile
	public Dictionary<Tuple<int, int>, Tile> tiles;

	[SerializeField] private List<ExpeditionEnemy> temporaryEnemyList = new List<ExpeditionEnemy>();

	private ExpeditionBattle expeditionBattle;

	// Col / Row max values
	private int rows = 4;
	private int columns = 5;


	//----------------------------------------------------------------------------------------------------------------------------//
	// Generic


	// Awake
	private void Awake()
	{
		// This needs to be in awake so that EnemyTile can have a proper reference
		expeditionBattle = GetComponent<ExpeditionBattle>();
	}


	// Start
	private void Start()
	{
		InitializeMap();
	}


	//----------------------------------------------------------------------------------------------------------------------------//
	// Generate Order


	// Initialize 
	public void InitializeMap()
	{
		// Get tiles into memory
		tiles = new Dictionary<Tuple<int, int>, Tile>();


		// I drew this out in a hex style however this in reality is treated like a map of squares
		// For every coloumn in the tiles 
		for (int colIter = 0; colIter < columns; colIter++)
		{
			// For every row in the tiles
			for (int rowIter = 0; rowIter < rows; rowIter++)
			{

				Tile newTile;

				// Makes the bottom far left corner the starting tile
				if (colIter == 0 && rowIter == 0)
				{
					//Tile newTile = new Tile(Tuple.Create(rowIter, colIter), TileType.Start, 1, null);
					newTile = new EnemyTile(Tuple.Create(rowIter, colIter), 1, GenerateEnemies(), expeditionBattle);

					//newTile = new EnemyTile(Tuple.Create(rowIter, colIter), TileType.EnemyPopulated, 1, GenerateEnemies());
					tiles.Add(newTile.position, newTile);
				}
				// Otherwise it will create a new random tile and append it to all tiles
				else
				{
					Tile randomTile = GenerateRandomTile(Tuple.Create(rowIter, colIter));
					tiles.Add(randomTile.position, randomTile);
				}
			}
		}

	}


	// Generate a random tile based on a roll. This will likely be changed
	private Tile GenerateRandomTile(Tuple<int, int> position)
	{

		int tileRoll = UnityEngine.Random.Range(0, 100);

		if (tileRoll <= 20) return new EmptyTile(position, 1);
		if (tileRoll <= 35) return new EnemyTile(position, 1, GenerateEnemies(), expeditionBattle);
		//if (tileRoll <= 50) return (TileType.AvoidableBarricade, null);
		//if (tileRoll <= 60) return (TileType.UnavoidableBarricade, null);
		//if (tileRoll <= 80) return (TileType.Scavengable, null);    // Later this must be different to incorporate loot
		//if (tileRoll <= 95) return (TileType.MinorLoot, null);      // So will this
		//if (tileRoll <= 100) return (TileType.MajorLoot, null);     // And of course, this

		// Just in case something fails
		return new EmptyTile(position, 1);
	}


	// Generate enemy data
	private List<ExpeditionEnemy> GenerateEnemies()
	{
		// Later on there will be some randomness to this
		return new List<ExpeditionEnemy>(temporaryEnemyList);
	}


	// Gets all valid adjacent tiles that can be moved to
	public List<Tile> GetAdjacentTiles(Tuple<int, int> currentTilePos)
	{

		// First goes through each and every possible position around the tile
		List<Tuple<int, int>> adjacentPositions = new List<Tuple<int, int>>()
		{
			new Tuple<int, int>(currentTilePos.Item1, currentTilePos.Item2 + 1),		// Up	 			(x, y + 1)
			new Tuple<int, int>(currentTilePos.Item1 + 1, currentTilePos.Item2 + 1),	// Up and Right 	(x + 1, y + 1)
			new Tuple<int, int>(currentTilePos.Item1 + 1, currentTilePos.Item2),		// Right			(x + 1, y)
			new Tuple<int, int>(currentTilePos.Item1 + 1, currentTilePos.Item2 - 1),	// Down and Right	(x + 1, y - 1)
			new Tuple<int, int>(currentTilePos.Item1, currentTilePos.Item2 - 1),		// Down				(x, y - 1)
			new Tuple<int, int>(currentTilePos.Item1 - 1, currentTilePos.Item2 - 1),	// Down and Left	(x - 1, y - 1)
			new Tuple<int, int>(currentTilePos.Item1 - 1, currentTilePos.Item2),		// Left				(x - 1, y)
			new Tuple<int, int>(currentTilePos.Item1 - 1, currentTilePos.Item2 + 1),	// Up and Left 		(x - 1, y + 1)
		};

		// This is what will be returned once finding all valid tiles
		List<Tile> validAdjacentTiles = new List<Tile>();

		foreach (Tuple<int, int> position in adjacentPositions)
		{
			// If the adjacent tile even exists within the dictionary with the key of position
			if (tiles.ContainsKey(position))
			{
				// Then append it to the valid tiles list
				validAdjacentTiles.Add(tiles[position]);
			}
		}

		return validAdjacentTiles;
	}


	/* 	// Returns a list of just the tiles
		public List<Tile> GetAllTiles()
		{
			List<Tile> tilesToReturn = new List<Tile>(tiles.Values);

			return tilesToReturn;
		} */
}
