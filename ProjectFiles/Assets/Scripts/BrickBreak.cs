using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickBreak : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D collision)
    {

        Vector3 distance = gameObject.transform.position - collision.transform.position;

        Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();

        if (collision.gameObject.CompareTag("Player") && rb.velocity.y > 0 && distance.y > 0.5f)
        {

            PlayerController pc = collision.gameObject.GetComponent<PlayerController>();
            


            rb.velocity = new Vector2(rb.velocity.x, 0);
            if (Random.Range(0, 20) == 19)
            {
                pc.coins += 1;
            }
            Destroy(gameObject);
        }
    }

}
