using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MySceneManager : MonoBehaviour
{
	// Singleton
	private static MySceneManager _instance;
	public static MySceneManager Instance { get { return _instance; } }


	//----------------------------------------------------------------------------------------------------------------------------//


	// General 
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

		Screen.orientation = ScreenOrientation.LandscapeLeft;

	}



	//----------------------------------------------------------------------------------------------------------------------------//
	// Scene Loading


	public void LoadScene(int sceneNumber, bool isPortrait)
	{

		// Will set the screen to either portrait or 
		if (isPortrait)
		{
			Screen.orientation = ScreenOrientation.Portrait;
		}
		else
		{
			Screen.orientation = ScreenOrientation.LandscapeLeft;
		}

		// Loads scene based on index
		switch (sceneNumber)
		{
			// Base Screen
			case 0:
				SceneManager.LoadSceneAsync(sceneNumber, LoadSceneMode.Single);
				break;
			// Expedition Screen
			case 1:
				SceneManager.LoadSceneAsync(sceneNumber, LoadSceneMode.Single);
				break;

		}


	}



}
