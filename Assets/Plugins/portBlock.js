#pragma strict
public var blocked = 0;
function Start () {

		
}

 function Update () 
 {
 var lock = 0;
         if (Input.GetMouseButtonDown(0))
		 {
             var hit: RaycastHit;
             var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
             if (gameObject.GetComponent.<Renderer>().material.color == Color.white && lock != 1)
             {
				if (Physics.Raycast(ray, hit)) 
				{
					if (hit.transform.name == gameObject.name )
					 {
                 		gameObject.GetComponent.<Renderer>().material.color = Color.red;
						Debug.Log( "red" );
						Debug.Log( gameObject.GetComponent.<Renderer>().material.color );
						blocked = 1;
						lock = 1;
					}
                }
			}
			
		 
		if (gameObject.GetComponent.<Renderer>().material.color == Color.red && lock != 1)
        {
			if (Physics.Raycast(ray, hit)) 
			{
                 if (hit.transform.name == gameObject.name )
                 {
					gameObject.GetComponent.<Renderer>().material.color = Color.white;
					Debug.Log( "white" );
					blocked = 0;
					lock = 1;
                 }
            }
		}
     }
}

