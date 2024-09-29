using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


[System.Serializable]
public class Chain : MonoBehaviour
{

    // External references
    private CurrencyManager currencyManager;


    // Unlock / Upgrade values
    [SerializeField] private int unlockCost;
    public int chainLevel { get; private set; }
    private int baseUpgradeCost;
    [SerializeField] private int currentUpgradeCost;
    public bool unlocked;


    // External to be set //

    // Demon
    public Demon assignedDemon;

    // Sprites
    public Image chainImage;    // Fix later


    //----------------------------------------------------------------------------------------------------------------------------//


    // Start
    private void Start()
    {
        currencyManager = CurrencyManager.Instance;
        chainLevel = 1;

        if (this.unlocked)
        {

        }
    }



    //----------------------------------------------------------------------------------------------------------------------------//



    // Function for unlock button
    public void UnlockChain()
    {
        if (currencyManager.ReduceResource(CurrencyManager.ResourceType.gold, unlockCost))
        {
            ChainManager.Instance.UnlockChain(this);
        }
    }


    // Function for upgrade button
    public void UpgradeChain()
    {
        // Checks if the player has enough gold
        if (currencyManager.ReduceResource(CurrencyManager.ResourceType.gold, currentUpgradeCost))
        {
            // Add logic here to multiply next cost
        }
        else
        {
            return;
        }

        // Check to see if room has reached max level
        if (chainLevel >= 5)
        {
            Debug.Log("Room has reached maximum level");
            // Later on use a message system to send out a delegate
        }
        else
        {
            Debug.Log("Upgrading to: " + (chainLevel + 1));
            chainLevel++;
        }
    }
}
