using System;
using System.Collections.Generic;
using UnityEngine;


public abstract class Tile
{
	// 
	public Tuple<int, int> position { get; private set; }
	public float difficulty;


	//----------------------------------------------------------------------------------------------------------------------------//
	// Constructor


	public Tile(Tuple<int, int> tilePos, float tileDifficulty)
	{
		position = tilePos;
		difficulty = tileDifficulty;
	}

	public abstract void Interact();
}


// Empty Tiles
public class EmptyTile : Tile
{

	public EmptyTile(Tuple<int, int> position, float difficulty) : base(position, difficulty) { }


	public override void Interact()
	{
		Debug.Log("Empty Tile Override");
		throw new NotImplementedException();
	}

}


// Enemy Populated Tiles
public class EnemyTile : Tile
{
	public List<ExpeditionEnemy> enemies;
	public ExpeditionBattle expeditionBattle;
	// Loot


	public EnemyTile(Tuple<int, int> position, float difficulty, List<ExpeditionEnemy> enemies, ExpeditionBattle expeditionBattle) : base(position, difficulty)
	{
		this.enemies = enemies;
		this.expeditionBattle = expeditionBattle;
	}

	public override void Interact()
	{
		Debug.Log("Enemy Tile Override");
		BeginBattle();
	}

	public void BeginBattle()
	{
		Debug.Log("Battle begins!");

		if (expeditionBattle == null)
		{
			Debug.LogError("No expeditionBattle Reference");
		}
		else
		{
			expeditionBattle.LoadEnemiesIntoTile(enemies);
		}
	}
}





