using UnityEngine;
using System.Collections;

public class ApplicationState : MonoBehaviour {

	public static string currentFilename;
	public static bool editing;

	
	public void backToMain() {
		Application.LoadLevel("Main");
	}
	
	public void editLevel() {
		Application.LoadLevel("Editor");
	}
	
	public void playLevel() {
		Application.LoadLevel("Play");
	}
	
	public static void editLevel(string filename) {
		ApplicationState.currentFilename = filename;
		Application.LoadLevel("Editor");
	}
	
	public static void playLevel(string filename) {
		ApplicationState.currentFilename = filename;
		ApplicationState.editing = false;
		Application.LoadLevel("Play");
	}
}
