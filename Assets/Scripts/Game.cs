using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {
	
	public Texture2D[] textures;
	public Texture2D palette;
	
	public static Game instance;
	
	private Color[] _colors;
	

	public float colorChangeTimer = 4.7f;
	public float colorLerpSpeed = 0.7f;

	Color currentColor;
	float activeColorChangeTimer;

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

		activeColorChangeTimer = colorChangeTimer;

		currentColor = getRandomColor();

		transform.FindChild("camera").camera.backgroundColor = currentColor;
		transform.FindChild("light").light.color = currentColor;
		RenderSettings.fogColor = currentColor;
	}

	void Update()
	{
		activeColorChangeTimer -= Time.deltaTime;
		if(activeColorChangeTimer < 0)
		{
			activeColorChangeTimer = colorChangeTimer;

			Camera cam = transform.FindChild("camera").camera;
			Light lite = transform.FindChild("light").light;

			Color nextColor = getRandomColor();

			Waiters.Interpolate(colorLerpSpeed,
								t => {
										Color c = Color.Lerp(currentColor, nextColor, t);

										cam.backgroundColor = c;
										lite.color = c;
										RenderSettings.fogColor = c;
									 },
								gameObject)
				   .Then( () => currentColor = nextColor);
		}

	}
	
	
	public Texture2D getRandomTexture() {
		return textures[Mathf.FloorToInt(Random.value * (textures.Length-1))];
	}
	
	public Color getRandomColor() {
		return _colors[Mathf.FloorToInt(Random.value * (_colors.Length-1))];
	}
	
}
