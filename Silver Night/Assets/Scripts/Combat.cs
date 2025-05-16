using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{

    public Transform frontAttackPoint;
    public Transform upAttackPoint;
    public Transform downAttackPoint;
    public float attackRange = 0.5f;
    public int attackDamage = 20;
    public float attackRate = 2f;
    public float power;

    private float nextAttackTime = 0f;
    private Animator animator;
    private Rigidbody2D rb;
    private LayerMask enemyLayers;

    void Start() 
    {
        enemyLayers = LayerMask.GetMask("Enemy");
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Time.time);
        if (Time.time >= nextAttackTime && !StaticVariables.isPaused)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) == true)
            {
                if (Input.GetKey(KeyCode.W) == true)
                {
                    animator.SetTrigger("upAttack");
                    Debug.Log("up swing");
                    Attack(upAttackPoint, 1);
                    nextAttackTime = Time.time + 1f / attackRate;
                }
                else if (Input.GetKey(KeyCode.S) == true)
                {
                    animator.SetTrigger("downAttack");
                    Debug.Log("down swing");
                    Attack(downAttackPoint, 2);
                    nextAttackTime = Time.time + 1f / attackRate;
                }
                else
                {
                    animator.SetTrigger("Attack");
                    Attack(frontAttackPoint, 3);
                    nextAttackTime = Time.time + 1f / attackRate;
                }
            }
        }
    }

    void Attack(Transform attack, int attackType)
    {
        //Dectect enemies in range of attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attack.position, attackRange, enemyLayers);

        //Damage them
        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("We hit " + enemy.name);
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
            if (attackType == 2)
            {
                rb.velocity = Vector2.up * power;
            }
        }
    }

    //void OnDrawGizmosSelected()
    //{
    //    if (attackPoint == null)
    //    {
    //        return;
    //    }
    //    Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    //}
}
