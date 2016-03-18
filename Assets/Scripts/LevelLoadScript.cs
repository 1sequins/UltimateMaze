using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelLoadScript : MonoBehaviour {
	public GameObject LoadingScene;
	public Image LoadingBar;
	int levelidx=0;
	public void LoadLevel(int LevelIndex)
	{
		levelidx=LevelIndex;
		StartCoroutine (LevelCoroutine ());
	}
	IEnumerator LevelCoroutine ()
	{
		LoadingScene.SetActive (true);
		AsyncOperation async = Application.LoadLevelAsync (levelidx);
		yield return null;
		/*while (!async.isDone) {
			LoadingBar.fillAmount = async.progress / 0.9f;
			yield return null;
		}*/
	}
}
