using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndCollider : MonoBehaviour
{
    public string nextLevel;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0.1f, 0.1f, 0.1f);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            SceneManager.LoadScene(nextLevel);
        }
    }
}
