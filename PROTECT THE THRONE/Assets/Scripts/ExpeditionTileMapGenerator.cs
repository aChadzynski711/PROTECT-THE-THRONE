using System;
using System.Collections.Generic;
using UnityEngine;

public class ExpeditionTileMapGenerator : MonoBehaviour
{
	// Dictionary to store each and every tile
	private Dictionary<Tuple<int, int>, Tile> tiles;


	// Col / Row max values
	private int rows = 4;
	private int columns = 5;


	//----------------------------------------------------------------------------------------------------------------------------//
	// Generic


	private void Start()
	{
		InitializeMap();
	}



	//----------------------------------------------------------------------------------------------------------------------------//
	// Initializer


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
				// Makes the bottom far left corner the starting tile
				if (colIter == 0 && rowIter == 0)
				{
					Tile newTile = new Tile(Tuple.Create(rowIter, colIter), TileType.Start, 1, true);
					tiles.Add(newTile.position, newTile);
				}
				// Otherwise it will create a new random tile and append it to all tiles
				else
				{
					Tile newTile = new Tile(Tuple.Create(rowIter, colIter), GenerateRandomTileType(), 1, false);
					tiles.Add(newTile.position, newTile);
				}
			}
		}

	}


	// Generate a random tile based on a roll. This will likely be changed
	private TileType GenerateRandomTileType()
	{

		int tileRoll = UnityEngine.Random.Range(0, 100);

		if (tileRoll <= 20) return TileType.Empty;
		if (tileRoll <= 35) return TileType.EnemyPopulated;
		if (tileRoll <= 50) return TileType.AvoidableBarricade;
		if (tileRoll <= 60) return TileType.UnavoidableBarricade;
		if (tileRoll <= 80) return TileType.Scavengable;
		if (tileRoll <= 95) return TileType.MinorLoot;
		if (tileRoll <= 100) return TileType.MajorLoot;

		// Just in case something fails
		return TileType.Empty;
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



}
