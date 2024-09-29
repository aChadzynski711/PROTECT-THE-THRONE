using System.Collections.Generic;
using UnityEngine;

public class ChainManager : MonoBehaviour
{

    // Singleton
    private static ChainManager _instance;
    public static ChainManager Instance { get { return _instance; } }


    // Lists
    public List<Chain> lockedChains;
    public List<Chain> availableChains;
    public List<Chain> occupiedChains;


    // Chain Image handler
    private ChainImageHandler chainImageHandler;


    //----------------------------------------------------------------------------------------------------------------------------//


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

    }


    private void Start()
    {
        InitChains();
    }



    //----------------------------------------------------------------------------------------------------------------------------//



    // Init chains
    private void InitChains()
    {
        chainImageHandler = FindObjectOfType<ChainImageHandler>();

        // Load chain Sprite data
        foreach (Chain chain in availableChains)
        {
            chainImageHandler.UpdateCurrentSprite(chain, ChainSprite.Available);
        }
        foreach (Chain chain in occupiedChains)
        {
            chainImageHandler.UpdateCurrentSprite(chain, ChainSprite.Occupied);
        }
    }


    // Function to unlock a chain
    public void UnlockChain(Chain chain)
    {
        availableChains.Add(chain);
        lockedChains.Remove(chain);
        UpdateChainImage(chain, ChainSprite.Available);
    }


    // Function to add a demon to the first available chain
    public void AddDemonToChain(Demon demonToAdd)
    {
        // All of this here is temporary. Later on I would like to implement a way to have the player be able to choose the chain
        // that the demon is assigned to

        // Demon
        demonToAdd.assignedChain = availableChains[0];

        // Chain Logic
        //availableChains[0].chainImage.color = Color.black;
        availableChains[0].assignedDemon = demonToAdd;

        // put the chain image handle thing here
        chainImageHandler.UpdateSpriteWithDemon(availableChains[0]);
        //availableChains[0].chainImage.sprite = demonToAdd.sprite;

        // List Adjustment 
        occupiedChains.Add(availableChains[0]);
        availableChains.Remove(availableChains[0]);


    }


    // Remove a demon from chain
    public void RemoveDemonFromChain(Demon demonToRemove)
    {
        availableChains.Add(demonToRemove.assignedChain);
        occupiedChains.Remove(demonToRemove.assignedChain);
    }


    // Update the Chain Image with a sprite type
    public void UpdateChainImage(Chain chain, ChainSprite sprite)
    {
        chainImageHandler.UpdateCurrentSprite(chain, sprite);
    }




}