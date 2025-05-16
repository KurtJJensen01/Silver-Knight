using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public HealthBar healthBar;
    public GameObject gameOverMenu;

    private Animator animator;
    private Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        healthBar.SetHealth(StaticVariables.playerMaxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        StaticVariables.playerMaxHealth -= damage;
        Debug.Log("Player Health = " + StaticVariables.playerMaxHealth.ToString());
        healthBar.SetHealth(StaticVariables.playerMaxHealth);

        //play hurt animation
        animator.SetTrigger("Hurt");

        if (StaticVariables.playerMaxHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        gameOverMenu.SetActive(true);
        //Debug.Log("Player died!");
        rb.velocity = new Vector2(0, 0);

        //die animation
        animator.SetTrigger("Death");

        rb.bodyType = RigidbodyType2D.Static;
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<PlayerMovement>().enabled = false;
        GetComponent<Combat>().enabled = false;
        enabled = false;
    }
}
