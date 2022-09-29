using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterControls : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField]
    GameObject TextObject;
    public bool enemyNear;
    [SerializeField]
    private Attack attack;
    [SerializeField]
    private bool attackcurrent;
    private float chargeCoolDown;
    private string Direction;
    private GameObject attacknode;
    private GameObject seenode;
    private void Awake()
    {
        TextObject = GameObject.Find("CountDown");
        rb = gameObject.GetComponent<Rigidbody2D>();
        attack = gameObject.transform.GetChild(1).gameObject.GetComponent<Attack>();
        attacknode = gameObject.transform.GetChild(1).gameObject;
        seenode = gameObject.transform.GetChild(0).gameObject;
        Direction = "right";
        Counter();
    }

    private void Counter()
    {
        if (chargeCoolDown > 0)
        {
            chargeCoolDown -= 1;
        }
        Invoke("Counter", 1f);
    }

    private void OnWest_Button()
    {
        if (enemyNear && Direction == "left"  && attackcurrent == false)
        {
            attackcurrent = true;
            StartCoroutine(Hit());
            
        }
        else if (chargeCoolDown == 0)
        {
            if (attacknode.transform.localPosition.x > 0)
            {
                attacknode.transform.localPosition *= -1;
                seenode.transform.localPosition *= -1;
            }
            rb.AddForce(-transform.right * 25f, ForceMode2D.Impulse);
            chargeCoolDown += 1f;
            Direction = "left";
            
        }


    }
    private void OnEast_Button()
    {
        if (enemyNear && Direction == "right" && attackcurrent == false)
        {
            attackcurrent = true;
            StartCoroutine(Hit());
        }
        else if (chargeCoolDown == 0)
        {
            if (attacknode.transform.localPosition.x < 0)
            {
                attacknode.transform.localPosition *= -1;
                seenode.transform.localPosition *= -1;
            }
            rb.AddForce(transform.right * 25f, ForceMode2D.Impulse);
            chargeCoolDown += 1f;
            Direction = "right";
            
        }
    }

    IEnumerator Hit()
    {
            yield return new WaitForSeconds(0.1f);
            attack.Attacking = true;
            yield return new WaitForSeconds(0.1f);
            attack.Attacking = false;
            yield return new WaitForSeconds(0.3f);
            attackcurrent = false;
    }
    
}
