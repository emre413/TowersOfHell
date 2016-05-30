using UnityEngine;
using System.Collections;

public class SpawnEnemy : MonoBehaviour {

	public GameObject enemy;
	public float spawnTime = 3f;
	GameManager manager;
	// Use this for initialization
	void Start () {
		GameObject g = GameObject.Find ("CameraMain");
		manager = g.GetComponent<GameManager> ();
		InvokeRepeating ("SpawnEnemyIn30Second", 0, spawnTime);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void SpawnEnemyIn30Second ()
	{
		Vector3 pos = gameObject.transform.position;
		pos.y -= 15f;
		/*
		GameObject go = GameObject.Instantiate (enemy, pos, Quaternion.identity) as GameObject;
		go.transform.Rotate (0, 188, 0);	*/

		int i = 0;
		while (i <= manager.level/2 + 1 ) {			
			GameObject go3 = GameObject.Instantiate (enemy, pos, Quaternion.identity) as GameObject;
			go3.transform.Rotate (0, 188, 0);
			pos.z -= 15f;
			i++;
		}

		manager.level++;

		if (manager.level == 10)
			manager.state = GameState.WON;
	}

	void Wait ()
	{

	}

}
