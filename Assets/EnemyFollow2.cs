using UnityEngine;
using System.Collections;

public class EnemyFollow2 : MonoBehaviour {

	public Transform target; //the enemy's target
	public int moveSpeed = 1; //move speed
	public int rotationSpeed = 3; //speed of turning
	public float range = 10f;
	public float range2 = 10f;
	public float stop = 0;
	public Transform myTransform; //current transform data of this enemy
	public int health = 10;

	public Animator animator;

	void Awake()
	{
		myTransform = transform; //cache transform data for easy access/preformance
	}

	void Start()
	{
		animator = GetComponent<Animator> ();
		animator.SetBool("Run", true);
		target = GameObject.FindWithTag("Player").transform; //target the player

	}

	void FixedUpdate () {
		//rotate to look at the player
		var distance = Vector3.Distance(myTransform.position, target.position);

		if (distance <= range2 &&  distance >= range){
			myTransform.rotation = Quaternion.Slerp(myTransform.rotation, Quaternion.LookRotation(target.position - myTransform.position), rotationSpeed * Time.deltaTime);
		}


		else if(distance <= range && distance > stop){
			//move towards the player
			myTransform.rotation = Quaternion.Slerp(myTransform.rotation, Quaternion.LookRotation(target.position - myTransform.position), rotationSpeed * Time.deltaTime);
			myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
		}
		else if (distance <= stop) {
			animator.SetBool("Run", false);
			myTransform.rotation = Quaternion.Slerp(myTransform.rotation, Quaternion.LookRotation(target.position - myTransform.position), rotationSpeed * Time.deltaTime);
		}
	}
}
