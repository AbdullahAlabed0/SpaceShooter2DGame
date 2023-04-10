using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScriptController : MonoBehaviour
{
    public GameObject container;//1
    public GameObject bulletPrefap;
    public GameObject bulletSpawnerPoint;

    // Start is called before the first frame update
    void Start()
    {
        float randomStart = Random.Range(1f,9f);//4
        float randomRate = Random.Range(3f, 8f);//6
        InvokeRepeating("CreateEnemyBullet", randomStart, randomRate);
    }


    void CreateEnemyBullet()
    {
        if (BulletContainerManager.isAllowed == false)
            return;

        // create a bullet
        //2 
        GameObject bullet = Instantiate(bulletPrefap, bulletSpawnerPoint.transform.position, Quaternion.identity);
        //3
        bullet.transform.SetParent(container.transform);

    }


   
}
