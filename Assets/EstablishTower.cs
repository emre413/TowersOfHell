using UnityEngine;
using System.Collections;

public class EstablishTower : MonoBehaviour {

	public GameObject towerPrefab;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Camera.main){
			if (Input.GetMouseButtonDown (0)) {
				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				RaycastHit hit;
				if (Physics.Raycast (ray, out hit, 500)) {
					if (gameObject.name == "Plane") {
						GameObject tower = Instantiate (towerPrefab, hit.transform.position, gameObject.transform.rotation) as GameObject;

						if (hit.transform.position.x > -70) {
							tower.transform.Rotate (0, 270, 0);
						} else {
							tower.transform.Rotate (0, 90, 0);
						}
					}
				}
			}
		}
	}
}
