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


    // Remove a resource amount by type and amount
    public bool ReduceResource(ResourceType resourceType, int amount)
    {
        if (resources[resourceType] >= amount)
        {
            resources[resourceType] -= amount;
            return true;
        }
        else
        {

            // Malloc simplified for string
            string resourceString = string.Empty;

            // This will just make the returned resource name UX friendly
            switch (resourceType)
            {
                case ResourceType.gold:
                    resourceString = "Gold";
                    break;
                case ResourceType.rottedBoneShards:
                    resourceString = "Rotted Bone Shards";
                    break;
            }

            UIManager.Instance.DisplayWarningBox("Not enough " + resourceString);

            return false;
        }
    }


    // Add a resource amount by type
    public void AddResource(ResourceType resourceType, int amount)
    {
        resources[resourceType] += amount;
    }


    // Pull the current resource amount by type
    public int GetResourceAmount(ResourceType resourceType)
    {
        return resources[resourceType];
    }



}
