using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {
	
	public Texture2D[] textures;
	public Texture2D palette;
	
	public static Game instance;
	
	private Color[] _colors;
	
	void Awake() {
		if (instance == null) instance = this;
		
		_colors = new Color[palette.width * palette.height];
		int i = 0;
		for (int x = 0; x < palette.width; x++) {
			for (int y = 0; y < palette.height; y++) {
				_colors[i] = palette.GetPixel(x,y);
				i++;
			}
		}
	}
	
	void Start() {
		
		Color c = getRandomColor();
		transform.FindChild("camera").camera.backgroundColor = c;
		transform.FindChild("light").light.color = c;
		RenderSettings.fogColor = c;
	}
	
	
	public Texture2D getRandomTexture() {
		return textures[Mathf.FloorToInt(Random.value * (textures.Length-1))];
	}
	
	public Color getRandomColor() {
		return _colors[Mathf.FloorToInt(Random.value * (_colors.Length-1))];
	}
	
}
