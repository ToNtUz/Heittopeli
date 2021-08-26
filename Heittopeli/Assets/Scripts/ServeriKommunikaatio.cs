using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class ServeriKommunikaatio : MonoBehaviour {
public string url = "http://127.0.0.1:5000/ohjaindata";
public bool nappipainettu = false;
public bool nappi2painettu = false;
public bool nappi3painettu = false;
public bool joystickxpainettuO = false;
public bool joystickxpainettuV = false;
public bool joystickxpainettuA = false;
public bool joystickxpainettuY = false;

	// Use this for initialization


	void Start () {
		StartCoroutine ("GetOhjainData");
 }



 [Serializable]

public class PeliohjaimenTiedot {
 public Ohjain OhjaimenTiedot;
}



[Serializable]
public class Ohjain {

	public int ohjaimenId;
 	public int napin1tila;
 	public int napin2tila;	
	public int napin3tila;
	public int joystickxtila;
	

}




 IEnumerator GetOhjainData()
 {
 using (WWW www = new WWW(url))
 {
 yield return www;
 Debug.Log ("Getting JSON data: " + www.text);
 PeliohjaimenTiedot peliohjaimentieto = JsonUtility.FromJson<PeliohjaimenTiedot>(www.text);
 
 Debug.Log ("Serveriltä: " + peliohjaimentieto.OhjaimenTiedot.ohjaimenId + 
"Napin1tila" + peliohjaimentieto.OhjaimenTiedot.napin1tila);

 if (peliohjaimentieto.OhjaimenTiedot.napin1tila == 10)
 nappipainettu = true;
 else
 nappipainettu = false;

 if (peliohjaimentieto.OhjaimenTiedot.napin2tila == 12)
 nappi2painettu = true;
 else
 nappi2painettu = false;

if (peliohjaimentieto.OhjaimenTiedot.napin3tila == 14)
 nappi3painettu = true;
 else
 nappi3painettu = false;

if (peliohjaimentieto.OhjaimenTiedot.joystickxtila == 20)
 joystickxpainettuO = true;
 else
 joystickxpainettuO = false;

if (peliohjaimentieto.OhjaimenTiedot.joystickxtila == 21)
 joystickxpainettuV = true;
 else
 joystickxpainettuV = false;

if (peliohjaimentieto.OhjaimenTiedot.joystickxtila == 22)
 joystickxpainettuA = true;
 else
 joystickxpainettuA = false;

if (peliohjaimentieto.OhjaimenTiedot.joystickxtila == 23)
 joystickxpainettuY = true;
 else
 joystickxpainettuY = false;

yield return new WaitForSeconds (0.1f);
StartCoroutine ("GetOhjainData");

 }
}
}
