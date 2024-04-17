using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    
    public GameObject player;
    public GameObject leftWall;
    public GameObject rightWall;


    private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 playerPos = player.transform.position;
        Vector3 pos = new Vector3(playerPos.x, playerPos.y, -10);

        //I got this code from Quiet-Pixel on the Unity Forums
        //https://forum.unity.com/threads/orthographic-camera-width.299243/
        //Used the code to keep the player from seeing the wall on the left side of the screen
        float screenAspect = (float)Screen.width / (float)Screen.height;
        float camHalfHeight = cam.orthographicSize;
        float camHalfWidth = screenAspect * camHalfHeight;
        float camWidth = camHalfWidth;

        //This is my own
        if(playerPos.x < leftWall.gameObject.transform.position.x + camWidth + 1)
        {
            pos.x = leftWall.gameObject.transform.position.x + camWidth + 1;
        }
        if(playerPos.x > rightWall.gameObject.transform.position.x - camWidth - 1)
        {
            pos.x = rightWall.gameObject.transform.position.x - camWidth - 1;
        }
        gameObject.transform.position = pos;
    }
}
