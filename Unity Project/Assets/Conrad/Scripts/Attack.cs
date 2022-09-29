using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField]
    public bool Attacking = false;
    [SerializeField]
    private bool ReadyToAttack = false;
    private GameObject ColObj;
    [SerializeField]
    private GameObject Player;
    [SerializeField]
    private bool damageCoolDown = false;
    public bool DamageCoolDown
    {
        get
        {
            return damageCoolDown;
        }
        set
        {
            damageCoolDown = value;
            StartCoroutine(DamageCoolingDown());
        }
    }

    IEnumerator DamageCoolingDown()
    {
        if (DamageCoolDown == true)
        {
            yield return new WaitForSeconds(0.5f);
            DamageCoolDown = false;
        }
        
    }

    private void FixedUpdate()
    {
        if (Attacking == true && ReadyToAttack == true && DamageCoolDown == false)
        {
            Vector3 StandardLauch = ColObj.transform.position - Player.transform.position + new Vector3(0f,2f,0f);
            Vector3 FinalLauch = ColObj.transform.position - Player.transform.position + new Vector3(0f, 2f, 0f);
            Rigidbody2D EnemyCol = ColObj.GetComponent<Rigidbody2D>();
            if (ColObj.GetComponent<EnemyV2>().Health == 1)
            {
                EnemyCol.AddForce(FinalLauch * 1000f);
                ColObj.GetComponent<EnemyV2>().Health -= 1;
            }
            else if (ColObj.GetComponent<EnemyV2>().Health == 2)
            {
                EnemyCol.AddForce(FinalLauch * 700f);
                ColObj.GetComponent<EnemyV2>().Health -= 1;
            }
            else
            {
                EnemyCol.AddForce(StandardLauch * 400f);
                ColObj.GetComponent<EnemyV2>().Health -= 1;
            }
            DamageCoolDown = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        
        if(collision.gameObject.tag == "Enemy" && DamageCoolDown == false)
        {
            ReadyToAttack = true;
            ColObj = collision.gameObject;  
        }
        else if (collision.gameObject.tag !="Enemy")
        {
            ReadyToAttack = false;
            //Debug.Log(collision.name);
        }
        if(collision.gameObject.tag == "Bullet" && DamageCoolDown == false)
        {
            Destroy(collision.gameObject);
            Debug.Log("BlockBullet"); 
        }
    }
}
