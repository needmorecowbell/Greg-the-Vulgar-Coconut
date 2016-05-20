using UnityEngine;
using System.Collections;

public class BirdMovement : MonoBehaviour {
	public float upForce;			//upward force of the "flap"
	public float forwardSpeed;		//forward movement speed
	public float delay= 2f;
	public bool isDead = false;		//has the player collided with a wall?
	public bool isLeft= false;
	Animator anim;					//reference to the animator component
	bool flap = false;				//has the player triggered a "flap"?
	private AudioSource audio;
	public AudioClip hurt;
	void Start()
	{
		//get reference to the animator component
		anim = GetComponent<Animator> ();
		//set the bird moving forward
		GetComponent<Rigidbody2D>().velocity = new Vector2 (forwardSpeed, 0);
		audio = GetComponent<AudioSource> ();
	}

	void Update()
	{
		//don't allow control if the bird has died
		if (isDead)
			return;
		//look for input to trigger a "flap"
		flap = true;
	}

	void FixedUpdate()
	{
		//if a "flap" is triggered...
		if (flap) 
		{
			flap = false;

			//...tell the animator about it and then...
			anim.SetTrigger("Flap");
			//...zero out the birds current y velocity before...
			if (isLeft) {
				GetComponent<Rigidbody2D> ().velocity = new Vector2 (-(GetComponent<Rigidbody2D> ().velocity.x), 0);//TODO FIX RIGHT MOVEMENT
			} else {
				GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, 0);
			}

			//..giving the bird some upward force
			GetComponent<Rigidbody2D>().AddForce(new Vector2(0, upForce));
		}
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		
		if (other.gameObject.tag == "Ground") {
			isLeft = !isLeft;
		}
		//...tell the animator about it...
		if(other.gameObject.tag == "Player"){

			if (gameObject.GetComponent<BoxCollider2D>().IsTouching(other.gameObject.GetComponent<CircleCollider2D>())){ //is player hitting top of bird
				//audio.PlayOneShot (hurt);
				anim.SetTrigger ("Die");
				//...and tell the game control about it
				Destroy (gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(1).length + delay); 
				GameControlScript.current.BirdDied ();
			}



		}

	}
}
