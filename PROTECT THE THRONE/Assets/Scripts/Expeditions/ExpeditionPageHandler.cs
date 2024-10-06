using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ExpeditionPageHandler : MonoBehaviour
{

    private List<Demon> selectedDemonsForExpedition;
    public List<GameObject> selectedDemonsPanels;

    [SerializeField] private TMP_Text selectedDemonText;



    //----------------------------------------------------------------------------------------------------------------------------//
    // Generic


    // Start
    private void Start()
    {
        selectedDemonsForExpedition = new List<Demon>();
        selectedDemonsForExpedition.Capacity = 2;
    }



    //----------------------------------------------------------------------------------------------------------------------------//
    // Expedition Logic


    // Function to be called when player selects demon
    public void SetDemonForExpedition(Demon demon)
    {

        if (demon == null)
        {
            Debug.Log("No demons set");
            return;
        }

        selectedDemonsForExpedition.Add(demon);
        demon.selectedForExpedition = true;

        UIManager.Instance.UpdateText(selectedDemonText, selectedDemonsForExpedition[0].demonName);
        UpdateSelectedView(demon);
    }


    // Function to be called when the player needs to remove a demon
    public void RemoveDemonForExpedition(Demon demon)
    {

    }


    public void UpdateSelectedView(Demon demon)
    {
        selectedDemonsPanels[selectedDemonsForExpedition.Count - 1].gameObject.GetComponent<Image>().color = Color.black;
        //selectedDemonsForExpedition[selectedDemonsForExpedition.Count - 1].name 
    }


    // Sends the selected demon out on an expedetion
    // Later on I could use a parameter here to decide which expedition to undertake
    public void SendOnExpedition()
    {
        // Can't send if there's no selected demons
        if (selectedDemonsForExpedition.Count == 0)
        {
            // Later on create some UI popup here
            Debug.LogWarning("No demons have been selected!");
            UIManager.Instance.DisplayWarningBox("No demons have been selected");

            return;
        }


        // Survival roll
        int baseChance = 80;
        int survivalChance = Random.Range(0, 100);


        if (survivalChance > baseChance)
        {
            // Failed survival check
            Debug.LogWarning(selectedDemonsForExpedition[0].demonName + " has died!");
            DemonManager.Instance.RemoveDemon(selectedDemonsForExpedition[0]);

        }
        else
        {
            // Return with goods
            CurrencyManager.Instance.AddResource(CurrencyManager.ResourceType.rottedBoneShards, 1);

            Debug.Log("Demon succesful on expedition gathering: 1 Rotted Bone Shard");
        }


        foreach (Demon demon in selectedDemonsForExpedition)
        {
            demon.selectedForExpedition = false;
        }


        // Reset values
        selectedDemonsForExpedition.Clear();

    }

}
