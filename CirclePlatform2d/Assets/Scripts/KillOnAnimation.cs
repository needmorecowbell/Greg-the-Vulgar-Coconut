using UnityEngine;
using System.Collections;

public class KillOnAnimation : MonoBehaviour {

	public float delay = .25f;

	// Use this for initialization
	void Start () {
		Destroy (gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + delay); 
	}
}
