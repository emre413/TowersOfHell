using UnityEngine;
using System.Collections;

public class TowerAttackScript : MonoBehaviour {

	public GameObject ballPrefab;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter ( Collider other)
	{
		if (other.gameObject.tag == "Enemy") {
			GameObject ball = Instantiate (ballPrefab, new Vector3 (-129.8f, -247.4f, 191.80f), gameObject.transform.rotation) as GameObject;
			ball.SetActive (true);
			Rigidbody rb = new Rigidbody ();
			rb = ball.GetComponent<Rigidbody>();
			rb.AddForce (1500,5,5);
		}
	}
}
