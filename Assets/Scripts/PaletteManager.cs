using UnityEngine;
using System.Collections;

public class PaletteManager : MonoBehaviour {

	public PaletteSelectable defaultBlock;
	public PaletteSelectable selectedBlock;
	public PaletteSelectable trashBlock;
	public PaletteSelectable saveBlock;
	public bool trashActive;
	public LevelLoader level;

	public void Start() {
		selectedBlock = defaultBlock;
		selectedBlock.select ();
		trashActive = true;
		flipTrash ();
	}

	public bool mouseDown(Vector3 position) {
		Collider2D newSelection = Physics2D.OverlapPoint (position);

		if (newSelection) {
			PaletteSelectable selectable = newSelection.GetComponent <PaletteSelectable>();
			if (selectable) {
				if (selectable == trashBlock) {
					flipTrash ();
				} else if (selectable == saveBlock) {
					save ();
				} else {
					selectedBlock.deselect();
					selectedBlock = null;

					selectedBlock = selectable;
					selectedBlock.select();
				}
				return true;
			}
		}

		return false;
	}

	public void positionInCamera(Camera cmra) {
		transform.position = cmra.ScreenToWorldPoint (new Vector3 (80, 80, -cmra.transform.position.z));
		float scale = (float)cmra.orthographicSize / 10;
		transform.localScale = new Vector3 (scale, scale, 1f);
	}
	
	public bool trashing(){ return trashActive; }

	void flipTrash() {
		if (trashActive) {
			trashBlock.deselect ();
		} else {
			trashBlock.select ();
		}

		trashActive = !trashActive;
	}

	void save() {
		level.save ();
	}

}
