using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameUI : MonoBehaviour {
	public Button edit;
	public float time;
	public RectTransform winner;
	public bool running;

	// Use this for initialization
	void Start () {
		running = true;

		if (!ApplicationState.editing) {
			edit.gameObject.SetActive(false);
		}

		winner.gameObject.SetActive(false);
		time = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (running) {
			time += Time.deltaTime;
		}
	}

	Level level(){
		return GetComponent<LevelLoader> ().level;
	}

	public void win() {
		if (running) {
			running = false;
			winner.transform.Find ("TimeTaken").GetComponent<Text> ().text = string.Format ("Time taken: {0} seconds", time.ToString ("F2"));
			winner.transform.Find ("LastTimeTaken").GetComponent<Text> ().text = string.Format ("Previous time taken: {0} seconds", level ().time_taken.ToString ("F2"));
			winner.gameObject.SetActive (true);
			if (time < level ().time_taken) {
				level ().update (time);
			}
		}
	}
}
