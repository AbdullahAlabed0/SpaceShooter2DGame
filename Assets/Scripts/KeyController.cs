using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    public float speed = 3;

    private void Update()
    {
         
            transform.Translate(0, -1 * speed * Time.deltaTime, 0);
        
    }
}
