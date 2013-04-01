using UnityEngine;
using System;
using System.Collections.Generic;
using Debug = UnityEngine.Debug;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Rigidbody))]
public class RollBall : MonoBehaviour
{
	public AnimationCurve accelerationCurve;

	void Start()
	{
		
	}
	
	void FixedUpdate()
	{
		float z = Input.GetAxis("Vertical");
		float x = Input.GetAxis("Horizontal");

		Vector3 force = new Vector3(x, 0, z);

		rigidbody.AddForce(force);
	}
}
