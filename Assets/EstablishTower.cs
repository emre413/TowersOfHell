using UnityEngine;
using System.Collections;

public class EstablishTower : MonoBehaviour {

	public GameObject towerPrefab;
	GameManager manager;
	// Use this for initialization
	void Start () {
		GameObject g = GameObject.Find ("CameraMain");
		manager = g.GetComponent<GameManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Camera.main.name == "CameraMain"){
			if (Input.GetMouseButtonDown (0)) {
				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				RaycastHit hit;
				if (Physics.Raycast (ray, out hit, 400) && manager.gold >= 400) {
					if (gameObject.name == "Plane" && (hit.transform.position.x > -65 || hit.transform.position.x < -90)) {
						GameObject tower = Instantiate (towerPrefab, hit.transform.position, gameObject.transform.rotation) as GameObject;

						if (hit.transform.position.x > -70) {
							tower.transform.Rotate (0, 270, 0);
						} else {
							tower.transform.Rotate (0, 90, 0);
						}
						manager.gold -= 400;
					}
				}
			}
		}
	}
}
