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
    public int playerLivesCounter = 3;


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

    internal void ChechWinState()
    {

        if (destroied_enimes >= max_enimes-1)
        {
            Debug.Log("******************* WIN STATE ******************** ");

            GameWinUI.transform.DOLocalMove(Vector3.zero, 1).SetEase(Ease.OutBack).OnComplete(() => {
                Time.timeScale = 0;
            });
        }
        destroied_enimes++;

    }
}
