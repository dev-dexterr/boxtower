using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    [HideInInspector]
    public BlockController currentBlock;

    public BlockCloner blockCloner;
    public CameraController camera;
    public GameObject GameOver;
    public Text txtScore;

    private int count;
    private int score;
    public bool firstLanded = true;

    private void Awake()
    {
        txtScore.text = "0";

        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        blockCloner.CloneBlock();
    }

    void Update()
    {
        TrackClick();
    }

    private void TrackClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            currentBlock.FallingBlock();
        }
    }
    public void MoveCamera()
    {
        count++;

        if (count == 3)
        {
            count = 0;
            camera.targetPos.y += 3f;
        }
    }
    private void NewBlock()
    {
        blockCloner.CloneBlock();
    }

    public void CloneNewBlock()
    {
        score++;
        txtScore.text = score.ToString();
        //Debug.Log(score.ToString());
        Invoke("NewBlock", 2f);
        //NewBlock();
    }

    public void RestartGame()
    {
        Debug.Log("GameOver");
        GameOver.gameObject.SetActive(true);
        Time.timeScale = 0;
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
