using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpeditionUI : MonoBehaviour
{
	//
	private ExpeditionBattle expeditionBattle;
	[SerializeField] private List<Button> abilitiesButtons = new List<Button>();

	public Action<DemonAbility> OnAbilitySelected;
	public Action<ExpeditionEnemy> OnEnemySelected;

	private Demon demon;


	//----------------------------------------------------------------------------------------------------------------------------//


	//
	private void Start()
	{
		expeditionBattle = GetComponent<ExpeditionBattle>();

	}


	public void DisplayAbilities(Demon demon)
	{
		for (int i = 0; i < abilitiesButtons.Count; i++)
		{
			int index = i;
			Debug.Log(index);
			abilitiesButtons[index].onClick.RemoveAllListeners();
			abilitiesButtons[index].onClick.AddListener(() => UpdateAbilitySelected(index));
			abilitiesButtons[index].gameObject.SetActive(true);
		}

		// Populate the DisplayAbilities with demons
		this.demon = demon;
	}


	private void UpdateAbilitySelected(int buttonIndex)
	{
		DemonAbility selectedAbility = demon.abilities[buttonIndex];
		OnAbilitySelected?.Invoke(selectedAbility);
	}


	private void ApplyAbilitySelected()
	{



		//OnEnemySelected?.Invoke()
	}




}
