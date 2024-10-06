using UnityEngine;


[System.Serializable]
[CreateAssetMenu(fileName = "NewEnemy", menuName = "New Expedition Enemy")]
public class ExpeditionEnemy : ScriptableObject
{
	//
	public string enemyName;
	public int health;


	//----------------------------------------------------------------------------------------------------------------------------//


	public ExpeditionEnemy(string enemyName, int health)
	{
		this.enemyName = enemyName;
		this.health = health;
	}




}
