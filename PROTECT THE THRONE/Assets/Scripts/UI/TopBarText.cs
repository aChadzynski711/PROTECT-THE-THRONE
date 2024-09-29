using TMPro;
using UnityEngine;

public class TopBarText : MonoBehaviour
{

    public TMP_Text goldText;




    private void Update()
    {
        goldText.text = "Gold: " + CurrencyManager.Instance.GetResourceAmount(CurrencyManager.ResourceType.gold).ToString();
    }


}
