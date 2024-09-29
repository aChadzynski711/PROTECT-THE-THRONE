using System;
using UnityEngine;
using UnityEngine.Rendering;

public class DemonSelectWindow : MonoBehaviour
{

    public Transform contentTransform;
    public GameObject demonPanelPrefab;
    private Action<Demon> onDemonSelected;      // The delegate reference to send to DemonManager



    //----------------------------------------------------------------------------------------------------------------------------//
    // Setup and Population


    // Initializes the action and populates the list needed to display demons
    public void Setup(Action<Demon> onDemonSelected)
    {
        this.onDemonSelected = onDemonSelected; // Storing the callback function
        PopulateDemonList();
    }


    // Populates the list and displays the demons panel by panel
    private void PopulateDemonList()
    {


        foreach (Demon demon in DemonManager.Instance.demonsOwned)
        {

            // If the demon has already been selected then don't populate the list
            // Instead the user will be able to remove them via the panel beneath
            if (demon.selectedForExpedition)
            {
                Debug.Log("Skipped Demon: " + demon.demonName);
                continue;
            }

            Debug.Log("Populating: " + demon.demonName);

            // Instantiate one panel at a time and assign the reference
            var demonPanel = Instantiate(demonPanelPrefab, contentTransform);
            // Populate the panel
            var populator = demonPanel.GetComponent<DemonSelectPopulator>();
            populator.Populate(demon);

            // This attaches a listener to each and every button and if the button were to be pressed
            // then it initiates the SelectDemon function so that DemonManager knows what demon was selected
            populator.selectButton.onClick.AddListener(() => SelectDemon(demon));

        }
    }



    //----------------------------------------------------------------------------------------------------------------------------//
    // Delegate


    // Invoke function when a demon does get selected
    // It is called by a lambda function from the buttons that are instantiated from populating the list
    private void SelectDemon(Demon demon)
    {
        onDemonSelected?.Invoke(demon); // This returns all the way back to DemonManager.OnDemonSelected that takes in the type Demon
        Destroy(gameObject);
    }

}
