using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey("w"))
            this.GetComponent<Rigidbody>().AddForce(transform.forward * 100);


    if (Input.GetKey("s"))
            this.GetComponent<Rigidbody>().AddForce(transform.forward * -100);




        if (Input.GetKey("a"))
            this.transform.Rotate(Vector3.down * 1.7f);


        if (Input.GetKey("d"))
            this.transform.Rotate(Vector3.up * 1.7f);

    }
}
