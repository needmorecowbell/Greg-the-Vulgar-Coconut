using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	private Rigidbody2D rb;
	private bool isJumping = false;
	public float speed;
	public float jumpHeight;
	public AudioClip[] hurtClips;
	public AudioClip[] angerClips;
	private AudioSource audio;


	void Start(){
		rb = GetComponent<Rigidbody2D> ();
		audio = GetComponent<AudioSource> ();
	}

	// Update is called once per frame
	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		if (Input.GetKeyDown (KeyCode.Space)) {
			
			if (isJumping==false) {
				rb.AddForce(new Vector2(0,jumpHeight),ForceMode2D.Impulse);
				isJumping = true;
			}

		}

		Vector2 movement = new Vector2 (moveHorizontal,moveVertical);
		rb.AddForce (movement*speed);
	}

	void OnCollisionEnter2D(Collision2D col){
		
		if (col.gameObject.tag == "Ground") {
			isJumping = false;
			if (Mathf.Abs (rb.velocity.y) > 10) {
				audio.PlayOneShot (hurtClips [1]);
			}

		} else if (col.gameObject.tag == "Wall") {
			audio.PlayOneShot (angerClips [0]);
		}
		if (col.gameObject.tag == "Finish") {
			Debug.Log ("Game Complete");

		}
	}
}
