using UnityEngine;
using System.Collections;

public class TextureWarp : MonoBehaviour {
	
	public float warpSpeed = 0.1f;
	
	private Material _m; 
	
	// Use this for initialization
	void Start () {
		_m = renderer.material;
		_m.mainTextureOffset = new Vector2(Random.value,_m.mainTextureOffset.y);
	}
	
	// Update is called once per frame
	void Update () {
		float f = _m.mainTextureOffset.x + Time.deltaTime * warpSpeed * Game.instance.speedratio;
		_m.mainTextureOffset = new Vector2(Mathf.Repeat(f,1),_m.mainTextureOffset.y);
		if ((warpSpeed * Game.instance.speedratio > 0 && f > 1) && (warpSpeed * Game.instance.speedratio < 0 && f < 0)) {
			GetComponent<RandomTexture>().SetTexture();
		}
	}
}
