using UnityEngine;
using System.Collections;

public class PaletteSelectable : MonoBehaviour {
	public bool selected;
	public GameObject prefab;
	public SpriteRenderer rend;

	void Awake () {
		rend = transform.GetComponent<SpriteRenderer> ();
	}

	public void select(){
		selected = true;
		updateMaterial ();
	}
	
	public void deselect() {
		selected = false;
		updateMaterial ();
	}

	void updateMaterial () {
		if (selected) {
			rend.color = new Color(1f, 1f, 1f, 1f);
		} else {
			rend.color = new Color(1f, 1f, 1f, 0.5f);
		}
	}
}
