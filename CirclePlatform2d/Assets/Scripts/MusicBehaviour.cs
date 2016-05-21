using UnityEngine;
using System.Collections;

public class MusicBehaviour : MonoBehaviour {
	private AudioSource audio;
	public AudioClip clip;
	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource> ();
		audio.PlayOneShot (clip);
		audio.loop = true;

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
