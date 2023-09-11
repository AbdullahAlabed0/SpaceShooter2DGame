using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public Ease ease;
    public float duration = 1;
    public GameObject PlayButton;
    // Start is called before the first frame update
    void Start()
    {
        DoAnimation_PlayButton();
    }


    public void DoAnimation_PlayButton()
    {
        PlayButton.transform.DOLocalMoveX(0, duration).SetEase(ease).OnComplete(() =>
        {
            Debug.Log("******************** ANIMATION COMPLETED *******************");
        });
       
    }



    public void GoToGamePlay()
    {
        SceneManager.LoadScene("Level1");
    }
}
