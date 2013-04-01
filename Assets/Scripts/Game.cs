using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {
	
	public Texture2D[] textures;
	
	public static Game instance;
	
	void Awake() {
		if (instance == null) instance = this;
	}
	
	
	public Texture2D getRandomTexture() {
		return textures[Mathf.FloorToInt(Random.value * (textures.Length-1))];
	}
	
	
}
