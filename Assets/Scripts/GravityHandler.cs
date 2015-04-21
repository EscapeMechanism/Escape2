using UnityEngine;
using System.Collections;

public class GravityHandler : MonoBehaviour {

	public Vector3 direction;
	Rigidbody2D body;

	// Use this for initialization
	void Start () {
		direction = Vector3.down;
		body = this.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		body.AddForce (direction * 10);
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.GetComponent<GravitySwitch>()) {
			direction = direction * -1;
		}
	}
}
