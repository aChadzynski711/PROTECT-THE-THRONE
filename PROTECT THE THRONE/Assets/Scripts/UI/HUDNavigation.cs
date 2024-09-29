using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDNavigation : MonoBehaviour
{

    // References to tab game objects
    [SerializeField] private GameObject summonPageTab;
    [SerializeField] private GameObject chainPageTab;
    [SerializeField] private GameObject expeditionPageTab;


    // References to buttons at the bottom
    [SerializeField] private Button summonPageButton;
    [SerializeField] private Button chainPageButton;
    [SerializeField] private Button expeditionPageButton;


    // Enum for tabs
    public enum Tab
    {
        Summon,
        Chain,
        Expedition,
    }

    // Dictionary for tabs key value pair
    private Dictionary<Tab, GameObject> tabs;


    // Reference to current selected tab
    private Tab currentTab;


    //----------------------------------------------------------------------------------------------------------------------------//


    // Start
    private void Start()
    {
        tabs = new Dictionary<Tab, GameObject>()
        {
            {Tab.Summon, summonPageTab},
            {Tab.Chain, chainPageTab},
            {Tab.Expedition, expeditionPageTab},
        };

        summonPageButton.onClick.AddListener(() => UpdateHUD(Tab.Summon));
        chainPageButton.onClick.AddListener(() => UpdateHUD(Tab.Chain));
        expeditionPageButton.onClick.AddListener(() => UpdateHUD(Tab.Expedition));

        currentTab = Tab.Chain;
        ClearHUD();
        UpdateHUD(currentTab);
    }


    //----------------------------------------------------------------------------------------------------------------------------//


    // Updates the HUD based on the button press
    private void UpdateHUD(Tab newTab)
    {
        tabs[currentTab].SetActive(false);
        tabs[newTab].SetActive(true);

        currentTab = newTab;
    }


    // Clears the HUD of all tabs
    private void ClearHUD()
    {
        tabs[Tab.Summon].SetActive(false);
        tabs[Tab.Chain].SetActive(false);
        tabs[Tab.Expedition].SetActive(false);
    }
}
