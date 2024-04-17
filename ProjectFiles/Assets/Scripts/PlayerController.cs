using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float horizontalInput;

    public float speed;
    public float jumpHeight;
    public float maxJumpHeight;
    public float currentJump;

    public float dragScale;

    private Rigidbody2D rb;

    public bool collidingWithGround;

    public GameObject spawnPoint;

    public int lives;
    public int coins;

    private Vector3 deform;

    private float timer;

    public bool isInvulnerable;


    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        coins = 0;
        deform = new Vector3(1, 1, 1);
        timer = 0;
        speed = 1;
    }

    // Update is called once per frame
    void Update()
    {
        //Gets user horizontal input
        horizontalInput = Input.GetAxis("Horizontal");
        
        Vector2 move = new Vector2(horizontalInput * 6 * Time.fixedDeltaTime * speed, 0);
        rb.velocity += move;


        if(Input.GetKey(KeyCode.Space) && collidingWithGround)
        {
            timer += Time.deltaTime;
            if(timer > 0.1f)
            {
                currentJump += 0.1f;
                if (currentJump > maxJumpHeight)
                {
                    currentJump = maxJumpHeight;
                }
                deform = new Vector3(1.5f, 0.5f, 1);
            }
        }
        if (Input.GetKeyUp(KeyCode.Space) && collidingWithGround)
        {
            
            rb.velocity += new Vector2(0, currentJump);
            
            currentJump = jumpHeight;
            collidingWithGround = false;

        }

        if(!collidingWithGround)
        {
            deform = new Vector3(0.5f, 1.5f, 1);
        }

        //transform.localScale = deform;

        transform.localScale = (transform.localScale * 0.95f) + (deform * 0.05f);
        //Changes the friction when the player doesn't want to move
        if (horizontalInput == 0f && collidingWithGround)
        {
            dragScale = 10;
        }
        else
        {
            dragScale = 0.5f;
        }

        //Kills the player if they're below a certain height
        if(transform.position.y < -5)
        {
            killPlayer();
        }
        //Add friction to the player
        rb.velocity -= new Vector2(rb.velocity.x * Time.fixedDeltaTime * dragScale, 0);
    }

    public void killPlayer()
    {
        gameObject.transform.position = spawnPoint.transform.position;
        isInvulnerable = true;
        lives -= 1;
        StartCoroutine(wait());
        isInvulnerable = false;

    }

    void OnTriggerStay2D(Collider2D collision)
    {
        deform = new Vector3(1, 1, 1);
        collidingWithGround = true;
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(0.3f);
    }

}
