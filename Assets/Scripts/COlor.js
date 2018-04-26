#pragma strict

function Start () {
	
		
}

 function Update () {
         if (Input.GetMouseButtonDown(0)) {
             var hit: RaycastHit;
             var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
             
             if (Physics.Raycast(ray, hit)) {
                 if (hit.transform.name == "Box1" )gameObject.GetComponent.<Renderer>().material.color = Color.red;
             }
         }
		 }

function OnMouseDown ()
{

	gameObject.GetComponent.<Renderer>().material.color = Color.red;

}