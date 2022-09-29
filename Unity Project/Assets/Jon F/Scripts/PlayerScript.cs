using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    public float Jump;
    public bool isJumping = false;
    public int maxHealth = 3;
    public int currentHealth;
    public HealthBar healthBar;
    public GameObject Restarter;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)&&isJumping==true)
        {
            rb.AddForce(Vector2.up * Jump);
            isJumping = false;
            anim.SetBool("IsJumping", true);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="Ground"&&isJumping==false)
        {
            isJumping = true;
            anim.SetBool("IsJumping", false);
        }
        if (collision.gameObject.tag=="Cactus")
        {
            anim.SetBool("Hurt", true);
            Destroy(collision.gameObject);
            StartCoroutine(Wait());
            TakeDamage(1);
        }        
    }
    public IEnumerator Wait()
    {
        yield return new WaitForSeconds(.5f);
        anim.SetBool("Hurt", false);
    }
    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);

        if(currentHealth == 0)
        {
            Time.timeScale = 0;
            Restarter.SetActive(true);
        }

    }
    /*public void Restart()
    {
        SceneManager.LoadScene("HCG");
        Time.timeScale = 1;
    }*/
}
