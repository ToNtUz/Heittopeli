using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OsumaAnim : MonoBehaviour {

    public Animator anim;
    public float m_pistemaara;
    public float m_loppuPisteet;
    Text m_pisteet;
    //public Text Piste;

 

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();

        GameObject pistegameobject = GameObject.Find("Pisteet");
        m_pisteet = pistegameobject.GetComponent<Text>();
       

    }

    void PaivitaNopeus()
    {
        GameObject opettaja = GameObject.Find("Opettaja_Idle");
        Sideways sideways = opettaja.GetComponent<Sideways>();

        sideways.KasvataNopeutta();
    }

    void start()
    {

    }

    // Update is called once per frame
    void Update() {


    }


        private void OnCollisionExit(Collision collision)
        {
            anim.SetBool ("Osuma", false);

        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Ammus")
            {
            anim.SetBool("Osuma", true);
            m_pistemaara = m_pistemaara + 10f;
            m_loppuPisteet = m_pistemaara;
            m_pisteet.text = "Pisteet: " + m_loppuPisteet;
            //Piste.text = "Pisteet:" + m_pistemaara;

            PaivitaNopeus();


        }

        }

    
}
