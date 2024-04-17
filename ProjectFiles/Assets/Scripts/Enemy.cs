using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Rigidbody2D rb;

    public int direction;

    private float timer;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        timer = 0;
    }

    void Update()
    {
        moveEnemy();
        timer += Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();


        if (rb.velocity.y < 0)
        {
            killEnemy(rb);
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerController pc = collision.gameObject.GetComponent<PlayerController>();
            pc.killPlayer();
        }

        //I tried to solve enemy thrashing issue with the timer but it didn't work
        //I wanted the enemies to only turn when they hit another enemy or a wall
        if (timer > 0.5f && (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Enemy")))
        {
            if(rb.velocity.x > 0)
            {
                direction = -1;
            }
            if(rb.velocity.x < 0)
            {
                direction = 1;
            }
            timer = 0;
        }
    }

    void moveEnemy()
    {
        Vector2 move = new Vector2(direction * 300 * Time.fixedDeltaTime, rb.velocity.y);

        rb.velocity = move;
    }


    void killEnemy(Rigidbody2D rb)
    {
        transform.localScale = new Vector3(1, 0.6f, 1);
        rb.velocity = new Vector2(rb.velocity.x, 4);
        StartCoroutine(wait());
        Destroy(gameObject);
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(0.5f);
    }


}
