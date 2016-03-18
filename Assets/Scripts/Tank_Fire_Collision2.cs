//To be attached to fire type particle systems

using UnityEngine;
using System.Collections;


public class Tank_Fire_Collision2 : MonoBehaviour {
	private float ExplosionTime=5.0f;
	private float Explosion_Game_OverTime=6.0f;
	private bool fireHit=false;
	private Transform explosion;
	public GameObject GameOver;
	private GameObject player;
	public Material dirtMaterial;
	// Use this for initialization
	void Start () {
		explosion=GameObject.FindGameObjectWithTag("Player").transform.FindChild("Explosions");
		if(explosion.gameObject.activeSelf)
			explosion.gameObject.SetActive(false);
		
		player=GameObject.FindGameObjectWithTag("Player");
		
	}
	
	// Update is called once per frame
	
	//on Collision of particles with other game object
	void OnParticleCollision(GameObject other) {
		
		if (other.CompareTag ("Fire") || other.CompareTag("Fire_Block")){
			fireHit=true;
			//GameObject.FindGameObjectWithTag("Tank_Explosion").SetActive(true);
			
			
		}
	}
	void Update () {
		if(fireHit)
		{
			//Debug.Log("Fire_Hit");
			ExplosionTime-=Time.deltaTime;
			Explosion_Game_OverTime-=Time.deltaTime;
			if(!explosion.gameObject.activeSelf)
				explosion.gameObject.SetActive(true);
			if(!explosion.FindChild("SmallFires").gameObject.activeSelf)
			{
				explosion.FindChild("SmallFires").gameObject.SetActive(true);
				explosion.FindChild("Flare").gameObject.SetActive(true);
				if(explosion.FindChild("FireMobile")!=null)
					explosion.FindChild("FireMobile").gameObject.SetActive(true);
				
			}
			if(ExplosionTime<3.0f)
			{
				GameOver.SetActive(true);
				if(explosion.FindChild("FireComplex")!=null &&!explosion.FindChild("FireComplex").gameObject.activeSelf)
				{explosion.FindChild("FireComplex").gameObject.SetActive(true);
					//Debug.Log("FireComplex");
				}
			}
			if(ExplosionTime<0.0f)
			{
				if(!explosion.FindChild("Fireball").gameObject.activeSelf)
				{
					explosion.FindChild("Fireball").gameObject.SetActive(true);
					explosion.FindChild("FlameStrike").gameObject.SetActive(true);
					explosion.FindChild("Firebolt").gameObject.SetActive(true);
					//Debug.Log("Fireball");	
				}
			}
			
			if(ExplosionTime<0.0f)
			{

				if(GameObject.FindGameObjectWithTag("Player").activeSelf)
				{
					if(GameObject.FindGameObjectWithTag("Player").transform.FindChild("TankRenderers").gameObject.activeSelf)
						//GameObject.FindGameObjectWithTag("Player").transform.FindChild("TankRenderers").gameObject.SetActive(false);
						if(!explosion.FindChild("fx_fumefx_boom").gameObject.activeSelf)
							explosion.FindChild("fx_fumefx_boom").gameObject.SetActive(true);
					GameObject.FindGameObjectWithTag("Player").
						GetComponent<TankMovement>().enabled=false;
					Transform temp=player.transform.FindChild("TankRenderers");//GetComponent<MeshRenderer>().material=dirtMaterial;
					foreach(Transform child in temp)
					{
						child.gameObject.GetComponent<MeshRenderer>().material=dirtMaterial;
					}
					//Debug.Log("TankRenderers");
				}
				//gameOver
			}
			if(Explosion_Game_OverTime<0.0f)
			{
				//if(GameObject.FindGameObjectWithTag("Player").activeSelf)
				//{
				if(explosion.FindChild("fx_fumefx_boom").gameObject.activeSelf)
					explosion.FindChild("fx_fumefx_boom").gameObject.SetActive(false);
				if(explosion.gameObject.activeSelf)
					explosion.gameObject.SetActive(false);
				
				
				//}
				//gameOver
				player.GetComponent<score_n_time>().loss=true;
				GameOver.SetActive(true);
				Debug.Log("Game Over");
			}
			
		}
	}
}

