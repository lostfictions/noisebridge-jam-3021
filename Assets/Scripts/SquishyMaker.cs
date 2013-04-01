using UnityEngine;
using System;
using System.Collections.Generic;
using Debug = UnityEngine.Debug;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

public class SquishyMaker : MonoBehaviour
{
	public Squishy squishy;

	public float initialZ = 25f;
	public float initialX = 35f;

	Transform squishyContainer;

	float spawnTimer = 1.2f;

	void Start()
	{
		squishyContainer = new GameObject().transform;
		squishyContainer.gameObject.name = "SquishyContainer";
	}


	void Update()
	{
		spawnTimer -= Time.deltaTime;

		if(spawnTimer < 0)
		{
			spawnTimer = Random.Range(5.9f, 9.43f);

			bool guh = Random.Range(0, 2) == 0;
			Vector3 v = new Vector3(guh ? -initialX : initialX, 0, initialZ);

			Squishy s = (Squishy)Instantiate(squishy, v, Quaternion.identity);
			s.horizontalSpeed = guh ? s.horizontalSpeed : -s.horizontalSpeed;

			s.transform.parent = squishyContainer;
		}
	}
}
