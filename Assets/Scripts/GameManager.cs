using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject explosionEffectPrefap;

    public static GameManager instance;
    private void Awake()
    {
        instance = this;
    }



    GameObject exp;
    public void CreateExplosionEffect()
    {
        exp = Instantiate(explosionEffectPrefap, transform.position, Quaternion.identity);

        DestroyEnemyAndEffect();
    }

    private void DestroyEnemyAndEffect()
    {
        Destroy(exp, 0.6f);
    }
}
