using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour {
	
	public GameObject arrowPrefab;
	public Camera cam2;

	Animator anim;
	/*
	public int i = 1;
	float distance = 10.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		int force = -5000;
		if (Input.GetKey(KeyCode.Mouse0) && i == 1 ) {
			Vector3 pos = gameObject.transform.position;
			pos.y += 5;
			pos.z += 5;
			GameObject arrow = Instantiate (arrowPrefab, pos, gameObject.transform.rotation) as GameObject;
			arrow.SetActive (true);
			arrow.transform.Rotate (90, 0, 0);


			Rigidbody rb = new Rigidbody ();
			rb = arrow.GetComponent<Rigidbody>();
			rb.AddForce (0,1000,1500);
			i--;
		}

		if (Input.GetMouseButtonDown(0)) {

			Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
			position = Camera.main.ScreenToWorldPoint(position);

			Vector3 pos = gameObject.transform.position;
			pos.y += 5;
			pos.z += 5;

			GameObject go = Instantiate(arrowPrefab, pos, Quaternion.identity) as GameObject;
			go.transform.LookAt(position);    
			Debug.Log(position);    

			//go.rigidbody.AddForce(go.transform.forward * 1000);

			Rigidbody rb = new Rigidbody ();
			rb = go.GetComponent<Rigidbody>();
			rb.AddForce (go.transform.forward * 1000);
		}


	}*/
	float ArrowSpeed = 10000.0f;
	float fireRate = 2f;
	float nextFire = 0.0f;
	float pullStartTime = 0.0f;
	float pullTime = 0.5f;

	bool falsePull;
	float maxStrengthPullTime = 2f;

	void Start ()
	{
		falsePull = false;
		anim = GetComponent<Animator> ();

	}

	void Update()
	{
		if (cam2.enabled) {
			if (Input.GetMouseButtonDown (0)) {
				if (Time.time > nextFire) {
					nextFire = Time.time + fireRate;
					pullStartTime = Time.time;
				} else {
					falsePull = true;
				}
			}
			if (Input.GetMouseButtonUp (0)) {
				//	gameObject.transform.Rotate (0,90,0);
				anim.SetTrigger ("Fire");

				if (!falsePull) {
					nextFire = Time.time + pullTime;

					float timePulledBack = Time.time - pullStartTime;
					if (timePulledBack > maxStrengthPullTime)
						timePulledBack = maxStrengthPullTime;

					float arrowSpeed = ArrowSpeed * timePulledBack;

					Vector3 pos = gameObject.transform.position;
					pos.y += 5f;
					//pos.z += 5;

					GameObject go = Instantiate (arrowPrefab, pos, transform.rotation) as GameObject;

					go.transform.Rotate (90, 90, 0);
					Collider cl1 = arrowPrefab.GetComponent<Collider> ();
					Collider cl2 = transform.root.GetComponent<Collider> ();

					Physics.IgnoreCollision (cl1, cl2);

					Rigidbody rb = new Rigidbody ();
					rb = go.GetComponent<Rigidbody> ();

					rb.AddForce ((-1 * transform.right) * arrowSpeed);
				} else {
					falsePull = false;
				}
			}
		}
	}
}
