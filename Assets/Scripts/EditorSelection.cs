using UnityEngine;
using System.Collections;

public class EditorSelection : MonoBehaviour {
	public int lastCount;
	public EditorSelectable selected;

	// Use this for initialization
	void Start () {
	
	}

	public void mouseDown(Vector3 position) {
		Collider2D newSelection = Physics2D.OverlapPoint(position);
		if (selected) {
			selected.deselect();
			selected = null;
		}
		if (newSelection) {
			EditorSelectable selectable = newSelection.GetComponent <EditorSelectable>();
			if (selectable) {
				selected = selectable;
				selected.select();
			}
		}
	}

	public void drag(Vector3 delta) {
		if (selected){
			selected.drag (delta);
		}
	}

}
