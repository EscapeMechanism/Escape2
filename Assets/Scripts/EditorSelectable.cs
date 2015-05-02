using UnityEngine;
using System.Collections;

public class EditorSelectable : MonoBehaviour {
	public bool selected;
	public Vector3 dragStart;

	public void select(){
		selected = true;
		dragStart = transform.position;
	}

	public void deselect() {
		selected = false;
	}

	public void drag(Vector3 delta) {
		dragStart += delta;
		transform.position = new Vector3(Mathf.Round(dragStart.x), Mathf.Round(dragStart.y), 0);
	}
}
