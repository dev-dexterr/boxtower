using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void ExitButton()
    {
        AudioManager audioManager = FindObjectOfType<AudioManager>();
        audioManager.Play("button");

        Application.Quit();
        Debug.Log("Game Closed");
    }

    public void StartGame()
    {
        AudioManager audioManager = FindObjectOfType<AudioManager>();
        audioManager.Play("button");

        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1;

        //StartCoroutine(StartPlay());
    }

    //IEnumerator StartPlay()
    //{
    //    yield return new WaitForSeconds(0.5f);

    //    SceneManager.LoadScene("SampleScene");
    //    Time.timeScale = 1;
    //}
}
