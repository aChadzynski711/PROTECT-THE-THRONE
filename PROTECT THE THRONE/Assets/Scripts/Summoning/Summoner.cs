using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Summoner : MonoBehaviour
{

    // Events
    public UnityEvent<Demon> goldDemonSummonedEvent;    // Later on make it so the event can also pass through a class type of "Trait" which wil affect
                                                        // the demons stats and its performance overall.

    // Lists
    public List<BaseDemon> baseDemons = new List<BaseDemon>();


    //----------------------------------------------------------------------------------------------------------------------------//


    // Function to generate traits for the demon
    // private Trait GenerateDemonTrait()



    private void CopyDemon(Demon originalDemon, Demon targetDemon)
    {
        targetDemon.demonName = originalDemon.name;
        targetDemon.description = originalDemon.description;
        targetDemon.selectedForExpedition = originalDemon.selectedForExpedition;
    }




    // Logic for summoning using gold
    public void GoldSummon()
    {

        int selectDemonRoll = UnityEngine.Random.Range(0, baseDemons.Count);

        // Ordering is important here. first there is a check to see if there are any available chains to attach a demon to
        // if this is false then currency manager will not deduce the players gold even if they have enough as it goes left to right
        if (ChainManager.Instance.availableChains.Count > 0 && CurrencyManager.Instance.ReduceResource(CurrencyManager.ResourceType.gold, 500))
        {

            BaseDemon selectedDemon = baseDemons[selectDemonRoll];
            BaseDemon summonedDemon = ScriptableObject.CreateInstance<BaseDemon>();

            CopyDemon(selectedDemon, summonedDemon);


            /* 
                This sends out an event to:
                DemonManager.AddDemon(summonedDemon)
                ChainManager.AddDemon(summonedDemon)
            */
            goldDemonSummonedEvent.Invoke(summonedDemon);
        }
        else
        {
            UIManager.Instance.DisplayWarningBox("Chains at capacity");
        }
    }


    // Logic for summoning using resources
    public void ResourceSummon()
    {

    }

}
