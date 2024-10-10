using UnityEngine;


[System.Serializable]
[CreateAssetMenu(fileName = "NewEnemy", menuName = "New Expedition Enemy")]
public class ExpeditionEnemy : ScriptableObject
{
	//
	public string enemyName;
	public int health;
	public Sprite enemySprite;


	//----------------------------------------------------------------------------------------------------------------------------//


	public ExpeditionEnemy(string enemyName, int health, Sprite sprite)
	{
		this.enemyName = enemyName;
		this.health = health;
		this.enemySprite = sprite;
	}




}
