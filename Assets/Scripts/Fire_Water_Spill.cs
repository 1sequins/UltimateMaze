//this script to be attached to water canon and its particle system to remove fire
//on spilling water to the fires

using UnityEngine;
using System.Collections;

public class Fire_Water_Spill : MonoBehaviour {
	//time required for water canon to extinguish fire block
	public float FireBlock_ThersoldTime=10.0f;
	private float copy1;
	private float copy2;
	private GameObject player=null;
	//time required for water canon to extinguish ordinary fire
	public float Fire_ThersoldTime=5.0f;
	bool flag1=false;
	bool flag2=false;

	void Start(){
		player=GameObject.FindGameObjectWithTag("Player");
		copy1=FireBlock_ThersoldTime;
		copy2=Fire_ThersoldTime;
	}
	void OnParticleCollision(GameObject other) {
		//Debug.Log("Collision");
		//other.gameObject.SetActive(false);
		//to detect the hit of water stream with the FireBlock floor
		if (other.gameObject.CompareTag ("Fire_Block"))
		{
			flag1=true;
			if(FireBlock_ThersoldTime<0.0f)
			{
				other.gameObject.SetActive(false);
				player.GetComponent<score_n_time>().increaseScore(100);
				FireBlock_ThersoldTime=copy1;
				flag1=false;
			}
		}
		else if (other.gameObject.CompareTag ("Fire"))
		{
			flag2=true;
			flag1=false;
			if(Fire_ThersoldTime<0.0f)
			{
				other.gameObject.SetActive(false);
				player.GetComponent<score_n_time>().increaseScore(100);
				Fire_ThersoldTime=copy2;
				flag2=false;
			}
		}
		else{
			flag1=false;
			flag2=false;
		}
	}
	void Update()
	{
		if(flag1)
			FireBlock_ThersoldTime-=Time.deltaTime;
		if(flag2)
			Fire_ThersoldTime-=Time.deltaTime;

	}

}
