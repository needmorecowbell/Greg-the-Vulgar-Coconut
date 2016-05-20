using UnityEngine;
using System.Collections;

public class MushroomLogic : MonoBehaviour {
	private float timeEnd=0;
	private bool isAffected = false;
	public float duration = 10f;
	private bool didOnce= false;
	private SpriteRenderer filter;
	// Use this for initialization
	void Start () {
		filter =GameObject.FindGameObjectWithTag ("Filter").GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		if (isAffected) {
			if (!didOnce) {
				timeEnd = Time.time + duration;
				didOnce = true;
				gameObject.GetComponent<SpriteRenderer> ().color = new Color (255, 255, 255, 0);//Make invisible
				gameObject.GetComponent<EdgeCollider2D>().enabled=false;
			}


			if (Time.time <= timeEnd) {
				
				filter.color = new Color (Random.Range (0, 255), Random.Range (0, 255), Random.Range (0, 255), .25f);

				//do graphical animation

			}
			if (Time.time >= timeEnd) {
				isAffected = false;
				filter.color=new Color (255, 255, 255, 0);
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
