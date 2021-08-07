using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Restart : MonoBehaviour
{
    public void BTN_Restart()
    {
        AudioManager audioManager = FindObjectOfType<AudioManager>();
        audioManager.Play("button");

        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void HomeButton()
    {
        AudioManager audioManager = FindObjectOfType<AudioManager>();
        audioManager.Play("button");

        SceneManager.LoadScene("MainMenu");
    }
}
