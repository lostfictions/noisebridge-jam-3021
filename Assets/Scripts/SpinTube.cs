using UnityEngine;
using System;
using System.Collections.Generic;
using Debug = UnityEngine.Debug;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

public class SpinTube : MonoBehaviour
{
	public float spinSpeed = 1f;
	
	void Update()
	{
		Vector3 lea = transform.localEulerAngles;
		lea.z += spinSpeed * Time.deltaTime * Game.instance.speedratio;
		transform.localEulerAngles = lea;
	}
}
