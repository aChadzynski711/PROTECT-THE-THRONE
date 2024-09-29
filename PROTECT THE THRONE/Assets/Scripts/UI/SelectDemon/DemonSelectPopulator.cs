using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class DemonSelectPopulator : MonoBehaviour
{

    [SerializeField] private Transform buttonPosition;
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private GameObject selectDemonButtonPrefab;
    public Button selectButton;



    //----------------------------------------------------------------------------------------------------------------------------//
    // Population


    // Populates the panel with necessary information
    public void Populate(Demon demon)
    {
        Debug.Log("Populated demon: " + demon.demonName);

        // Button 
        var button = Instantiate(selectDemonButtonPrefab, buttonPosition.position, Quaternion.identity, buttonPosition.parent);
        selectButton = button.GetComponent<Button>();   // This is assigned for DemonSelectWindow to be able to add a listener to it

    }

}
