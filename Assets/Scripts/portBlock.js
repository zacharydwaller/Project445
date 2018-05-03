#pragma strict
public var blocked = 0;
function Start () {

		
}

 function Update () {
         if (Input.GetMouseButtonDown(0)) {
             var hit: RaycastHit;
             var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
             
             if (Physics.Raycast(ray, hit)) {
                 if (hit.transform.name == "Box1" )
                 {
                 if( gameObject.GetComponent.<Renderer>().material.color == Color.white)
                 		gameObject.GetComponent.<Renderer>().material.color = Color.red;
                 Debug.Log( "test" );
				 if (blocked == 0)
                 blocked = 1;
				 else
                 blocked = 0;
                 }
             }

         }
		 }

function OnMouseDown ()
{

	gameObject.GetComponent.<Renderer>().material.color = Color.red;

}