using UnityEngine;
using System.Collections;

public class CharacterHeal : MonoBehaviour {

	GameManager manager;
	bool inArea = false;
	// Use this for initialization
	void Start () {
		GameObject g = GameObject.Find ("CameraMain");
		manager = g.GetComponent<GameManager> ();
	}

	// Update is called once per frame
	void Update () {
		if (inArea) {
			if (manager.playerType == PlayerType.Archer) {
				if (manager.playerHealth < 80.0f) {
					manager.playerHealth += 0.005f;
				}
			} else if (manager.playerType == PlayerType.Swordsman) {
				if (manager.playerHealth < 100.0f) {
					manager.playerHealth += 0.005f;
				}
			}
		}
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == "Player") {
			inArea = true;
		}
	}

	void OnTriggerExit (Collider other)
	{
		if (other.gameObject.tag == "Player") {
			inArea = false;
		}
	}

}
