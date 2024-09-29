using System;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyManager : MonoBehaviour
{

    // Singleton
    private static CurrencyManager _instance;
    public static CurrencyManager Instance { get { return _instance; } }

    // Resource values
    public enum ResourceType
    {
        gold,
        rottedBoneShards,

    }

    [SerializeField] private Dictionary<ResourceType, int> resources;


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


        resources = new Dictionary<ResourceType, int>
        {
            { ResourceType.gold, 10000 },
            { ResourceType.rottedBoneShards, 0 },
        };
    }



    //----------------------------------------------------------------------------------------------------------------------------//
    // Resource Manipulation



    public bool ReduceResource(ResourceType resourceType, int amount)
    {
        if (resources[resourceType] >= amount)
        {
            resources[resourceType] -= amount;
            return true;
        }
        else
        {
            // Signal a UI function to display text
            Debug.LogWarning("Not enough resources");
            return false;
        }
    }


    public void AddResource(ResourceType resourceType, int amount)
    {
        resources[resourceType] += amount;
    }


    public int GetResourceAmount(ResourceType resourceType)
    {
        return resources[resourceType];
    }



}
