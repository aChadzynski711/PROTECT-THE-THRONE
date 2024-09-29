using System.Collections;
using TMPro;
using UnityEngine;

public class UIWarning : MonoBehaviour
{

	// Prefab and References
	[SerializeField] private GameObject warningBoxGameObject;
	[SerializeField] private GameObject parentCanvas;

	private TMP_Text text;



	//----------------------------------------------------------------------------------------------------------------------------//




	// Display Warning Box / Text
	public void DisplayWarning(string warningText)
	{
		StartCoroutine(DisplayCoroutine(warningText));
	}


	// Main Display Ienumerator
	private IEnumerator DisplayCoroutine(string textToPopulate)
	{
		GameObject box = Instantiate(warningBoxGameObject, parentCanvas.transform);
		text = box.GetComponentInChildren<TMP_Text>();
		text.text = textToPopulate;
		yield return new WaitForSeconds(4);
		Destroy(box);
	}




}
