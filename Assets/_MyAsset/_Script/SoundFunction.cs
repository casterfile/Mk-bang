using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundFunction : MonoBehaviour {
	public AudioClip Click,Points,Wrong;
	AudioSource audioSource;

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	public void FuncClick () {
		audioSource.PlayOneShot(Click, 0.7F);
	}

	public void FuncPoints () {
		audioSource.PlayOneShot(Points, 0.7F);
	}
	public void FuncWrong () {
		audioSource.PlayOneShot(Wrong, 0.7F);
	}
}
