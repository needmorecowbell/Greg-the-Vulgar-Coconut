using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class PortalBehavior : MonoBehaviour {
	private int scene;
	public bool enabled= false;
	// Use this for initialization
	void Start () {

		scene = SceneManager.GetActiveScene ().buildIndex;

	}

	void sceneStart(){
		SceneManager.LoadScene (0);
	}
	
	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "Player") {
			SceneManager.LoadScene (scene+1);
		}
	}
}
