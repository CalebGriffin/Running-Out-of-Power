using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Look : MonoBehaviour
{
    private CharacterControls player;

    private void Awake()
    {
        player = gameObject.transform.parent.GetComponent<CharacterControls>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            StartCoroutine(FoundEnemy());
        }
    }
    IEnumerator FoundEnemy()
    {
        yield return new WaitForSeconds(0.05f);
        gameObject.transform.parent.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        player.enemyNear = true;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            StartCoroutine(LostEnemy());
        }
    }
    IEnumerator LostEnemy()
    {
        yield return new WaitForSeconds(0.05f);
        player.enemyNear = false;
    }
}
