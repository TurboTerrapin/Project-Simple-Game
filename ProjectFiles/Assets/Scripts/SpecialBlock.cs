using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialBlock : MonoBehaviour
{

    public bool isCoins;

    public int numCoins = 1;

    public int upgradePrefab;

    public bool used;

    public GameObject[] prefabs; 

    void OnTriggerEnter2D(Collider2D collision)
    {

        Vector3 distance = gameObject.transform.position - collision.transform.position;
        Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();

        if (collision.gameObject.CompareTag("Player") && rb.velocity.y > 0 && distance.y > 0.5f && !used)
        {

            PlayerController pc = collision.gameObject.GetComponent<PlayerController>();
            

            if(isCoins)
            {
                pc.coins += numCoins;
            }
            else
            {
                Debug.Log("Spawning upgrade of type " + upgradePrefab);
                Instantiate(prefabs[upgradePrefab], transform);
                //Instantiate
            }


            rb.velocity = new Vector2(rb.velocity.x, 0);


            SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();

            sr.color = Color.gray;

            used = true;
            //Destroy(gameObject);
        }
    }
}
