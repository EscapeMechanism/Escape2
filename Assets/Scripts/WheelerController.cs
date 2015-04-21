using UnityEngine;
using System.Collections;

public class WheelerController : MonoBehaviour {

	public float drive;
	public float torque;
	public float speed_limit = 500f;
	GravityHandler gravity;

	// Use this for initialization
	void Start () {
		gravity = GetComponent<GravityHandler> () as GravityHandler;
	}
	
	// Update is called once per frame
	void Update () {
		drive = Input.GetAxis("Horizontal");
		torque = GetComponent<Rigidbody2D>().angularVelocity;
//		if ((torque > -speed_limit && drive > 0f) || (torque < speed_limit && drive < 0f)) {
//			rigidbody2D.AddTorque(drive * -500f);
//		}
		GetComponent<Rigidbody2D>().AddTorque(drive * acceleration());
		if (drive == 0f) {
			GetComponent<Rigidbody2D>().AddTorque(torque/-20f);
		}
	}

	float acceleration() {
		return 1000f * direction();
	}

	int direction() {
		if (gravity.direction == Vector3.down) {
			return -1;
		} else {
			return 1;
		}
	}
}
