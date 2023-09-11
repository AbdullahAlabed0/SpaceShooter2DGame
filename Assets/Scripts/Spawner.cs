using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject EnemyPrefap;    
    public GameObject KeyPrefap;    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CreateMovingEnemy",0,1.5f);   
        InvokeRepeating("CreateMovingKey",0,5f);   
    }
    
    // Update is called once per frame
    void CreateMovingEnemy()
    {
        if (EnemyPrefap == null)
        {
            CancelInvoke("CreateMovingEnemy");
            return;
        }
        float x = Random.Range(-7f,7f);
        float y = Random.Range(6, 9);
        Vector3 vector3 = new Vector3(x,y,0);
        GameObject enemy = Instantiate(EnemyPrefap, vector3, Quaternion.identity);
        enemy.transform.SetParent(transform);
    } 
    
    void CreateMovingKey()
    {
        if (KeyPrefap == null)
        {
            CancelInvoke("CreateMovingKey");
            return;
        }

        float x = Random.Range(-7f, 7f);
        float y = Random.Range(6, 9);
        Vector3 vector3 = new Vector3(x,y,0);
        GameObject enemy = Instantiate(KeyPrefap, vector3, Quaternion.identity);
        enemy.transform.SetParent(transform);
    }
}
