using UnityEngine;
using System.Collections;

public class MoveAndDie : MonoBehaviour {
	
	public float speed = 5;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(0,0,-Time.deltaTime * speed,Space.World);
		if (transform.position.z < -5) {
			Destroy(gameObject);
		}
	}
}
