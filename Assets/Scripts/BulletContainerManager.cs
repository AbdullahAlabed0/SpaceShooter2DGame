using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletContainerManager : MonoBehaviour
{
    public int MaxNumberOfBullets = 3;
    public static bool isAllowed = true;
    // Update is called once per frame
    void Update()
    {

        if (transform.childCount < MaxNumberOfBullets)
        {
            // allow creat bullets
            isAllowed = true;
        }
        else
        {
            // disable create bullets
            // destroy
            isAllowed = false;
        }
    }
}
