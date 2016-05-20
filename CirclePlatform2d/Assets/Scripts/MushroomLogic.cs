using UnityEngine;
using System.Collections;

public class MushroomLogic : MonoBehaviour {
	private float timeEnd=0;
	private bool isAffected = false;
	public float duration = 5f;
	private bool didOnce= false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (isAffected) {
			if (!didOnce) {
				timeEnd = Time.time + duration;
				didOnce = true;
			}


			if (Time.time <= timeEnd) {
				Debug.Log ("Woahhhh");
				//do graphical animation

			}
			if (Time.time >= timeEnd) {
				isAffected = false;
				Destroy (gameObject);
			}

		}


	}
	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "Player") {
			
			isAffected=true;
		}
	}

}
