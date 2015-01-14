using UnityEngine;
using System.Collections;

public class GravityHandler : MonoBehaviour {

	public Vector3 direction;

	// Use this for initialization
	void Start () {
		direction = Vector3.down;
	}
	
	// Update is called once per frame
	void Update () {
		this.rigidbody2D.AddForce (direction * 10);
	}

	void OnTriggerEnter2D(Collider2D other) {
		direction = direction * -1;
	}
}
