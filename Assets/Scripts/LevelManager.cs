using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;

public class LevelManager : MonoBehaviour {

	public RectTransform level;
	public string[] files;
	public Scrollbar scroller;
	public Text path;


	// Use this for initialization
	void Start () {
		files = System.IO.Directory.GetFiles(Level.save_path());
		populate ();
		scroller.value = 1;
		path.text = Level.save_path ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void populate() {
		for (int i=0; i < files.Length; i++) {
			string name = files[i];
			Transform l = Instantiate (level);
			l.transform.SetParent (transform);
			l.GetComponent<LevelSelection> ().setLevelName (name);
		}
	}
}
