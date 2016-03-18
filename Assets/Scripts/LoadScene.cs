using UnityEngine;
using System.Collections;

public class LoadScene : MonoBehaviour {

	public void LoadTheScene(int Scene_No)
	{
		Application.LoadLevel(Scene_No);
	}
	public void quitGame()
	{
		Application.Quit();
		Debug.Log("Quit Clicked");
	}

}
