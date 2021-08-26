using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System;
using WebSocketSharp;

public class Werkko2 : MonoBehaviour {

	WebSocket ws;

	// Use this for initialization
	void Start () {
		ws = new WebSocket("ws://172.16.200.27:5000/unitysocketendpoint");

		ws.OnMessage += (Sender, e) => Debug.Log("Test says: "+ e.Data);

		ws.Connect();

		ws.Send("PRKL!");

		Debug.Log("Starting");
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKeyDown(KeyCode.F))
		{
			ws.Close();
		}
		if (Input.GetKeyDown(KeyCode.M))
		{
			Debug.Log("KeyCode.M");
			ws.Send("Testing..!");
			
		}

	}
}
