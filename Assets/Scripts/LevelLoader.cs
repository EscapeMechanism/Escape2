using UnityEngine;
using System.Collections;

public class LevelLoader : MonoBehaviour {

	public Block[] blocks;

	// Use this for initialization
	void Start () {
		foreach (Block block in blocks) {
			GameObject g = Instantiate(block.prefab);
			g.transform.position = new Vector3(block.x, block.y, 0);
			g.transform.parent = this.transform;
			g.AddComponent<EditorSelectable>();
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

[System.Serializable]
public class Block : System.Object {

	public int x;
	public int y;
	public GameObject prefab;

}