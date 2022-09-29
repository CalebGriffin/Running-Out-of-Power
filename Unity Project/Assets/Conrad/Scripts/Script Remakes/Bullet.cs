using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Countdown countdown;

    private void Awake()
    {
        countdown = GameObject.Find("CountDown").GetComponent<Countdown>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("HitPlayer");
            countdown.Time -= 3;
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
        else
        {
            Debug.Log(collision.gameObject.name);
        }
    }


}


