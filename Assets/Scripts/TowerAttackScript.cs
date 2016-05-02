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
		int force = 1000;
		if (other.gameObject.tag == "Enemy") {
			Vector3 pos = gameObject.transform.position;
			pos.y += 23;
			if (gameObject.transform.position.x > -70)
				force *= -1;
			GameObject ball = Instantiate (ballPrefab, pos, gameObject.transform.rotation) as GameObject;
			ball.SetActive (true);
			Rigidbody rb = new Rigidbody ();
			rb = ball.GetComponent<Rigidbody>();
			rb.AddForce (force,5,5);
		}
	}
}
