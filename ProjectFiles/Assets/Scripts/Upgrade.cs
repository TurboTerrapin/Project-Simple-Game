using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : MonoBehaviour
{
    private PlayerController player;
    public int upgradeType;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            player = collision.gameObject.GetComponent<PlayerController>();
            switch (upgradeType)
            {
                case 0:
                    player.lives += 5;
                    break;

                case 1:
                    player.speed *= 1.2f;
                    break;
                
                case 2:
                    player.jumpHeight += 2;
                    player.maxJumpHeight += 2;
                    break;
            }
            Destroy(gameObject);
        }
    }
}
