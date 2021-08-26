using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AikaLaskuri : MonoBehaviour
{

    OsumaAnim oa;

    PaaKoodi pk;

	Sideways sw;

	AikaLaskuri al;

    

    public int aika = 10;
    public Text laskuriTeksti;
    public Text gameOverPisteet;
    public Text m_gameOverPisteet;
    public GameObject canvas;
    public GameObject gameOver;
    bool m_aktivoi;
    bool t_aktivoi;
    bool includeInactive =true;


    // Use this for initialization
    void Start()
    {
        oa = GameObject.Find("Opettaja_Idle").GetComponent<OsumaAnim>();
        sw = GameObject.Find("Opettaja_Idle").GetComponent<Sideways>();
        pk = GameObject.Find("Main Camera").GetComponent<PaaKoodi>();
		al = GameObject.Find("AikaTeksti").GetComponent<AikaLaskuri>();

        StartCoroutine("LaskeAikaa");
        canvas = GameObject.Find("Canvas");
        gameOver = GameObject.Find("GameOver");
        m_aktivoi = false;
        t_aktivoi = true;
        gameOver.SetActive(m_aktivoi);
        //gameOver.SetActive(t_aktivoi);

        //gameOverPisteObject = gameOver.GetComponentInChildren<GameOverPisteet>(true);
        GameObject gameOverPisteObject = GameObject.Find("GameOverPisteet");
        m_gameOverPisteet = gameOverPisteObject.GetComponent<Text>();



    }

    // Update is called once per frame
     void Update()
    {
        
        
        laskuriTeksti.text = ("Aika: " + aika);


        if (aika <= 0)
        {
            StopCoroutine("LaskeAikaa");
            laskuriTeksti.text = "Aika loppui!";
            sw.enabled = false;
			al.enabled = false;
			pk.enabled = false;
            
            canvas.SetActive(m_aktivoi);
            gameOver.SetActive(t_aktivoi);
            m_gameOverPisteet.text = "Pisteet: " + oa.m_loppuPisteet;

        }


    }

    IEnumerator LaskeAikaa()
    {
        while (true)
        {
            
            yield return new WaitForSeconds(1);
            if (sw.enabled == true)
            {
            aika--;
            }
        }
    }

}
