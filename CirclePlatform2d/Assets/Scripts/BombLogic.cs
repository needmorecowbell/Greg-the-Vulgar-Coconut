using UnityEngine;
using System.Collections;

public class BombLogic : MonoBehaviour {
	private float timeEnd=0;
	private bool isAffected = false;
	public float duration = 5f;
	private bool didOnce= false;//this is bad
	private bool didOnce2 = false; //this is so bad. I should be ashamed of myself
	public AudioClip[] explosionClips;
	private AudioSource audio;
	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource> ();
	}

	// Update is called once per frame
	void Update () {

		if (isAffected) {
			if (!didOnce) {
				timeEnd = Time.time + duration;
				didOnce = true;
			}


			if (Time.time <= timeEnd) {
				Debug.Log (timeEnd-Time.time);
				if ((int)(Time.time*10) % 2==0) { //Tenth of a second
					gameObject.GetComponent<SpriteRenderer> ().color = Color.red;
				} else {
					gameObject.GetComponent<SpriteRenderer> ().color = Color.white;
				}
				//do graphical animation

			}
			if (Time.time >= timeEnd) {
				Debug.Log ("BOOM!");

				if (!didOnce2) {
					audio.PlayOneShot(explosionClips[Random.Range(0,explosionClips.Length-1)]);
					didOnce2 = true;
				}

				if(!audio.isPlaying){
					isAffected = false;
					Destroy (gameObject);
				}

			}

		}


	}
	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "Player") {
			
			isAffected=true;
		}
	}

}


