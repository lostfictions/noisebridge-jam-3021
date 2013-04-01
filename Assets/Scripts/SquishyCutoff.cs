using UnityEngine;
using System;
using System.Collections.Generic;
using Debug = UnityEngine.Debug;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

public class SquishyCutoff : MonoBehaviour
{
	
	public float xamp = 0.03f;
	public float xper = 0.4f;
	public float xoffset = 0f;
	
	
	private Material _mat; 

	void Start()
	{
		xoffset = Random.Range(0, 1f);
		_mat = renderer.material;
	}

	void Update()
	{
		_mat.SetFloat("_Cutoff", 0.5f + Mathf.Sin(xoffset + Time.time * xper) * xamp);
	}
}
