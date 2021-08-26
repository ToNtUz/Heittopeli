using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Huomaus : MonoBehaviour {

    Animator m_heittajaAnimaatiot;
  

    // Use this for initialization
    void Start () {

        m_heittajaAnimaatiot = GetComponent<Animator>();



    }
	
	// Update is called once per frame
	void Update () {

        GameObject pelaaja = GameObject.Find("Heittaja");

       float etaisyysPelaajaan = Vector3.Distance(
       pelaaja.transform.position, transform.position);

        if (etaisyysPelaajaan < 5000f)
        {
            RaycastHit raycastHit = new RaycastHit();
            // tarkastus onko pelaajan ja kummituksen välillä jotain?
            bool osuttiinkojohonkin = Physics.Linecast(transform.position,
                                                       pelaaja.transform.position,
                                                       out raycastHit);
            if (osuttiinkojohonkin == true)
            {
                if (raycastHit.transform.name.Contains("Heittaja"))
                {
                    Debug.Log("Osuttiin heittajaan");
                }
                else
                {
                    Debug.Log("Ray sade ei osunut pelaajaan, vaan " + raycastHit.transform.name);
                }
            }
        }
    }


}

