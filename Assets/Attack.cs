using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour {

	public GameObject arrowPrefab;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		int force = -5000;
		if (Input.GetKey(KeyCode.Mouse0)) {
			Vector3 pos = gameObject.transform.position;
			pos.y += 5;
			pos.x += 5;
			GameObject arrow = Instantiate (arrowPrefab, pos, gameObject.transform.rotation) as GameObject;
			arrow.SetActive (true);
			arrow.transform.Rotate (90, 0, 0);


			Rigidbody rb = new Rigidbody ();
			rb = arrow.GetComponent<Rigidbody>();
			rb.AddForce (force,1000,1000);
		}
	}
}
