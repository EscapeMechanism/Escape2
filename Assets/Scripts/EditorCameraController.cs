using UnityEngine;
using System.Collections;

public class EditorCameraController : MonoBehaviour {

	Vector3 lastMousePosition, mousePosition;
	Camera cmra;
	public MeshRenderer rend;
	Material gridMat;
	Vector2 gridOffset;

	// Use this for initialization
	void Start () {
		cmra = GetComponent<Camera>();
		gridMat = rend.material;
		gridOffset = gridMat.mainTextureOffset;
	}
	
	// Update is called once per frame
	void Update () {
		gridMat.SetTextureOffset("_MainTex", gridOffset);
	}

	void OnGUI(){
		lastMousePosition = mousePosition;
		mousePosition = Input.mousePosition;

		if (Input.GetMouseButtonDown (0)) {
			GetComponent<EditorSelection>().mouseDown(world(mousePosition));
		}
		if (Input.GetMouseButtonDown (2)) {
			lastMousePosition = mousePosition;
		}
		if (Input.GetMouseButton (0)) {
			GetComponent<EditorSelection>().drag(world(mousePosition) - world(lastMousePosition));
		}
		if (Input.GetMouseButton (2)) {
			this.transform.position += (mousePosition - lastMousePosition) / 4;
			gridOffset.x = this.transform.position.x % 1f + 0.5f;
			gridOffset.y = this.transform.position.y % 1f + 0.5f;
		}

		cmra.orthographicSize = Mathf.Clamp(cmra.orthographicSize - Input.mouseScrollDelta.y, 1, 30);
	}

	Vector3 world(Vector2 position){
		return cmra.ScreenToWorldPoint (new Vector3(position.x, position.y, -cmra.transform.position.z));
	}
}
