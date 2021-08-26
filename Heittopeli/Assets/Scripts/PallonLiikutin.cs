using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PallonLiikutin : MonoBehaviour {

	public ServeriKommunikaatio sk;
	public Rigidbody rb;

	GameObject crosshair = GameObject.Find("Crosshair");

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	if(sk.nappipainettu)
	{
		rb.AddForce(Vector3.up*3000f);
	}

	if(sk.nappi2painettu)
	{
		rb.AddForce(Vector3.left*1500f);
	} 

	if(sk.nappi3painettu)
	{
		rb.AddForce(Vector3.right*1500f);
		Debug.Log("Pallon pitaisi liikkua vasemallle");
	}

	if(sk.joystickxpainettuO)
	{
		
		//rb.AddForce(Vector3.down*350f);
		Debug.Log("OIKEALLE");
	}

	if(sk.joystickxpainettuV)
	{
		rb.AddForce(Vector3.down*350f);
		Debug.Log("VASEMMALLE");
	}

	if(sk.joystickxpainettuY)
	{
		rb.AddForce(Vector3.down*350f);
		Debug.Log("YLOS");
	}

	if(sk.joystickxpainettuA)
	{
		rb.AddForce(Vector3.down*350f);
		Debug.Log("ALAS");
	}
		
	else 
	{
		rb.AddForce(Vector3.up*300f);
	}

	}
}
