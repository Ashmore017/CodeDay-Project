﻿#pragma strict

function Start () {

}

function Update () 
{
    if(Input.GetKey("w"))   
        this.transform.Translate (Vector3.forward * 0.3);


    if(Input.GetKey("s"))   
        this.transform.Translate (Vector3.back * 0.05);


    if(Input.GetKey("a"))   
        this.transform.Rotate (Vector3.down * 0.7);


    if(Input.GetKey("d"))   
        this.transform.Rotate (Vector3.up * 0.7);


    if(Input.GetKey("space"))   
        this.transform.Translate (Vector3.up * 0.3);


    if(Input.GetKey("c"))   
        this.transform.Translate (Vector3.down * 0.1);

    if(Input.GetKey("q"))   
        this.transform.Rotate (Vector3.up * 0.5);

    if(Input.GetKey("e"))   
        this.transform.Rotate (Vector3.down * 0.5);

    if(Input.GetKey("c"))   
        this.transform.Rotate (Vector3.right * 0.3);
}