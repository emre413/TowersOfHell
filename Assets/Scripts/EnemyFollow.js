﻿#pragma strict

 var target : Transform; //the enemy's target
 var moveSpeed = 1; //move speed
 var rotationSpeed = 3; //speed of turning
 var range : float=10f;
 var range2 : float=10f;
 var stop : float=0;
 var myTransform : Transform; //current transform data of this enemy
 var health : int = 10;

 var animator : Animator;

 function Awake()
 {
     myTransform = transform; //cache transform data for easy access/preformance
 }
  
 function Start()
 {
 	animator = GetComponent(Animator);
 	animator.SetBool("Run", true);
    target = GameObject.FindWithTag("Player").transform; //target the player
  
 }
  
 function FixedUpdate () {
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