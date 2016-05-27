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
	public AudioClip[] successClips;

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
		
		if (col.gameObject.tag == "Ground" || (col.gameObject.tag=="Wall"&&col.gameObject.GetComponent<BoxCollider2D>().IsTouching(gameObject.GetComponent<CircleCollider2D>()))) {
			isJumping = false;
			Debug.Log (rb.velocity.y);
			if (Mathf.Abs (rb.velocity.y) > 5) {
				Debug.Log ("Ouch!");
				audio.PlayOneShot (hurtClips [Random.Range (0, hurtClips.Length - 1)]);
			}

		} else if (col.gameObject.tag == "Wall") {
			if (!col.gameObject.GetComponent<BoxCollider2D> ().IsTouching (GetComponent<CircleCollider2D> ())) {
				Debug.Log ("Ouch!");
				audio.PlayOneShot (angerClips [Random.Range (0, hurtClips.Length - 1)]);
			}

		}else if (col.gameObject.tag == "EnemyBird") {
			if (gameObject.GetComponent<CircleCollider2D> ().IsTouching (col.gameObject.GetComponent<EdgeCollider2D> ())) {//is player touching the sides of bird
				audio.PlayOneShot (hurtClips [Random.Range (0, hurtClips.Length - 1)]);
				//DIE? LOSE A HEART?
			} else {
				isJumping = false;
				Debug.Log ("GOTEEEM");
				audio.PlayOneShot (successClips [Random.Range (0, successClips.Length - 1)]);
			}
		}else if (col.gameObject.tag == "Finish") {
			
			Debug.Log ("Game Complete");
			audio.PlayOneShot (successClips [Random.Range (0, successClips.Length - 1)]);
		}
	}
}
