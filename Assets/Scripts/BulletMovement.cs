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

            CreateExplosionEffect();
            UI_Manager.instance.ChechWinState();

            Destroy(collision.gameObject);//enemy
            Destroy(gameObject);//bullet
        }
    }

    GameObject exp;
    public void CreateExplosionEffect()
    {
        exp = Instantiate(GameManager.instance.explosionEffectPrefap, transform.position, Quaternion.identity);

        DestroyEnemyAndEffect();
    }

    private void DestroyEnemyAndEffect()
    {
        Destroy(exp, 0.6f);
    }
}
