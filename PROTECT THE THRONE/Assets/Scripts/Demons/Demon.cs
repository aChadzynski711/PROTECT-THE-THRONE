using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
[CreateAssetMenu(fileName = "Demon", menuName = "New Demon")]
public class Demon : ScriptableObject
{

    [Header("General Attributes")]
    public string demonName;
    public string description;
    public DemonTypeBase demonType;
    public List<CurrencyManager.ResourceType> requiredResourcesForSummon = new List<CurrencyManager.ResourceType>();

    [Header("Visuals")]
    public Sprite sprite;

    [Header("Misc")]
    public int goldGenerationPerTick;
    public Chain assignedChain;
    public bool selectedForExpedition = false;



    //----------------------------------------------------------------------------------------------------------------------------//



    // Constructor
    public Demon(string demonName, string description, int goldGenerationPerTick, DemonTypeBase demonType)
    {
        this.demonName = demonName;
        this.description = description;
        this.goldGenerationPerTick = goldGenerationPerTick;
        this.selectedForExpedition = false;
        this.demonType = demonType;
    }

}
