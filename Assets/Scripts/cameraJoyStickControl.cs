using UnityEngine;
using System.Collections;

public class cameraJoyStickControl: MonoBehaviour {
	public float cameraAngle=2.0f;
	public VirtualJoystick joyStick;
	private Vector3 offset;
	private Camera cam;
	void Start ()
	{
		//cam=GetComponent<Camera>();
	}
	
	void LateUpdate ()
	{
		Vector3 dir=Vector3.zero;
		dir.y=joyStick.Horizontal();
		dir.x=-joyStick.Vertical();
		if(dir.magnitude>1)
			dir.Normalize();
		transform.Rotate(dir*cameraAngle*Time.deltaTime);
	}

}