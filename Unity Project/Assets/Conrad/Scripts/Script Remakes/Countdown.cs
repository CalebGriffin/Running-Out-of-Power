using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    public int Time = 30;
    public int KillCount;
    private GameObject Countdowntimer;

    private void Awake()
    {
        Time = 30;
        Countdowntimer = gameObject;
        Countingdown();
    }

    private void Countingdown()
    {
        if (Time > 0)
        {
            Time -= 1;
        }
        Countdowntimer.GetComponent<Text>().text = Time.ToString();
        Invoke("Countingdown", 1f);
    }
}
