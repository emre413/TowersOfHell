using UnityEngine;
using System.Collections;

public class KillEnemy : MonoBehaviour {
	public Animator charAnimator;

	// Use this for initialization
	void Start () {
	
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Enemy") {
			if (charAnimator.GetBool("Swing") == true) {
				other.gameObject.SetActive (false);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
