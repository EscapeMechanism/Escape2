using UnityEngine;
using System.Collections;

public class TextureScroller : MonoBehaviour {

	Vector2 uvOffset = Vector2.zero;
	Renderer render;
	Material mat;

	void Start () {
		render = GetComponent<Renderer> ();
		mat = Instantiate (render.material);
		mat.CopyPropertiesFromMaterial (render.material);
		render.material = mat;
		Vector2 scale = new Vector2 (transform.localScale.x, transform.localScale.y);
		mat.SetTextureScale ("_MainTex", scale);
	}
	
	void LateUpdate () {
		uvOffset.y = Mathf.Sin (Time.fixedTime * 4) / 5f;

		if( render.enabled ) {
			mat.SetTextureOffset("_MainTex" , uvOffset );
		}
	}
}
