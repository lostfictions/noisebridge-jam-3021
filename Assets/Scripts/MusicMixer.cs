using UnityEngine;
using System;
using System.Collections.Generic;
using Debug = UnityEngine.Debug;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

public class MusicMixer : MonoBehaviour
{
	public AudioClip normal;
	public AudioClip night;
	public AudioClip menace;

	AudioSource activeAudio;

	void Start()
	{
		activeAudio = gameObject.AddComponent<AudioSource>();
		
	}
	
	void Update()
	{
		
	}
}
