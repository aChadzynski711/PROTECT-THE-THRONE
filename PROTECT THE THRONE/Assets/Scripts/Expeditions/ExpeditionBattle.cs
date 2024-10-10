using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpeditionBattle : MonoBehaviour
{
	//
	private ExpeditionTileMapGenerator expeditionTileMapGenerator;
	private ExpeditionExploration expeditionExploration;
	private ExpeditionUI expeditionUI;

	[SerializeField] private List<ExpeditionEnemy> currentTileEnemies;
	[SerializeField] private List<GameObject> enemyGameObjects = new List<GameObject>();

	private bool playerTurn = false;
	public Demon currentDemonsTurn = null;
	public DemonAbility abilitySelected = null;


	//----------------------------------------------------------------------------------------------------------------------------//


	// Start
	private void Start()
	{
		expeditionTileMapGenerator = GetComponent<ExpeditionTileMapGenerator>();
		expeditionExploration = GetComponent<ExpeditionExploration>();
		expeditionUI = GetComponent<ExpeditionUI>();

		expeditionUI.OnAbilitySelected += UpdateAbilitySelected;
	}



	//----------------------------------------------------------------------------------------------------------------------------//



	// Initialize the current battle on the tile
	// This should ultimately start the battle as well
	public void LoadEnemiesIntoTile(List<ExpeditionEnemy> enemies)
	{
		currentTileEnemies = new List<ExpeditionEnemy>();

		int enemyTracker = 0;

		// Do a reset function here that disables all gameobjects for any inactive enemies


		foreach (ExpeditionEnemy enemy in enemies)
		{
			currentTileEnemies.Add(enemy);

			PopulateEnemyInfo(enemyGameObjects[enemyTracker], enemy);

			enemyTracker++;
		}

		StartCoroutine(BattleCoroutine());


	}

	// Populate all info of enemies onto tile
	private void PopulateEnemyInfo(GameObject objectToPopulate, ExpeditionEnemy enemy)
	{
		Image enemyImage = objectToPopulate.GetComponent<Image>();

		enemyImage.sprite = enemy.enemySprite;
	}





	public IEnumerator BattleCoroutine()
	{

		playerTurn = !playerTurn;


		if (currentTileEnemies.Count == 0)
		{
			StopAllCoroutines();
			yield break;
		}


		if (playerTurn)
		{
			currentDemonsTurn = expeditionExploration.demonsOnExpedition[0];
			expeditionUI.DisplayAbilities(currentDemonsTurn);
		}

		yield return null;

	}


	// Grabs the updated 
	private void UpdateAbilitySelected(DemonAbility newAbility)
	{
		abilitySelected = newAbility;
		Debug.Log("Selected Move: " + abilitySelected);
	}


	public void PerformAbilitySelected(ExpeditionEnemy enemy)
	{
		if (abilitySelected != null)
		{
			enemy.health -= abilitySelected.damage;
		}
		else
		{
			Debug.Log("No move selected");
		}
	}

}


/* public enum BattlePhase
{
	PlayerTurn,
	EnemyTurn,
	End
} */


