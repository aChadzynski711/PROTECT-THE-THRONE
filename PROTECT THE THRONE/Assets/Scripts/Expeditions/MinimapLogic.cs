using System.Collections.Generic;
using UnityEditor.U2D.Aseprite;
using UnityEngine;

public class MinimapLogic : MonoBehaviour
{
	// References
	[SerializeField] private ExpeditionTileMapGenerator expeditionTileMapGenerator;
	[SerializeField] private GameObject mapBKGPrefab;

	/*


		//----------------------------------------------------------------------------------------------------------------------------//
		// General


		// Start
		private void Start()
		{
			InitMap();
		}



		//----------------------------------------------------------------------------------------------------------------------------//


		// Initializes the List of all tiles for this script to access
		private void InitMap()
		{
			foreach (Tile tile in expeditionTileMapGenerator.GetTiles())
			{
				tilesForMap.Add(tile);
			}
		} */

	// Theres a big issue here when the map gets updated
	// Runs everything needed to open the map
	public void OpenMap()
	{
		GameObject mapBKG = Instantiate(mapBKGPrefab);

		// Goes through every tile in the map
		/* foreach (Tile tile in tilesForMap)
		{

		}
		 */// Populate the the BKG with the tiles
	}


	//



}
