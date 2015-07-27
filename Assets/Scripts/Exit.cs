using UnityEngine;
using System.Collections;

public class Exit : MonoBehaviour {

	public Transform player;
	public GameUI ui;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.transform == player) {
			ui.win();
		}
	}

}
