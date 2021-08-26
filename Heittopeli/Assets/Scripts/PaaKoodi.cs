using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaaKoodi : MonoBehaviour {
public Camera m_CrosshairCamera;

 public Animator anim;

 public ServeriKommunikaatio sk;
 public Rigidbody rb;
 public float coolDown = 3;
 public float coolDownTimer;

 public Text m_cooldownNaytto;


 public float heitonVoimakkuus = 1.2f;
    // Use this for initialization
    public bool test = true; 

    void Start () {
        m_CrosshairCamera.gameObject.SetActive(true);
        GameObject uiCooldown = GameObject.Find("CooldownTeksti");
        m_cooldownNaytto = uiCooldown.GetComponent<Text>();
      
    }

 // Update is called once per frame
 void Update () {

   GameObject crosshair = GameObject.Find("Crosshair");

 if (coolDownTimer > 0)
   {
     coolDownTimer -= Time.deltaTime;
   }

 if (coolDownTimer < 0)
   {
     coolDownTimer = 0;
   }

  m_cooldownNaytto.text = "Cooldown: " + coolDownTimer.ToString("F1");

        
        if (sk.nappipainettu /*Input.GetButtonDown("Fire1")*/ && coolDownTimer == 0)
        {
            
            coolDownTimer = coolDown;

                Object HeitettavaEsine = Resources.Load("HeittoTolkki");

                GameObject instatioituEsine = (GameObject)Instantiate(HeitettavaEsine);


                Rigidbody m_heitettavaEsine = instatioituEsine.GetComponent<Rigidbody>();
                Camera pelaajanKamera = Camera.main;
                Vector3 hiirenpaikka = new Vector3(crosshair.transform.position.x,
                                               crosshair.transform.position.y,
                                               pelaajanKamera.nearClipPlane);
                Vector3 tolkinalkupiste = pelaajanKamera.ScreenToWorldPoint(hiirenpaikka);
                Ray tolkinSuunta = pelaajanKamera.ScreenPointToRay(hiirenpaikka);

                m_heitettavaEsine.transform.position = tolkinalkupiste;


                Vector3 heittoSuunta = (pelaajanKamera.transform.forward) + (pelaajanKamera.transform.up * 300f) + (tolkinSuunta.direction *12000f) ;

                m_heitettavaEsine.velocity = Vector3.zero;
                m_heitettavaEsine.AddForce(heittoSuunta * heitonVoimakkuus );
                //m_heitettavaEsine.transform.position = transform.position + (transform.forward * -2f) + Vector3.up;



          
            }
        }


 
 }
