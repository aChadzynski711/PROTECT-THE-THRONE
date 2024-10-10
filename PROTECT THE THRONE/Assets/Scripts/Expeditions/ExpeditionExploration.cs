using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ExpeditionExploration : MonoBehaviour
{
	// References
	private ExpeditionTileMapGenerator expeditionTileMapGenerator;

	public Tuple<int, int> currentTilePosition;
	public List<Demon> demonsOnExpedition = new List<Demon>();



	//----------------------------------------------------------------------------------------------------------------------------//
	// General


	private void Start()
	{
		expeditionTileMapGenerator = GetComponent<ExpeditionTileMapGenerator>();


		currentTilePosition = new Tuple<int, int>(0, 0);
		LoadTileScene();
	}



	//----------------------------------------------------------------------------------------------------------------------------//
	// Tiles


	// Tile Generation
	private void LoadTileScene()
	{

		Tile tileToLoad = expeditionTileMapGenerator.tiles[currentTilePosition];

		LoadTileContent(tileToLoad);
	}


	// Loading the content of the current tile the player is in
	private void LoadTileContent(Tile tileToLoad)
	{

		// Later on I can pass in parameters to Interact so that I can reference methods
		tileToLoad.Interact();



	}





}
