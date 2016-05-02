using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {
	public int speed = 1;
	public bool start = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate ()
	{
		if (start)
			transform.position += transform.forward * speed * Time.deltaTime;
	}

	void OnTriggerEnter ( Collider other)
	{
		if (other.gameObject.tag == "Player")
			speed = 0;
	}

	void StartMove ()
	{
		start = true;
	}

}
