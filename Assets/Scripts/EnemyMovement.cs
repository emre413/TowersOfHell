using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {
	public int speed = 8;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate ()
	{
		transform.position += transform.forward * speed * Time.deltaTime;
	}

	void OnTriggerEnter ( Collider other)
	{
		if (other.gameObject.tag == "Player")
			speed = 0;
	}
}
