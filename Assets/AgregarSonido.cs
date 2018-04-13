using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgregarSonido : MonoBehaviour {

	public AudioSource audio;
	public AudioClip clip ;

	void Start () 
	{
		audio.clip = clip;
	}
	

	void Reproducir () 
	{
		audio.Play();
	}
}
