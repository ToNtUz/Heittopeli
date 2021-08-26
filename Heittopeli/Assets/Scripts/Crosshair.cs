using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour {

	ServeriKommunikaatio sk;


	// Use this for initialization
	void Start () {

		Cursor.visible = false;
		sk = GameObject.Find("Main Camera").GetComponent<ServeriKommunikaatio>();


		
	}
	
	// Update is called once per frame
	void Update () {
		float sivuliike = 0;
		float pystyliike = 0;

		if (sk.joystickxpainettuO)
		{
			sivuliike = 30f;
			Debug.Log("CROSSHAIR OIKEALLE");
		}

		else if (sk.joystickxpainettuV)
		{
			sivuliike = -30f;
			Debug.Log("CROSSHAIR VASEMMALLE");
		}
	
		else if (sk.joystickxpainettuY)
		{
			pystyliike = 30f;
			
		}

		else if (sk.joystickxpainettuA)
		{
			pystyliike = -30f;
			
		}


		else 
		{
			sivuliike = 0;
		}

		this.transform.position = new Vector3(this.transform.position.x + sivuliike, this.transform.position.y + pystyliike);

	}
}
