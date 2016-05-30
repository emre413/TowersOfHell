using UnityEngine;
using System.Collections;

public class DecreaseHealth : MonoBehaviour {

	private GameManager gm;
	CameraController cont;
	// Use this for initialization
	void Start () {
		GameObject g = GameObject.Find ("CameraMain");
		gm = g.GetComponent<GameManager> ();

		cont = g.GetComponent<CameraController> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionStay(Collision col) {
		if (col.collider.gameObject.tag == "Enemy") {
			gm.playerHealth -= 2.0f * Time.deltaTime;

			if (gm.playerHealth <= 0.0f) {
				Vector3 pos = gameObject.transform.position;
				pos.z = -17f;
				gameObject.transform.position = pos;
				cont.cam1.enabled = true;
				cont.cam2.enabled = false;
			}
		}
	}
}
