using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameUI : MonoBehaviour {
	public Button edit;

	// Use this for initialization
	void Start () {
		if (!ApplicationState.editing) {
			edit.gameObject.SetActive(false);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
