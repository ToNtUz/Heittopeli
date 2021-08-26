using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour{

public ServeriKommunikaatio sk;


    void Start()
    {
        sk = GameObject.Find("Main Camera").GetComponent<ServeriKommunikaatio>();
    }

    public void RestartGame()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
        // loads current scene
        SceneManager.LoadScene("PaaKentta");
        Time.timeScale = 1;
    }

    public void MainMenuun()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1;
    }

    void Update()
    {
        if (sk.nappi2painettu)
        {
            RestartGame();
        }

        if (sk.nappi3painettu)
        {
            MainMenuun();
        }

    }
}
