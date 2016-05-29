using UnityEngine;
using System.Collections;

public class SpawnEnemy : MonoBehaviour {

	public GameObject enemy;
	public float spawnTime = 10f;
	// Use this for initialization
	void Start () {
		InvokeRepeating ("SpawnEnemyIn30Second", spawnTime, spawnTime);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void SpawnEnemyIn30Second ()
	{
		Vector3 pos = gameObject.transform.position;
		GameObject go = GameObject.Instantiate (enemy, pos, Quaternion.identity) as GameObject;
		go.transform.Rotate (0, 188, 0);
	}

}
