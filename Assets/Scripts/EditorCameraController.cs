using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EditorCameraController : MonoBehaviour {

	Vector3 lastMousePosition, mousePosition;
	Camera cmra;
	public MeshRenderer rend;
	Material gridMat;
	Vector2 gridOffset;
	BlockDragger dragger;
	public PaletteManager palette;
	public LevelLoader level;
	public Text filename;


	public void back() {
		Application.LoadLevel("Main");
	}
	
	public void play() {
		ApplicationState.editing = true;
		Application.LoadLevel("Play");
	}
	
	void Start () {
		cmra = GetComponent<Camera>();
		gridMat = rend.material;
		gridOffset = gridMat.mainTextureOffset;
		dragger = GetComponent<BlockDragger> ();
		filename.text = ApplicationState.currentFilename;
	}
	
	// Update is called once per frame
	void Update () {
		gridMat.SetTextureOffset("_MainTex", gridOffset);

		lastMousePosition = mousePosition;
		mousePosition = Input.mousePosition;

		if (Input.GetKeyDown ("a")) {
			PaletteSelectable button = palette.selectedBlock;
			level.add (button.prefab, world (mousePosition));
		}
		
		if (Input.GetMouseButtonUp (0)) {
			dragger.mouseUp(world(mousePosition));
		}

		if (Input.GetMouseButtonDown (0)) {
			lastMousePosition = mousePosition;
			if (!palette.mouseDown(world(mousePosition))) {
				dragger.mouseDown(world(mousePosition));
			}
		}
		if (Input.GetMouseButton (0)) {
			if (dragger.hasSelection()) {
				dragger.drag(world(mousePosition) - world(lastMousePosition));
			} else {
				this.transform.position += (mousePosition - lastMousePosition) / 10;
				gridOffset.x = this.transform.position.x % 1f + 0.5f;
				gridOffset.y = this.transform.position.y % 1f + 0.5f;
			}
		}

		cmra.orthographicSize = Mathf.Clamp(cmra.orthographicSize - Input.mouseScrollDelta.y, 1, 30);
		positionPalette ();
	}

	void positionPalette() {
		palette.positionInCamera (cmra);
	}

	Vector3 world(Vector2 position){
		return cmra.ScreenToWorldPoint (new Vector3(position.x, position.y, -cmra.transform.position.z));
	}

}