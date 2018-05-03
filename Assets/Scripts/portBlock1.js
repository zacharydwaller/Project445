#pragma strict
function Start () {

		
}

 function Update () 
 {	
         if (Input.GetMouseButtonDown(0))
		 {				
             var hit: RaycastHit;
             var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
             
             if (Physics.Raycast(ray, hit)) 
			 {Debug.Log("test");
                 if (hit.transform.name == "Box1" )
                 {
					Debug.Log("test");
					Application.LoadLevel("d");
                 }
             }

         }
}

