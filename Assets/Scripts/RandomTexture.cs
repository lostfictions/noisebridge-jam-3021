using UnityEngine;
using System.Collections;

public class RandomTexture : MonoBehaviour {

	// Use this for initialization
	void Start () {
		SetTexture();
	}
	
	public void SetTexture() {
		renderer.material.mainTexture = Game.instance.getRandomTexture();
	}
	
}
