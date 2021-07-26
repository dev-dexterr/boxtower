using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    private bool gameover;
    private bool moving;
    private bool ignoreCollision;
    private bool ignoreTrigger;
    private bool firstLanded;

    private float speed = 2f;
    private float min_x = -1.45f;
    private float max_x = 1.45f;

    private Rigidbody2D body;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        body.gravityScale = 0;
    }

    void Start()
    {
        GameController.instance.currentBlock = this;
        moving = true;
        firstLanded = true;

        if (Random.Range(0, 2) > 0)
        {
            speed *= -1f;
        }

        GameController.instance.currentBlock = this;
    }

    private void Moving()
    {
        if (moving == true)
        {
            Vector3 vector = transform.position;
            vector.x += speed * Time.deltaTime;

            if (vector.x > max_x)
            {
                speed *= -1f;
            }
            else if (vector.x < min_x)
            {
                speed *= -1f;
            }

            transform.position = vector;
        }
    }

    void Update()
    {
        Moving();
    }

    public void FallingBlock()
    {
        moving = false;
        body.gravityScale = Random.Range(2, 4);
    }

    private void TouchGround()
    {
        if (firstLanded)
        {
            firstLanded = false;
        }

        if (gameover == true)
        {
            return;
        }
        else
        {
            ignoreCollision = true;
            ignoreTrigger = true;
            GameController.instance.CloneNewBlock();
            GameController.instance.MoveCamera();
        }
    }
    private void RestartGame()
    {
        GameController.instance.RestartGame();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (ignoreCollision)
        {
            return;
        }

        if (collision.gameObject.tag == "Ground")
        {
            ignoreCollision = true;
            Invoke("TouchGround", 1f);
            //TouchGround();
        }

        if (collision.gameObject.tag == "Block")
        {
            ignoreCollision = true;
            Invoke("TouchGround", 1f);
            //TouchGround();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (ignoreTrigger)
        {
            return;
        }

        if (collision.tag == "Ground")
        {
            if (!firstLanded)
            {
                CancelInvoke("TouchGround");
                gameover = true;
                ignoreTrigger = true;
                Invoke("RestartGame", 2f);
            }
            
        }
    }
}
