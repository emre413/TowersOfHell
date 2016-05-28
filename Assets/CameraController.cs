using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public Camera cam1; 
	public Camera cam2; 

	// Use this for initialization
	void Start () {

		cam2.enabled = false;
		cam1.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.Space)){
			cam1.enabled = false;
			cam2.enabled = true;

			EnemyMovement em = new EnemyMovement ();
			em.start = true;
		}
	}
}
