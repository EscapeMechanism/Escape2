using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Text.RegularExpressions;

public class LevelSelection : MonoBehaviour {

	public string level_name;
	
	public void setLevelName(string filename) {
		level_name = nameFromFileName(filename);
		setButtonText ();
	}

	string nameFromFileName(string filename) {
		Match match = Regex.Match(filename, @"/(\w+).xml");
		return match.Groups[1].Value;
	}

	void setButtonText(){
		playButton().Find ("Text").GetComponent<Text> ().text = level_name;
	}

	Transform playButton(){
		return transform.Find ("Play");
	}
	
	Transform editButton(){
		return transform.Find ("Edit");
	}
	
	// Use this for initialization
	void Start () {
		rect ().offsetMin = new Vector2 (0f, 0f);
		rect ().offsetMax = new Vector2 (0f, 0f);

		playButton ().GetComponent<Button>().onClick.AddListener(() => play());
		editButton ().GetComponent<Button>().onClick.AddListener(() => edit());
	}

	void play() {
		ApplicationState.playLevel (level_name);
	}
	
	void edit() {
		ApplicationState.editLevel (level_name);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	RectTransform rect(){
		return GetComponent<RectTransform> ();
	}
}
