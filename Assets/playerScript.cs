using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIO;
using System;
public class playerScript : MonoBehaviour {
	public void Start() 
	{
		GameObject go = GameObject.Find("SocketIO");
		SocketIOComponent socket = go.GetComponent<SocketIOComponent>();
		Debug.Log("lets get things started");
		socket.On("moveforward", MoveForward);
		socket.On("movebackward", MoveBackward);
		socket.On("turnleft", TurnLeft);
		socket.On("turnright", TurnRight);
		socket.Emit ("moveforward");

	}

	public void MoveForward(SocketIOEvent e) {
		this.transform.Translate (Vector3.forward);
	}

	public void MoveBackward(SocketIOEvent e) {
		this.transform.Translate(Vector3.back);
	}
	public void TurnLeft(SocketIOEvent e) {
		this.transform.Rotate(Vector3.down);
	}
	public void TurnRight(SocketIOEvent e) {
		this.transform.Rotate(Vector3.up);
	}

	// Update is called once per frame
	void Update () {
		GameObject go = GameObject.Find("SocketIO");
		SocketIOComponent socket = go.GetComponent<SocketIOComponent>();
		if (Input.GetKey(KeyCode.W)) {
			Debug.Log ("FORWARD");
			socket.Emit ("moveforward");
		}
		else if (Input.GetKey (KeyCode.S)) {
			Debug.Log ("Backwards");
			socket.Emit ("movebackward");
		}
		if (Input.GetKey (KeyCode.A)) {
			socket.Emit ("turnleft");
		}
		if (Input.GetKey (KeyCode.D)) {
			socket.Emit ("turnright");
		}
	}
}
