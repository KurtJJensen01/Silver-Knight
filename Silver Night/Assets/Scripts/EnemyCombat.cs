using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    public float attackRange = 0.5f;
    public int attackDamage;
    public float attackRate = 2f;

    private float nextAttackTime = 0f;
    private PlayerMovement playerMovement;
    private Enemy IsDead;
    private GameObject player;
    private float timer;

    void Start()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        IsDead = GetComponent<Enemy>();
        player = GameObject.FindGameObjectWithTag("Player");
        attackDamage *= StaticVariables.loop;
        timer = nextAttackTime;
    }

    public void Attack()
    {
        Debug.Log("Enemy hit " + player.name);
        playerMovement.KnockbackCounter = playerMovement.KnockbackTime;
        if (player.transform.position.x <= transform.position.x)
        {
            playerMovement.KnockedFromRight = true;
        }
        if (player.transform.position.x >= transform.position.x)
        {
            playerMovement.KnockedFromRight = false;
        }

        player.GetComponent<PlayerHealth>().TakeDamage(attackDamage);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            if (Time.time >= nextAttackTime && !StaticVariables.isPaused && IsDead.isDead == false)
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            timer -= Time.time;
            if (timer < 0 && Time.time >= nextAttackTime && !StaticVariables.isPaused && IsDead.isDead == false)
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
                timer = nextAttackTime;
                return;
            }
        }
    }

    //public void Update()
    //{
    //    Debug.Log(timer);
    //}
}
