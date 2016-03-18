using UnityEngine;
using System.Collections;

public class QuitButton : MonoBehaviour {
	public GameObject quitPanel;
	// Use this for initialization
	public void Quit_Clicked()
	{
		quitPanel.SetActive(true);
	}
	public void No_Clicked()
	{
		quitPanel.SetActive(false);
	}
	

}
