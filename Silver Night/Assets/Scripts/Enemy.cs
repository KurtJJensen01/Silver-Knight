using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth;
    public bool isDead = false;

    private int currentHealth;
    private Collider2D Collider2D;
    private Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
        Collider2D = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        currentHealth -=damage;
        Debug.Log(currentHealth);

        //play hurt animation
        animator.SetTrigger("Hurt");

        if (currentHealth <=0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("enemy died!");
        isDead = true;

        //die animation
        animator.SetBool("Dead", true);

        Collider2D.enabled = false; //still need

        this.tag = "Untagged"; //tells the system that the enemy is dead

        this.enabled = false; //Disable the enemy
    }
}
