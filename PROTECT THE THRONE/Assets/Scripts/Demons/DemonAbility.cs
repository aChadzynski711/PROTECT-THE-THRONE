using UnityEngine;


[System.Serializable]
[CreateAssetMenu(fileName = "NewDemonAbility", menuName = "New Demon Ability")]
public class DemonAbility : ScriptableObject
{
	//
	public int damage;
	public string abilityName;


	//----------------------------------------------------------------------------------------------------------------------------//


	public DemonAbility(int damage, string abilityName)
	{
		this.damage = damage;
		this.abilityName = abilityName;
	}



}
