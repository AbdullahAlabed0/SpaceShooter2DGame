using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayerScript : MonoBehaviour
{
   public float speed = 1.0f;
    public GameObject bulletPrefap;
    public GameObject bulletSpawnerPoint;
    void Update()
    {
        var move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        transform.position += move * speed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bulletPrefap, bulletSpawnerPoint.transform.position, Quaternion.identity);
        }
    }
}
