using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    public float Jump;
    public bool isJumping = false;
    public int maxHealth = 3;
    public int currentHealth;
    public int currentScore;
    public HealthBar healthBar;
    public Text scoreText;
    //public GameObject Restarter;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Space)&&isJumping==true)
        {
            rb.AddForce(Vector2.up * Jump);
            isJumping = false;
            //anim.SetBool("IsJumping", true);
        }*/
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="Ground"&&isJumping==false)
        {
            isJumping = true;
            //anim.SetBool("IsJumping", false);
        }
        if (collision.gameObject.tag=="Enemy")
        {
            //anim.SetBool("Hurt", true);
            Destroy(collision.gameObject);
            //StartCoroutine(Wait());
            TakeDamage(1);
        }
        if (collision.gameObject.tag == "Core")
        {
            Destroy(collision.gameObject);
            IncreaseScore(1);
        }
    }
    /*public IEnumerator Wait()
    {
        yield return new WaitForSeconds(.5f);
        anim.SetBool("Hurt", false);
    }*/
    void IncreaseScore (int score)
    {
        currentScore += score;
        scoreText.text = $"- {currentScore}";

        if (currentScore == 25)
        {
            LevelLoader.Instance.StartTransition(SceneManager.Levels.MENU, $"Your skill earned you {currentScore} points! Amazing!!");
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);

        if(currentHealth == 0)
        {
            //Time.timeScale = 0;
            //Restarter.SetActive(true);
            LevelLoader.Instance.StartTransition(SceneManager.Levels.MENU, $"Your score was {currentScore}");
        }

    }
    private void OnRight_Trigger()
    {
        // This will run when the right trigger is pressed
        //if(Physics2D.OverlapCircleAll(transform.GetChild(0).position, 2, LayerMask.GetMask("Blocks")))
        
    }
    private void OnSouth_Button()
    {
        // This will run when the south button is pressed
        rb.AddForce(Vector2.up * Jump);
        //isJumping = false;
        //anim.SetBool("IsJumping", true);

    }

    /*public void Restart()
    {
        SceneManager.LoadScene("HCG");
        Time.timeScale = 1;
    }*/
}
