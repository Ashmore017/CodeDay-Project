using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIO;
using System;
using System.Globalization;
public class playerScript : MonoBehaviour {
	private int myID = -1;
	private int count = 0;
	private GameObject player;
	private SocketIOComponent socket;
	private float parseFloat(String s) {
		return float.Parse (s, CultureInfo.InvariantCulture.NumberFormat);
	}
	public void SpawnPlayerServer(SocketIOEvent e) {
		player = Instantiate(GameObject.Find ("Player"));
		Debug.Log (e.data.ToString ());
		player.transform.position = new Vector3 (
			float.Parse (e.data.GetField ("xpos").ToString(), CultureInfo.InvariantCulture.NumberFormat),
			float.Parse (e.data.GetField ("ypos").ToString(), CultureInfo.InvariantCulture.NumberFormat), 
			float.Parse (e.data.GetField ("zpos").ToString(), CultureInfo.InvariantCulture.NumberFormat));
		
		this.myID = int.Parse(e.data.GetField ("id").ToString());
		player.name = "player" + this.myID;
		Debug.Log ("SPAWN");

	}
	public void UpdatePosition(SocketIOEvent e) {
		if (myID == int.Parse (e.data.GetField ("id").ToString ()))
			return;
		GameObject updatedplayer = GameObject.Find ("player" + e.data.GetField ("id").ToString ());
		Debug.Log (e.data.ToString ());
		updatedplayer.transform.Translate(new Vector3 (
			parseFloat(e.data.GetField ("xpos").ToString()),
			parseFloat(e.data.GetField ("ypos").ToString()), 
			parseFloat(e.data.GetField ("zpos").ToString()))-updatedplayer.transform.position);
		updatedplayer.GetComponent<Rigidbody>().velocity = new Vector3 (
			parseFloat (e.data.GetField ("xvel").ToString ()),
			parseFloat (e.data.GetField ("yvel").ToString ()),
			parseFloat (e.data.GetField ("zvel").ToString ()));
		updatedplayer.transform.localRotation = Quaternion.Euler(parseFloat (e.data.GetField ("xrot").ToString ()),
			parseFloat (e.data.GetField ("yrot").ToString ()),
			parseFloat (e.data.GetField ("zrot").ToString ()));

		Debug.Log ("update!");
	}


	public void Start() 
	{
		GameObject go = GameObject.Find("SocketIO");
		socket = go.GetComponent<SocketIOComponent>();
		Debug.Log("lets get things started");
		/*socket.On("moveforward", MoveForward);*/
		socket.On("movebackward", MoveBackward);
		socket.On("turnleft", TurnLeft);
		socket.On("turnright", TurnRight);
		socket.On ("moveforward", MoveForward);
		socket.On ("spawnplayerserver", SpawnPlayerServer);
		socket.On ("updatepositionserver", UpdatePosition);
		StartCoroutine("test");

	}

	public IEnumerator test() {
		yield return new WaitForSeconds(1);
		socket.Emit("spawnplayer");

	}



	public void MoveForward(SocketIOEvent e) {
		/*Vector3 move = Vector3.Scale (Vector3.forward, new Vector3 (0.3F, 0.3F, 0.3f));
		this.transform.Translate (move);*/
	
	}

	public void MoveBackward(SocketIOEvent e) {
		/*Vector3 move = Vector3.back;
		move.Scale (Vector3 (0.3, 0.3, 0.3));
		this.transform.Translate(move);*/
	}
	public void TurnLeft(SocketIOEvent e) {
		/*Vector3 turn = Vector3.down;
		turn.Scale (Vector3 (0.3, 0.3, 0.3));
		this.transform.Rotate(turn);*/
		Debug.Log ("TURNING");
	}
	public void TurnRight(SocketIOEvent e) {
		/*Vector3 turn = Vector3.up;
		turn.Scale (Vector3 (0.3, 0.3, 0.3));
		this.transform.Rotate(turn);*/
	}

	// Update is called once per frame
	void Update () {
		if (myID != -1) {
			count += 1;
			if (count % 5 == 0) {
				JSONObject obj = new JSONObject ();
				obj.AddField ("id", myID);
				Transform t = this.transform;
				obj.AddField ("xpos", t.position.x);
				obj.AddField ("ypos", t.position.y);
				obj.AddField ("zpos", t.position.z);
				Vector3 velocity = this.GetComponent<Rigidbody> ().velocity;
				obj.AddField ("xvel", velocity.x);
				obj.AddField ("yvel", velocity.y);
				obj.AddField ("zvel", velocity.z);
				obj.AddField ("xrot", t.rotation.eulerAngles.x);
				obj.AddField ("yrot", t.rotation.eulerAngles.y);
				obj.AddField ("zrot", t.rotation.eulerAngles.z);
				socket.Emit ("updateposition", obj);
			}
		}
		//JSONObject data = new JSONObject ();
	}
}
