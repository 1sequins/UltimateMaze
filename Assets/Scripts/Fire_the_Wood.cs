using UnityEngine;
using System.Collections;

public class Fire_the_Wood : MonoBehaviour {
	private float WoodPile_ThersoldTime=15.0f;
	bool flag=false;
	GameObject otherGameObject;
	//private score_n_time scoreObject;
	public Material dirtMaterial;
	private Vector3 offset;
	private GameObject player=null;
	// Use this for initialization
	void Start () {
		//scoreObject=new score_n_time();
		offset =new Vector3(0.01f,0.005f,0.005f);
		player=GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame

	void OnParticleCollision(GameObject other) {
		if (other.gameObject.CompareTag ("Wood_Pile"))
		{
			if(!other.transform.FindChild("WallOfFire").gameObject.activeSelf)
				other.transform.FindChild("WallOfFire").gameObject.SetActive(true);
			if(!other.transform.FindChild("SmallFires").gameObject.activeSelf)
				other.transform.FindChild("SmallFires").gameObject.SetActive(true);
			flag=true;
			otherGameObject=other.gameObject;
		}

	}
	void Update () {
		if(flag){
			//float temp=6.0f;
			//score_n_time script=player.GetComponent<score_n_time>();

			bool flag1=false;
			WoodPile_ThersoldTime-=Time.deltaTime;
			if(WoodPile_ThersoldTime<12.0f && flag1==false && otherGameObject.activeSelf)
			{
				otherGameObject.GetComponent<MeshRenderer>().material=dirtMaterial;
				flag1=true;

			}
			if(WoodPile_ThersoldTime<10.0f && otherGameObject.activeSelf)
				otherGameObject.transform.localScale=Vector3.Lerp
					(otherGameObject.transform.localScale,offset,Time.deltaTime*0.1f);
				//temp-=1.0f;

			if(WoodPile_ThersoldTime<0.0f)
			{
				Destroy(otherGameObject.gameObject);
				player.GetComponent<score_n_time>().increaseScore(50);
				Debug.Log("Score Increased");
				flag=false;
				WoodPile_ThersoldTime=15.0f;
			}
		}
		
	}
}
