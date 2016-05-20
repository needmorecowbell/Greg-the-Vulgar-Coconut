using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class PlayButtonLogic : MonoBehaviour {
	Button btnPlay;

	void Start(){
		btnPlay = GetComponent<Button> ();
		btnPlay.onClick.AddListener (() => changeScene ());

	}

	void changeScene(){
		
		SceneManager.LoadScene ("GregTheVulgarCoconut");
	}
}
