using TMPro;
using UnityEngine;

public class UIText : MonoBehaviour
{

	// Private assignment
	[SerializeField] private TMP_Text selectedDemonTextRef;


	// Static References
	public static TMP_Text selectedDemonText;



	//----------------------------------------------------------------------------------------------------------------------------//
	// General


	// Awake
	private void Awake()
	{
		selectedDemonText = selectedDemonTextRef;
	}



	//----------------------------------------------------------------------------------------------------------------------------//
	// Text Manipulator


	// Updates text
	public static void UpdateText(TMP_Text textRef, string newText)
	{
		textRef.text = newText;
	}


}
