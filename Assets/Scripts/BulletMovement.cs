using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public float speed = 4;

    private void Start()
    {
        Destroy(gameObject, 15);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0,speed*Time.deltaTime,0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
