using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortBlock : MonoBehaviour {

    public bool Blocked = false;

	// Use this for initialization
	void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {

	}

    void OnMouseDown()
    {
        if (!Blocked)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.red;
            Blocked = true;
        }
        else
        {
            gameObject.GetComponent<Renderer>().material.color = Color.white;
            Blocked = false;
        }
    }
}
