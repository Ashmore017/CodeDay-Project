#pragma strict

function Start () {

}

function Update () 
{

    void Update () {
        if (Input.GetKey("uparrow"))
            this.GetComponent<Rigidbody>().AddForce(transform.right * 50);


        if (Input.GetKey("downarrow"))
            this.GetComponent<Rigidbody>().AddForce(transform.right * -12);




        if (Input.GetKey("leftarrow"))
            this.transform.Rotate(Vector3.down * 2.5f);


        if (Input.GetKey("rightarrow"))
            this.transform.Rotate(Vector3.up * 2.5f);

    }

}