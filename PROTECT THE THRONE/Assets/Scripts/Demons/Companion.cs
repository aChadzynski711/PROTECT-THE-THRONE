using System.Collections;
using UnityEngine;

public class Companion : MonoBehaviour
{

    private int goldGenerationPerTick = 1;



    //----------------------------------------------------------------------------------------------------------------------------//
    // General


    // Start
    private void Start()
    {
        StartCoroutine(GoldGeneration());
    }



    //----------------------------------------------------------------------------------------------------------------------------//
    // Gold Generation


    // Main gold loop
    private IEnumerator GoldGeneration()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);

            CurrencyManager.Instance.AddResource(CurrencyManager.ResourceType.gold, goldGenerationPerTick);
        }
    }

}
