using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyScriptController : MonoBehaviour
{
    public float speed = 3;
    public bool isMoving;
    public bool stopShootingBullets;
    public GameObject bulletPrefap;
    public GameObject bulletSpawnerPoint;

    // Start is called before the first frame update
    void Start()
    {
        float randomStart = Random.Range(1f,9f);//4
        float randomRate = Random.Range(3f, 8f);//6
        InvokeRepeating("CreateEnemyBullet", randomStart, randomRate);
    }

    private void Update()
    {
        if (isMoving) 
        {
            transform.Translate(0,-1*speed*Time.deltaTime,0);
        }
    }
    void CreateEnemyBullet()
    {
        if (BulletContainerManager.isAllowed == false)
            return;
       
        if (stopShootingBullets)
            return;

        // create a bullet
        //2 
        GameObject bullet = Instantiate(bulletPrefap, bulletSpawnerPoint.transform.position, Quaternion.identity);
        //3
        bullet.transform.SetParent(GameManager.instance.BulletsContainer);

    }

   

}
