using UnityEngine;
using System.Collections;

public class MushroomLogic : MonoBehaviour {
	private float timeEnd=0;
	private bool isAffected = false;
	public float duration = 10f;
	private bool didOnce= false;
	private SpriteRenderer filter;
	private float red, blue, green;
	private int count = 0;
	public float frequency= .3f;
	// Use this for initialization
	void Start () {
		filter =GameObject.FindGameObjectWithTag ("Filter").GetComponent<SpriteRenderer> ();
		Debug.Log (filter.ToString ());

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
				if ((int)(Time.time*100) % 2 == 0) {
					red   = Mathf.Sin(frequency*count + 0) * 127 + 128;
					green = Mathf.Sin(frequency*count + 2) * 127 + 128;
					blue  = Mathf.Sin(frequency*count + 4) * 127 + 128;
					count++;
					if (count >= 32) {
						count = 0;
					}
					filter.color = new Color (red/255,green/255,blue/255, .5f);
				//	Debug.Log (filter.color.ToString ());
				}
					

			}
			if (Time.time >= timeEnd) {
				isAffected = false;
				filter.color=new Color (255, 255, 255, 0);
				count = 0;
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
