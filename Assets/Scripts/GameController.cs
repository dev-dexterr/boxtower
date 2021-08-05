using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    [HideInInspector]
    public BlockController currentBlock;

    public BlockCloner blockCloner;
    public CameraController camera;

    private int count;
    private int score; 

    private void Awake()
    {
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
            camera.targetPos.y += 2f;
        }
    }
    private void NewBlock()
    {
        blockCloner.CloneBlock();
    }

    public void CloneNewBlock()
    {
        score++;
        Debug.Log(score.ToString());

        //Invoke("NewBlock", 2f);
        NewBlock();
    }

    public void RestartGame()
    {
        Debug.Log("Restart");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
}
