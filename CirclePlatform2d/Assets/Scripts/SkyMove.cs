using UnityEngine;
using System.Collections;

public class SkyMove : MonoBehaviour {
	
	private Vector3 startPos;
	public float size=5;
	public float scrollSpeed;
	private bool isLeft = true;


	// Use this for initialization
	void Start () {
		startPos = transform.position;
	}

	// Update is called once per frame
	void Update () {
		if (isLeft) {
			
			float newPos = Mathf.Repeat (Time.time * scrollSpeed, size);
			transform.position = startPos + Vector3.left * newPos;
			//isLeft = false;


		} else {
			float newPos = Mathf.Repeat (Time.time * scrollSpeed, size);
			transform.position = startPos + Vector3.right * newPos;
			//if(transform.position
			//isLeft = true;

		}

	}
}
