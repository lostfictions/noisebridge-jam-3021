using UnityEngine;
using System.Collections;

public class RandomColor : MonoBehaviour {

	// Use this for initialization
	void Start () {
		renderer.material.color = Game.instance.getRandomColor();
	}
}
