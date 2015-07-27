using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Text.RegularExpressions;

public class LevelCreator : MonoBehaviour {
	public GameObject error;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void create(){
		Match match = Regex.Match (levelName(), @"\A\w+\Z");
		if (match.Success) {
			ApplicationState.editLevel (levelName ());
		} else {
			error.SetActive(true);
		}
	}

    string levelName() {
		return transform.Find("Text").GetComponent<Text>().text;
    }
}
