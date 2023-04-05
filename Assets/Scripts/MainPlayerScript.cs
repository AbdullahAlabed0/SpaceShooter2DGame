using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayerScript : MonoBehaviour
{
    public float speed = 1.0f;
    public GameObject bulletPrefap;
    public GameObject bulletSpawnerPoint;

    public Transform leftBoarder, rightBoarder;

    void Update()
    {
        // on click on right arrow// the player moves to the right
        if (Input.GetAxis("Horizontal") >= 0.1f)
        {
            // enable movement until the spaceship reach the right boarder
            if (transform.position.x <= rightBoarder.position.x)
            {
                moveSpaceship();
            }
            else
            {
                // reenable movement to the left only 
                if (Input.GetAxis("Horizontal") <= -0.1f)
                {
                    moveSpaceship();
                }
            }
        }
        // click on left arrow
        else if (Input.GetAxis("Horizontal") <= -0.1f)
        {

            // enable movement until the spaceship reach the left boarder
            if (transform.position.x >= leftBoarder.position.x)
            {
                moveSpaceship();
            }
            else
            {
                // reenable movement to the right only 
                if (Input.GetAxis("Horizontal") >= 0.1f)
                {
                    moveSpaceship();
                }
            }
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bulletPrefap, bulletSpawnerPoint.transform.position, Quaternion.identity);
        }

      
    }


    void moveSpaceship()
    {
        var move = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        transform.position += move * speed * Time.deltaTime;
    }
}
