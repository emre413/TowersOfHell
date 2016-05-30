using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public Camera cam1; 
	public Camera cam2;
	public GameObject swordsman;
	public GameObject archer;
	private GameManager gm;
	private const int changeCost = 200;
	private float nextChange = 0.0f;
	private float changeRate = 2.0f;

	// Use this for initialization
	void Start () {
		gm = GetComponent<GameManager> ();

		if (swordsman.activeSelf) {
			gm.playerType = PlayerType.Swordsman;
			cam2 = swordsman.GetComponentInChildren<Camera> ();
			gm.playerHealth = 100.0f;
		} else if (archer.activeSelf) {
			gm.playerType = PlayerType.Archer;
			cam2 = archer.GetComponentInChildren<Camera> ();
			gm.playerHealth = 60.0f;
		} else {
			Debug.Log ("Both Characters are Inactive at the Same Time!");
		}

		cam2.enabled = false;
		cam1.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.K)) {
			cam1.enabled = false;
			cam2.enabled = true;

			EnemyMovement em = new EnemyMovement ();
			em.start = true;
		}
		if(Input.GetKey(KeyCode.L)){
			cam1.enabled = true;
			cam2.enabled = false;
		}
		if (Input.GetKey (KeyCode.C)) {
			if (gm.gold >= changeCost) {
				if (Time.time > nextChange) {
					nextChange = Time.time + changeRate;

					if (archer.activeSelf) {
						swordsman.transform.position = new Vector3 (-74.6f, -270.99f, 68.9f);
						swordsman.transform.rotation = Quaternion.Euler (0.0f, 0.0f, 0.0f);
						gm.playerHealth = 100;
						swordsman.SetActive (true);
						swordsman.GetComponentInChildren<Camera> ().enabled = true;
						gm.gold -= changeCost;
						gm.playerType = PlayerType.Swordsman;
						archer.SetActive (false);
					} else if (swordsman.activeSelf) {
						archer.transform.position = new Vector3 (-74.7f, -270.99f, 68.9f);
						archer.transform.rotation = Quaternion.Euler (0.0f, 90.0f, 0.0f);
						gm.playerHealth = 60;
						archer.SetActive (true);
						archer.GetComponentInChildren<Camera> ().enabled = true;
						gm.gold -= changeCost;
						gm.playerType = PlayerType.Archer;
						swordsman.SetActive (false);
					}
				}
			}
		}
	}
}
