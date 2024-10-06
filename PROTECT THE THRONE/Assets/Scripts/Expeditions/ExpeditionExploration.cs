using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpeditionExploration : MonoBehaviour
{
	//
	private ExpeditionTileMapGenerator expeditionTileMapGenerator;
	private Tuple<int, int> currentTilePosition;

	[SerializeField] private List<ExpeditionEnemy> currentTileEnemies;



	//----------------------------------------------------------------------------------------------------------------------------//
	// General


	private void Start()
	{
		expeditionTileMapGenerator = GetComponent<ExpeditionTileMapGenerator>();

		currentTilePosition = new Tuple<int, int>(0, 0);
		LoadTileScene();
	}



	//----------------------------------------------------------------------------------------------------------------------------//
	// FIRST THINK ABOUT EMPTY TILES ONLY
	private void LoadTileScene()
	{

		Tile tileToLoad = expeditionTileMapGenerator.tiles[currentTilePosition];

		LoadTileContent(tileToLoad);
	}



	private void LoadTileContent(Tile tileToLoad)
	{

		switch (tileToLoad.type)
		{
			// This is not taking to account that tiles can have previously been explored. I think honestly
			// I need to just make a tiletype called Explored and then just treat it like an empty
			case TileType.Empty:
				// Just load the scene
				Debug.Log("Loading Empty Tile...");
				break;

			case TileType.EnemyPopulated:
				// Load combat
				Debug.Log("Loading Enemy Tile...");
				LoadEnemiesIntoTile();
				break;

			case TileType.Explored:
				Debug.Log("Loading Explored Tile...");
				break;

			default:
				Debug.Log("Not yet implemented");
				break;
		}
	}


	private void LoadEnemiesIntoTile()
	{
		currentTileEnemies = new List<ExpeditionEnemy>();

		foreach (ExpeditionEnemy enemy in expeditionTileMapGenerator.tiles[currentTilePosition].content.enemies)
		{
			currentTileEnemies.Add(enemy);
		}

		// Update their Images and such

		// TODO: I need to essentially begin a battle coroutine here within the ExpeditionBattle Script

	}


}
