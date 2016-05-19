using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	private Rigidbody2D rb;
	private bool isJumping = false;
	public float speed;
	public float jumpHeight;



	void Start(){
		rb = GetComponent<Rigidbody2D> ();
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
		}
		if (col.gameObject.tag == "Finish") {
			Debug.Log ("Game Complete");

		}
	}
}
