using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {

	public ServeriKommunikaatio sk;

	PaaKoodi pk;

	Sideways sw;

	AikaLaskuri al;

	void Start()
	{
		sk = GameObject.Find("Main Camera").GetComponent<ServeriKommunikaatio>();
		pk = GameObject.Find("Main Camera").GetComponent<PaaKoodi>();
		sw = GameObject.Find("Opettaja_Idle").GetComponent<Sideways>();
		al = GameObject.Find("AikaTeksti").GetComponent<AikaLaskuri>();

	}

	void Update()
	{
		
		if(sk.nappi2painettu)
		{
			sw.enabled = false;
			al.enabled = false;
			pk.enabled = false;


		}

		if(sk.nappi3painettu)
		{
			//Time.timeScale = 1;
			//Debug.Log("Jatkuu");
			sw.enabled = true;
			al.enabled = true;
			pk.enabled = true;
		}
		

	}


}
