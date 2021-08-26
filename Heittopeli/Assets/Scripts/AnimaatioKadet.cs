using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimaatioKadet : MonoBehaviour {

    public Animator anim;

     public ServeriKommunikaatio sk;

	// Use this for initialization
	void Start () {

        sk = GameObject.Find("Main Camera").GetComponent<ServeriKommunikaatio>();
        anim = GetComponent<Animator>();
        anim.SetBool("Heitto1", false);
        anim.SetBool("Juonti", false);
        anim.SetBool("Heitto2", false);

    }
	
	// Update is called once per frame
	void Update () {
		
        if (sk.nappipainettu)
        {
            anim.SetBool("Heitto1", true);
            anim.SetBool("Heitto2", false);
        }

        if (sk.nappipainettu == false)
        {
            anim.SetBool("Heitto1", false);
            anim.SetBool("Heitto2", true);


        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("Juonti", true);
            anim.SetBool("Heitto1", false);
            anim.SetBool("Heitto2", false);

        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            anim.SetBool("Juonti", false);
        }

    }
}
