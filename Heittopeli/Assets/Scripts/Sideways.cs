using System.Collections;
using UnityEngine;

public class Sideways : MonoBehaviour
{

    public Animator anim;
    public int nopeus;
    public float maxRange;
    public float minRange;
    public float erotus;

    protected Vector3 nykyinenPos;
    protected Vector3 loppuPos;
    protected bool voiLiikkua = true;

    public void KasvataNopeutta()
    {

        nopeus = nopeus + 10;
    }

    void Start()
    {
        anim = GetComponent<Animator>();
        nykyinenPos = transform.position;
        loppuPos = new Vector3(Random.Range(minRange, maxRange), 10, -50);
    }

    void Update()
    {

 
        nykyinenPos = transform.position;


        if (nykyinenPos != loppuPos && voiLiikkua == true)
        {

            float askel = nopeus * Time.deltaTime;
            transform.position = Vector3.MoveTowards(nykyinenPos, loppuPos, askel);

            anim.SetBool("Kavely", true);
            anim.SetBool("Idle", false);
            anim.SetBool("Osuma", false);

        }

        if (nykyinenPos == loppuPos)
        {
            anim.SetBool("Kavely", false);
            anim.SetBool("Idle", true);
            anim.SetBool("Osuma", false);
            voiLiikkua = false;
            StartCoroutine(Wait());

            float A = nykyinenPos.x;

            float B = Random.Range(minRange, (A - erotus));
            if (B < minRange)
                B = minRange;

            float C = Random.Range(maxRange, (A + erotus));
            if (C > maxRange)
                C = maxRange;

            int suunta = 1;

            if (Mathf.Abs((maxRange - A)) < erotus)
                suunta = -1;
            else if (Mathf.Abs((minRange - A)) > erotus)
                suunta = 1;
            else
                suunta = Random.Range(-1, 1);

            if (suunta >= 0)
            {
                loppuPos = new Vector3(C, 10, -50);
            }



            else if (suunta < 0)
                loppuPos = new Vector3(B, 10, -50);
                Debug.Log("Suunta1:");
                
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.5f);
        voiLiikkua = true;
    }
}