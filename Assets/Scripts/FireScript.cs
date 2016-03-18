//this script is to be attached to the tank i.e. our player to
//exhaust water canon on pressing Q
//exhaust fire canon on pressing E
//Keep in Mind that Controls to be made user defined in future

using UnityEngine;
using System.Collections;

public class FireScript : MonoBehaviour {
	
	public ParticleEmitter waterCanon1;
	public ParticleEmitter waterCanon2;
	public ParticleSystem fireCanon;
	//public ParticleEmitter FireCanon1;
	//public ParticleEmitter FireCanon2;
	public AudioClip fireClip=null;
	public AudioClip waterClip=null;
	public AudioSource audio1=null;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.Q)||Input.GetKey(KeyCode.RightControl)||Input.GetKey(KeyCode.LeftControl))
		{
			waterCanon1.Emit();
			waterCanon2.Emit();
			if(audio1!=null && waterClip!=null)
			{
				audio1.PlayOneShot(waterClip);
			}
		
		}
		if(Input.GetKey(KeyCode.E) || Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
		{
			fireCanon.Play();
			//FireCanon2.Emit();
			if(audio1!=null && fireClip!=null)
			{
				audio1.PlayOneShot(fireClip);
			}

		}
		if(Input.GetKeyUp(KeyCode.Q))
		{

			waterCanon1.Emit(0);
			waterCanon2.Emit(0);
			audio1.Stop();

		}
		if(Input.GetKeyUp(KeyCode.E))
		{
			fireCanon.Stop();
			//FireCanon2.Emit(0);
			audio1.Stop();
			
		}

	
	}

}
