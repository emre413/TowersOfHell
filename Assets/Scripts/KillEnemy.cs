using UnityEngine;
using System.Collections;

public class KillEnemy : MonoBehaviour {
	public Animator charAnimator;
	EnemyFollow2 enemy;
	GameManager manager;
	// Use this for initialization
	void Start () {
		GameObject g = GameObject.Find ("CameraMain");
		manager = g.GetComponent<GameManager> ();
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Enemy") {
			if (charAnimator.GetBool("Swing") == true) {
				enemy = other.gameObject.GetComponent<EnemyFollow2> ();
				enemy.health -= 5; 
				if (enemy.health <= 0) {
					Destroy (other.gameObject);
					manager.gold += 100;
				}
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
