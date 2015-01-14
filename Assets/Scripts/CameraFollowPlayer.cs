using UnityEngine;
using System.Collections;

public class CameraFollowPlayer : MonoBehaviour {

	public Transform player;
	public float window_x = 20;
	public float window_y = 20;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (player.position.x > transform.position.x + window_x) { 
			transform.position = new Vector3 (player.position.x - window_x, transform.position.y, transform.position.z); 
		}
		if (player.position.x < transform.position.x - window_x) { 
			transform.position = new Vector3 (player.position.x + window_x, transform.position.y, transform.position.z); 
		}
		if (player.position.y > transform.position.y + window_y) { 
			transform.position = new Vector3 (transform.position.x, player.position.y - window_y, transform.position.z); 
		}
		if (player.position.y < transform.position.y - window_y) { 
			transform.position = new Vector3 (transform.position.x, player.position.y + window_y, transform.position.z); 
		}
	}
}
