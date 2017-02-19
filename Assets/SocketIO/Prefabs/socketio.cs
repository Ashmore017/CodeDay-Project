using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIO;
using System;

public class socketio : MonoBehaviour {
	void callback(SocketIOEvent e) {
		Console.Write("Hello World!");
	}
	// Use this for initialization
	void Start () {
		GameObject go = GameObject.Find("SocketIO"); 
		SocketIOComponent socket = go.GetComponent<SocketIOComponent> ();
		socket.On ("hi", callback);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
