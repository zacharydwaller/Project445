#pragma strict

var X : int;
var Y : int;

function Start () {
X = 100;
Y = 1;

	
}

function Update () {
	
transform.localScale = new Vector3(X, Y); //We don't changing Z scale now

}
