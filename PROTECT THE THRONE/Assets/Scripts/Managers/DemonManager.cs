using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DemonManager : MonoBehaviour
{
    // Singleton
    private static DemonManager _instance;
    public static DemonManager Instance { get { return _instance; } }

    // Lists
    public List<Demon> demonsOwned = new List<Demon>();

    // Events
    //public UnityEvent<Demon> removeDemon;

    private ExpeditionPageHandler expeditionPageHandler;


    //----------------------------------------------------------------------------------------------------------------------------//
    // General


    // Awake
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }

        GetExpeditionPageHandler();
    }


    private void GetExpeditionPageHandler()
    {
        expeditionPageHandler = FindObjectOfType<ExpeditionPageHandler>();
    }



    //----------------------------------------------------------------------------------------------------------------------------//
    // Demon Management


    // Function call to add a demon after its summoning
    public void AddDemon(Demon demonToAdd)
    {
        demonsOwned.Add(demonToAdd);
    }



    //----------------------------------------------------------------------------------------------------------------------------//
    // Demon Selection


    // FIRST function call for the button to use when it is pressed
    public void OnSelectDemonButtonPressed()
    {
        // THIS is the ACTION that is being passed in to all the other functions that will be invoked once it reaches the correct state
        UIManager.Instance.ShowPlayerSelectDemon(OnDemonSelected);
    }


    // This is what will be invoked once a player selects the demon
    private void OnDemonSelected(Demon selectedDemon)
    {
        expeditionPageHandler.SetDemonForExpedition(selectedDemon);
        Debug.Log(selectedDemon.demonName + " has been chosen for the expedition");
    }


    // Gold Generation


    // Generate gold based on unlocked demons
    public void GenerateGold()
    {
        foreach (Demon demon in demonsOwned)
        {
            // Adds gold based on the demons base gold generation tick as well as the chain level
            CurrencyManager.Instance.AddResource(CurrencyManager.ResourceType.gold, demon.goldGenerationPerTick * demon.assignedChain.chainLevel);
        }
    }


    // Removal of demon
    public void RemoveDemon(Demon demonToRemove)
    {
        /*
            This sends out an event to:
            ChainManager.RemoveDemon
            ChainImageHandler.UpdateCurrentSprite
        */
        ChainManager.Instance.UpdateChainImage(demonToRemove.assignedChain, ChainSprite.Available);
        ChainManager.Instance.RemoveDemonFromChain(demonToRemove);


        // Call this at the end so that all the other functions can safely have a reference (just to make sure)
        demonsOwned.Remove(demonToRemove);
    }

}
