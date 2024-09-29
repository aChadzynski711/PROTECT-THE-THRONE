using System;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    public static UIManager _instance;
    public static UIManager Instance { get { return _instance; } }

    public Transform canvasTransform;

    public GameObject demonSelectPopUpPrefab;

    private UIWarning uIWarning;



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

        uIWarning = GetComponent<UIWarning>();
    }



    //----------------------------------------------------------------------------------------------------------------------------//
    // Demon Select


    // Shows the select window and begins the process to display demons
    public void ShowPlayerSelectDemon(Action<Demon> onDemonSelected)
    {
        // Instantiate the panel for the player
        var demonSelectPopUp = Instantiate(demonSelectPopUpPrefab, canvasTransform);

        // Begin the process of setup and populate for the list
        var demonSelectScript = demonSelectPopUp.GetComponent<DemonSelectWindow>();
        demonSelectScript.Setup(onDemonSelected);
    }


    // Displays warning message box
    public void DisplayWarningBox(string message)
    {
        uIWarning.DisplayWarning(message);
    }


    // Updates text
    public void UpdateText(TMP_Text text, string newText)
    {
        Debug.Log(newText);
        text.text = newText;
    }



}
