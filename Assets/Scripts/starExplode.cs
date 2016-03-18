using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class starExplode : MonoBehaviour {

	// Use this for initialization
	public GameObject explode;
	public TextMesh point;
	void Start () {
		//point=GetComponent<TextMesh>();
		//point
	}
	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ("Player"))
		{
			//point.enabled=true;
			//for(int i=0;i<=10;i++)
			//	point.fontSize=point.fontSize+i;

		}

	}
}