using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinConScript : MonoBehaviour
{
    private Countdown countdown;
    private GameObject Victory;
    private GameObject Defeat;
    private bool You_Win;

    private void Awake()
    {
        countdown = GameObject.Find("CountDown").GetComponent<Countdown>();
        Victory = GameObject.Find("Victory");
        Defeat = GameObject.Find("GameOver");
        Victory.SetActive(false);
        Defeat.SetActive(false);
    }
    private void FixedUpdate()
    {
        if (countdown.Time <= 0 && You_Win == false)
        {
            Debug.Log("GameOver");
            Defeat.SetActive(true);
            LevelLoader.Instance.StartTransition(SceneManager.Levels.MENU, "Battery Depleted \n Try Again");
        }
        else if (countdown.KillCount >= 6 && countdown.Time != 0)
        {
            Debug.Log("Victory");
            Victory.SetActive(true);
            You_Win = true;
            LevelLoader.Instance.StartTransition(SceneManager.Levels.MENU, "Victory");
        }
    }

    
}
