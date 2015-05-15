using UnityEngine;
using System.Collections;

public class EditorDraggable : MonoBehaviour {
	public Vector3 dragStart;

	public void start(){
		dragStart = transform.position;
	}

	public void drag(Vector3 delta) {
		dragStart += delta;
		position(new Vector3(Mathf.Round(dragStart.x), Mathf.Round(dragStart.y), 0));
	}

	public void position(Vector3 p) {
		transform.position = new Vector3(Mathf.Round(p.x), Mathf.Round(p.y), 0);	
	}
}
