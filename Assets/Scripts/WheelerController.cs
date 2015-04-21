using UnityEngine;
using System.Collections;

public class WheelerController : MonoBehaviour {

	public float drive;
	public float torque;
	public float speed_limit = 500f;
	GravityHandler gravity;
	Rigidbody2D body;

	// Use this for initialization
	void Start () {
		gravity = GetComponent<GravityHandler> ();
		body = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		drive = Input.GetAxis("Horizontal");
		torque = body.angularVelocity;
//		if ((torque > -speed_limit && drive > 0f) || (torque < speed_limit && drive < 0f)) {
//			rigidbody2D.AddTorque(drive * -500f);
//		}
		body.AddTorque(drive * acceleration());
	}

	float acceleration() {
		return 10f * direction();
	}

	int direction() {
		if (gravity.direction == Vector3.down) {
			return -1;
		} else {
			return 1;
		}
	}
}
