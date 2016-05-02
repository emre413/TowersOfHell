using UnityEngine;
using System.Collections;

public class BallExplode : MonoBehaviour {

	public GameObject explosion;
	public AudioClip sound;

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag("Terrain") || other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Road")) {
			GameObject newExplosion = (GameObject)Instantiate (explosion, transform.position, transform.rotation);

			newExplosion.SetActive (true);

			AudioSource.PlayClipAtPoint (sound, other.transform.position);
			Destroy (newExplosion, 5);

			Destroy (gameObject);
		}
	}
}
