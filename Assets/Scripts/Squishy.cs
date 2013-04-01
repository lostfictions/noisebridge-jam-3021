using UnityEngine;
using System;
using System.Collections.Generic;
using Debug = UnityEngine.Debug;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

public class Squishy : MonoBehaviour
{
	public float horizontalSpeed = 0f;
	public float cameraApproachSpeed = 0f;

	public float xamp = 0.03f;
	public float xper = 0.4f;
	public float xoffset = 0f;

	public float yamp = 0.0096f;
	public float yper = 0.5f;
	public float yoffset = 0f;

	public float angleamp = 10f;
	public float angleper = 0.741f;
	public float angleoffset = 0f;

	public AudioClip[] squishySounds;

	float bloopTimer;

	Vector3 initialAngle;
	Vector3 initalScale;

	Transform camtransform;

	void Start()
	{
		horizontalSpeed *= Random.Range(0.97f, 1.12f);

		camtransform = Camera.main.transform;

		bloopTimer = Random.Range(3.4f, 5.6f);

		gameObject.AddComponent<AudioSource>();

		xoffset = Random.Range(0, 1f);
		yoffset = xoffset + 0.5f + Random.Range(-0.2f, 0.2f);
		angleoffset = Random.Range(0, 1f);

		initalScale = transform.localScale;
		initialAngle = transform.localEulerAngles;
	}

	void Update()
	{
		if(transform.position.z < camtransform.position.z)
		{
			Destroy(gameObject);
			return;
		}

		if(bloopTimer < 0)
		{
			bloopTimer = Random.Range(3.4f, 5.6f);
			audio.clip = squishySounds.RandomInRange();
			audio.Play();
		}

		bloopTimer -= Time.deltaTime;

		float xscale = initalScale.x + Mathy.Sin(xamp, xper, xoffset);
		float yscale = initalScale.y + Mathy.Sin(yamp, yper, yoffset);
		transform.localScale = new Vector3(xscale, yscale, initalScale.z);

		float angle = initialAngle.z + Mathy.Sin(angleamp, angleper, angleoffset);
		transform.localEulerAngles = new Vector3(initialAngle.x, initialAngle.y, angle);

		Vector3 pos = transform.position;
		pos += transform.right * horizontalSpeed * Time.deltaTime;
		pos.z -= cameraApproachSpeed * Time.deltaTime;
		transform.position = pos;
	}
}
