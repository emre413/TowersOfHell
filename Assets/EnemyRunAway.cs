using UnityEngine;
using System.Collections;

public class EnemyRunAway : MonoBehaviour {

	GameManager manager;
	// Use this for initialization
	void Start () {
		GameObject g = GameObject.Find ("CameraMain");
		manager = g.GetComponent<GameManager> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Enemy") {
			other.gameObject.SetActive (false);
			manager.health--;

			if (manager.health == 0) {
				manager.state = GameState.LOST;
				Time.timeScale = 0;
			}
		}
	}
}
