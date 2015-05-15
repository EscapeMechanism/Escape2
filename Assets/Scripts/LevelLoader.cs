using UnityEngine;
using System;
using System.Linq;

public class LevelLoader : MonoBehaviour {

	public string filename;
	public GameObject player;

	// Use this for initialization
	void Start () {
		if (ApplicationState.currentFilename == null) {
			Application.LoadLevel("Main");
		} else {
			filename = ApplicationState.currentFilename;
			load ();
		}
	}

	public void add(GameObject prefab, Vector3 position) {
		GameObject g = Instantiate(prefab);
		g.transform.parent = this.transform;
		g.transform.name = prefab.name;
		g.AddComponent<EditorDraggable>();
		g.GetComponent<EditorDraggable>().position(position);
	}

	public void load() {
		Level level = Level.load(filename);

		if (level != null) {
			foreach (Block block in level.blocks) {
				if (block.prefab == "Player") {
					player.transform.position = block.position();
				} else {
					GameObject prefab = Resources.Load<GameObject> (String.Format ("Blocks/{0}", block.prefab));
					add (prefab, block.position ());
				}
			}
		}
	}

	public void save() {
		Level level = new Level(filename);
		level.blocks = blocksForChildren ().ToArray<Block> ();
		level.save();
	}

	public System.Collections.Generic.IEnumerable<Block> blocksForChildren() {
		foreach (Transform child in transform.GetComponentInChildren<Transform>()) {
			yield return new Block(child.position, child.name);
		}
	
	}
}

