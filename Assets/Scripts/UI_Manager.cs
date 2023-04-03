using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{

    public GameObject GameOverUI;
    public Text playerLivesText;
    public int playerLivesCounter = 3;


    public static UI_Manager instance;



    private void Awake()
    {
        instance = this;
    }


    private void Start()
    {
        Time.timeScale = 1;
    }

    public void DecreasePlayerLives()
    {
        playerLivesCounter--;
        playerLivesText.text = playerLivesCounter.ToString();

        if (playerLivesCounter <= 0)
        {
            GameObject player = GameObject.FindWithTag("Player");
            Destroy(player);

            GameOverUI.SetActive(true);// make gameover ui active (visiable) on the screen
            Time.timeScale = 0;
        }
    }


    public void ReplayTheGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
