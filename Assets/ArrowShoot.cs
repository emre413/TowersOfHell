using UnityEngine;
using System.Collections;

public class ArrowShoot : MonoBehaviour {

	EnemyFollow2 enemy;
	GameManager manager;
	// Use this for initialization
	void Start () {
		GameObject g = GameObject.Find ("CameraMain");
		manager = g.GetComponent<GameManager> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnTriggerEnter ( Collider other)
	{
		if (other.gameObject.tag == "Enemy") {
			enemy = other.gameObject.GetComponent<EnemyFollow2> ();
			enemy.health -= 5; 
			if (enemy.health <= 0) {
				Destroy (other.gameObject);
				manager.gold += 100;
			}
			Destroy (gameObject);
		}

		else if (other.gameObject.CompareTag("Terrain") || other.gameObject.CompareTag("Road"))
		{
			Destroy (gameObject);
		}
	}


}
