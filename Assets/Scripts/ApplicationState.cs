using UnityEngine;
using System.Collections;

public class ApplicationState : MonoBehaviour {

	public static string currentFilename;
	public static bool editing;

	
	public void backToMain() {
		Application.LoadLevel("Main");
	}

	public void editLevel() {
		ApplicationState.currentFilename = "first";
		Application.LoadLevel("Editor");
	}

	public void playLevel() {
		ApplicationState.currentFilename = "first";
		ApplicationState.editing = false;
		Application.LoadLevel("Play");
	}
}
