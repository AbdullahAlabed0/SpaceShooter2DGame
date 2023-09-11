using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class UI_Manager : MonoBehaviour
{

    public GameObject GameOverUI, GameWinUI;
    public Text playerLivesText;
    public Text enemyLivesText;
    public Text keysText;
    public int playerLivesCounter = 3;
    private int keyVal;
    public int keysCounter 
    { 
        get 
        { 
            return keyVal; 
        } 
        set 
        { 
            keyVal = value;
            keysText.text = keyVal.ToString();
        } 
    }


    public int max_enimes;
    public int destroied_enimes;

    public static UI_Manager instance;



    private void Awake()
    {
        instance = this;
    }


    private void Start()
    {
        Time.timeScale = 1;

        EnemyScriptController[] enemies = GameObject.FindObjectsOfType<EnemyScriptController>();
       
        max_enimes = enemies.Length;
        if (max_enimes <= 1) 
        {
            max_enimes = 5;
        }
        keysCounter = 0;
        enemyLivesText.text= max_enimes.ToString();
    }

    public void DecreasePlayerLives()
    {
        playerLivesCounter--;
        playerLivesText.text = playerLivesCounter.ToString();

        if (playerLivesCounter <= 0)
        {
            GameObject player = GameObject.FindWithTag("Player");
            Destroy(player);

            //GameOverUI.SetActive(true);// make gameover ui active (visiable) on the screen
            GameOverUI.transform.DOLocalMove(Vector3.zero, 1).SetEase(Ease.OutBack).OnComplete(() => {
                Time.timeScale = 0;
            });
            
        }
    }


    public void ReplayTheGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void LoadLevel2()
    {
        SceneManager.LoadScene("Level2");
    }
    internal void ChechWinState()
    {
        Debug.Log("******************* WIN STATE ******************** ");
        max_enimes--;

        if (max_enimes <= 0)
        {

            GameWinUI.transform.DOLocalMove(Vector3.zero, 1).SetEase(Ease.OutBack).OnComplete(() =>
            {
                Time.timeScale = 0;
            });
        }

        enemyLivesText.text = max_enimes.ToString();

    }
}
