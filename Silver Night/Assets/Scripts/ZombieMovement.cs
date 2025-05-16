using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class ZombieMovement : MonoBehaviour
{
    public float speed;
    public float pointA = -30;
    public float pointB = 74;

    private Enemy IsDead;
    private bool movingLeft;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        IsDead = GetComponent<Enemy>();
        rb = GetComponent<Rigidbody2D>();
        movingLeft = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(IsDead.isDead == false)
        {
            if(movingLeft==true)
            {
                transform.Translate(Vector2.left * speed * Time.deltaTime);
                if (transform.localPosition.x <= pointA)
                {
                    //Debug.Log("Right");
                    gameObject.transform.localScale = new Vector3(-1, 1, 1);
                    movingLeft = false;
                }
            }
            else
            {
                transform.Translate(Vector2.right * speed * Time.deltaTime);
                if (transform.localPosition.x >= pointB)
                {
                    //Debug.Log("Left");
                    gameObject.transform.localScale = new Vector3(1, 1, -1);
                    movingLeft = true;
                }

            }
        }
    }
}
