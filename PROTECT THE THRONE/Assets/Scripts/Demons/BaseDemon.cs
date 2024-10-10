using UnityEngine;



[System.Serializable]
[CreateAssetMenu(fileName = "New Base Demon", menuName = "NewBaseDemon")]
public class BaseDemon : Demon
{

	public CurrencyManager.ResourceType gold;
	public int goldNeeded;



}
