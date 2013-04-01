using UnityEngine;
using System;
using System.Collections.Generic;
using Debug = UnityEngine.Debug;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

public class Squishy : MonoBehaviour
{
	public float horizontalSpeed = 0f;

	public float xamp = 0.03f;
	public float xper = 0.4f;
	public float xoffset = 0f;

	public float yamp = 0.0096f;
	public float yper = 0.5f;
	public float yoffset = 0f;

	

	Vector3 localEuler;

	Vector3 initalScale;

	void Start()
	{
		xoffset = Random.Range(0, 1f);
		yoffset = xoffset + 0.5f + Random.Range(-0.2f, 0.2f);

		initalScale = transform.localScale;
	}

	void Update()
	{
		float xscale = initalScale.x + Mathy.Sin(xamp, xper, xoffset);
		float yscale = initalScale.y + Mathy.Sin(yamp, yper, yoffset);
		transform.localScale = new Vector3(xscale, yscale, initalScale.z);

		Vector3 pos = transform.position;
		pos.x += horizontalSpeed * Time.deltaTime;
		transform.position = pos;
	}
}
