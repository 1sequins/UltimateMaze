using UnityEngine;
using System.Collections;

public class BallMotor : MonoBehaviour {

	public float moveSpeed=5.0f;
	public float drag=0.5f;
	public float terminalRotationSpeed=25.0f;
	public Vector3 moveVector{set;get;}
	public VirtualJoystick joyStick;
	private Rigidbody thisRigidBody;
	// Use this for initialization
	void Start () {
		//thisRigidBody=gameObject.AddComponent<Rigidbody>();
		thisRigidBody=gameObject.GetComponent<Rigidbody>();
		thisRigidBody.maxAngularVelocity=terminalRotationSpeed;
		thisRigidBody.drag=drag;
	
	}
	
	// Update is called once per frame
	void Update () {
		moveVector=PoolInput();
		Move();
	
	}
	public void Move()
	{
		thisRigidBody.AddForce((moveVector*moveSpeed*Time.deltaTime));

	}
	private Vector3 PoolInput(){
		Vector3 dir=Vector3.zero;
		//dir.x=Input.GetAxis("Horizontal");
		//dir.z=Input.GetAxis("Vertical");
	if (Application.platform == RuntimePlatform.Android)
		{	
			dir.x=joyStick.Horizontal();
			dir.z=joyStick.Vertical();
		}
		if (Application.platform == RuntimePlatform.WindowsEditor||Application.platform == RuntimePlatform.WindowsPlayer)
		{	
			dir.x=Input.GetAxis("Horizontal");
			dir.z=Input.GetAxis("Vertical");
		}
	
		if(dir.magnitude>1)
			dir.Normalize();
		return dir;
	}

}
