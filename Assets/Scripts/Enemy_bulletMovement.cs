using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_bulletMovement : MonoBehaviour
{
    public float speed = 4;

    private void Start()
    {
        float randomDestroy = Random.Range(3f, 5f);//4

        Destroy(gameObject, randomDestroy);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, -1 * speed * Time.deltaTime, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);//bullet
            UI_Manager.instance.DecreasePlayerLives();
        }
    }
}
