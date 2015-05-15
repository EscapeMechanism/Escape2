using UnityEngine;
using System.Collections;

public class BlockDragger : MonoBehaviour {
	public EditorDraggable dragging;
	public PaletteManager palette;
	public GameObject player;

	public void mouseDown(Vector3 position) {
		Collider2D newSelection = Physics2D.OverlapPoint(position);
		if (newSelection) {
			if (trashActive() && trashable(newSelection.gameObject)) {
				DestroyObject(newSelection.gameObject);
			} else {
				dragging = newSelection.GetComponent<EditorDraggable> ();
				if (dragging) {
					dragging.start ();
		
				}
			}
		}
	}
	
	public void mouseUp(Vector3 position) {
		dragging = null;
	}
	
	public void drag(Vector3 delta) {
		if (dragging){
			dragging.drag (delta);
		}
	}

	public bool hasSelection(){
		return dragging != null;
	}

	bool trashActive() {
		return palette.trashing();
	}

	bool trashable(GameObject obj){

		return (obj != player);
	}
}

