using UnityEngine;
using System.Collections;

public class DecreaseHealth : MonoBehaviour {

	private GameManager gm;

	// Use this for initialization
	void Start () {
		GameObject g = GameObject.Find ("CameraMain");
		gm = g.GetComponent<GameManager> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionStay(Collision col) {
		if (col.collider.gameObject.tag == "Enemy") {
			gm.playerHealth -= 2.0f * Time.deltaTime;

			if (gm.playerHealth <= 0.0f) {
				gm.state = GameState.LOST;
				Time.timeScale = 0;
			}
		}
	}
}
