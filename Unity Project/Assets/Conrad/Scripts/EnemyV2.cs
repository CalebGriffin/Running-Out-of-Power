using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyV2 : MonoBehaviour
{
    private bool Damaged = false;
    private LayerMask NonRayLayer;
    private EnemySpawner enemySpawner;
    private int health = 3;
    private GameObject Player;
    private Countdown countdown;
    private Rigidbody2D rb;
    Vector3 relativedirectionvec;
    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private bool bulletCooldown;
    private Vector3 Firingpoint;
    private Vector2 RayDirection;
    private AudioSource Audio;
    [SerializeField]
    public AudioClip Sound;
    public int Health
    {
        get
        {
            return health;
        }
        set
        {
            health = value;
            StartCoroutine(CheckHealth());
        }
    }

    IEnumerator CheckHealth()
    {
        
        if(health == 0)
        {
            Damaged = true;
            countdown.Time += 10;
            countdown.KillCount += 1;
            yield return new WaitForSeconds(2f);
            enemySpawner.NoOfEnemies -= 1;
            Destroy(gameObject);
        }
        else if(health > 0)
        {
            Damaged = true;
            yield return new WaitForSeconds(2f);
            Damaged = false;
        }
    }
    private bool MoveL;
    private bool MoveR;

    private void Awake()
    {
        Audio = GetComponent<AudioSource>();
        NonRayLayer = LayerMask.GetMask("Default") | LayerMask.GetMask("EnemyBlocker");
        Player = GameObject.Find("Character");
        enemySpawner = GameObject.Find("EnemySpawner").GetComponent<EnemySpawner>();
        countdown = GameObject.Find("CountDown").GetComponent<Countdown>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        DirectionDecided();
        BulletCooling();
    }

    private void FixedUpdate()
    {
        relativedirectionvec = gameObject.transform.position - Player.transform.position;
        float relativedirection = relativedirectionvec.x;

        if (relativedirection > 0)
        {
            MoveL = true;
            MoveR = false;
        }
        else if (relativedirection < 0)
        {
            MoveR = true;
            MoveL = false;
        }
        if (Damaged == false)
        {
            AimnFire();
        }


    }

    private void DirectionDecided()
    {
        if (MoveL == true && relativedirectionvec.magnitude > 3)
        {
            rb.AddForce(Vector2.left * 800f);
        }
        else if (MoveR == true && relativedirectionvec.magnitude > 3)
        {
            rb.AddForce(-Vector2.left * 800f);
        }
        Invoke("DirectionDecided",1f);
    }

    private void AimnFire()
    {
        if (MoveL == true) 
        { 
            Firingpoint = gameObject.transform.InverseTransformPoint(-2f, 0, 0);
            RayDirection = -gameObject.transform.right * 10f;
        }
        if (MoveR == true) 
        { 
            Firingpoint = gameObject.transform.InverseTransformPoint(-2f, 0, 0);
            RayDirection = gameObject.transform.right * 10f;
        }


        if (!(!MoveL && !MoveR))
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, RayDirection, 100f, NonRayLayer);
            Debug.DrawRay(transform.position, RayDirection, Color.red, 0.2f);
            //Debug.Log(gameObject.transform.InverseTransformPoint(-2f, 0, 0));

            if (MoveL == true) { Firingpoint = gameObject.transform.TransformPoint(-1f, -0.25f, 0); }
            if (MoveR == true) { Firingpoint = gameObject.transform.TransformPoint(1f, -0.25f, 0); }
            if (hit.collider != null)
            {
                //Debug.Log(MoveL);
                //Debug.Log(MoveR);
                if (hit.collider.gameObject.tag == "Player" && bulletCooldown == false)
                {
                    Debug.Log(hit.collider.gameObject.name);
                    GameObject Bullet = Instantiate(bullet, Firingpoint, Quaternion.identity);
                    if (MoveL == true) { Bullet.GetComponent<Rigidbody2D>().AddForce(-Vector2.right * 2000f); }
                    if (MoveR == true) { Bullet.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 2000f); }
                    bulletCooldown = true;
                    Audio.PlayOneShot(Sound);
                }
                else if (hit.collider.gameObject.tag != "Player" && hit.collider.gameObject != null)
                {
                    Debug.Log(hit.collider.gameObject.name);
                }
            }
        }
        
    }

    private void BulletCooling()
    {
        if (bulletCooldown == true)
        {
            bulletCooldown = false;
        }
        Invoke("BulletCooling", 3f);
    }
}
