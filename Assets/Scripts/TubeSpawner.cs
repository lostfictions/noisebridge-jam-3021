using UnityEngine;
using System.Collections;

public class TubeSpawner : MonoBehaviour {
	public GameObject spawnee;
	
	public bool useAudio = false;
	
	public int spawnAmount = 12; // make it multiple of 3 for best coloring
	public float separation = 10;
	public float speed = 5;
	public float radialscale = 1.0f;
	public float initialOffset = 2;
	
	public float minRotSpeed = 2;
	public float maxRotSpeed = 10;
	
	public float cutoffPosition = -5f;
	
	protected Transform _triParent;
	protected Transform[] _spawns;
	
	void Start ()
	{
		GameObject go;
		go = new GameObject("_triParent");
		_triParent = go.transform;
		_triParent.parent = transform;
		
		
		// spawn
		_spawns = new Transform[spawnAmount];
		for (int i = 0; i < _spawns.Length; i++) {
			_spawns[i] = Spawn(i + initialOffset * (speed > 0 ? 1 : -1));
			SetTubeProperties(_spawns[i]);
		}
		
	}
	
	private Transform Spawn(float i) {
		GameObject go;
		go = GameObject.Instantiate(spawnee, 
			new Vector3(0, 0, cutoffPosition + separation * i),
			Quaternion.identity) as GameObject;
		go.transform.parent = _triParent;
		go.transform.localScale = new Vector3(radialscale, radialscale, go.transform.localScale.z);
		
		return go.transform;
	}
	
	void Update ()
	{
		for (int i = 0; i < _spawns.Length; i++) {
			_spawns[i].Translate(0,0,-Time.deltaTime * speed,Space.World);
			if (speed > 0 && _spawns[i].position.z <= cutoffPosition) {
				_spawns[i].Translate(0,0,separation * _spawns.Length,Space.World);
				SetTubeProperties(_spawns[i]);
			} else if (speed < 0 && _spawns[i].position.z >= cutoffPosition + separation * spawnAmount) {
				_spawns[i].Translate(0,0,-separation * _spawns.Length,Space.World);
				SetTubeProperties(_spawns[i]);
			}
		}
	}
	
	void SetTubeProperties(Transform tube) {
		tube.GetComponent<RandomTexture>().SetTexture();
		tube.GetComponent<RandomColor>().SetColor();
		tube.GetComponent<SpinTube>().spinSpeed = Random.Range(minRotSpeed, maxRotSpeed) * (Random.value > 0.5f ? 1 : -1);
	}
}
