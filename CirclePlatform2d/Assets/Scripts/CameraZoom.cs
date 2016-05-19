using UnityEngine;
using System.Collections;

public class CameraZoom : MonoBehaviour
{

	public float zoom = 10f;
	public float normal = 3.471398f;
	public float smooth = 5f;
	private bool isZoomed = false;
	private bool isZoomFinished = true; // the animation zoom is over ?

	public Camera cam;
	public GameObject player;

	public float LockedX = 0f;
	public float LockedY = 0f;
	public float LockedZ = 0f;
	private bool hasBeenZoomed =  false;

	Vector3 targetPos;

	private Transform playerTransform;

	void Start(){
	    targetPos = transform.position;
	    playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
	

	}


	void Update(){
	    if (Input.GetKeyDown("z") && isZoomFinished) { 
	        isZoomed = !isZoomed; 
	        isZoomFinished = false;
	    }

	    if (isZoomed && !isZoomFinished){
	        ZoomInToPlayer();
	    }
	    else if (!isZoomed && !isZoomFinished){
			ZoomOutFromPlayer ();
		} else{
			
		}
	}

	float delta = 0;

	void ZoomInToPlayer()
	{
	    delta += smooth * Time.deltaTime;


	    //Cam size
	    cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, zoom, delta);

	    //Cam pos
	    float targetX = transform.position.x;
	    float targetY = transform.position.y;
	    targetX = Mathf.Lerp(transform.position.x, playerTransform.position.x, delta);
	    targetY = Mathf.Lerp(transform.position.y, playerTransform.position.y, delta);
	    cam.transform.position = new Vector3(targetX, targetY, transform.position.z);



	    // is animation over ?
	    if(delta >= 1) {
	        isZoomFinished = true;
	        delta = 0;
	    }
	}

	void ZoomOutFromPlayer()
	{

		delta += smooth * Time.deltaTime;

		//Cam size
		cam.orthographicSize = Mathf.Lerp (cam.orthographicSize, normal, delta);

		//Cam pos
		float targetX;
		float targetY;
		targetX = Mathf.Lerp (transform.position.x, LockedX, delta);
		targetY = Mathf.Lerp (transform.position.y, LockedY, delta);
		cam.transform.position = new Vector3 (targetX, targetY, transform.position.z);

		// is animation over ?
		if (delta >= 1) {
			isZoomFinished = true;
			delta = 0;
		}
	}

}
