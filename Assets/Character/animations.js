#pragma strict
var animator : Animator; 
var v : float; 
var h : float;
var swing : boolean;
var cam2 : Camera;

var sprint : float;
 
function Start () {
 
animator = GetComponent(Animator); 
 
}
 
function Update () {

	if(cam2.enabled) {
		v = Input.GetAxis("Vertical");
		h = Input.GetAxis("Horizontal");

		if(Input.GetMouseButton(0)) {
			swing = true;
		} else {
			swing = false;
		}

		Sprinting();
	}
}
 
function FixedUpdate () {
 	if(cam2.enabled) {
		animator.SetFloat ("Walk", v);
		animator.SetFloat ("Turn", h);
		animator.SetBool("Swing", swing);
		animator.SetFloat("Sprint", sprint);
	}
}
 

 function Sprinting () {
	if(Input.GetButton("Fire1")) {
		sprint = 0.2;
	}
	else {
	 
	sprint = 0.0;
	}
	 
}