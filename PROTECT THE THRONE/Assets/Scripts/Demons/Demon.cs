using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class Demon : ScriptableObject
{
    [Header("General Attributes")]
    public string demonName;
    public string description;
    public List<DemonAbility> abilities = new List<DemonAbility>();


    [Header("Visuals")]
    public Sprite sprite;

    [Header("Misc")]
    public Chain assignedChain;
    public bool selectedForExpedition = false;
}






/* 
[System.Serializable]
[CreateAssetMenu(fileName = "New Ashen Demon", menuName = "NewAshenDemon")]
public class AshenDemon : Demon
{

    public List<CurrencyManager.ResourceType> requiredResourcesForSummon = new List<CurrencyManager.ResourceType>();


} */