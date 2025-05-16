using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallThru : MonoBehaviour
{
    private readonly float radius = 0.3f;
    private PlatformEffector2D effector;
    private LayerMask platformLayer;
    private Transform pos;
    private bool platformed = false;


    // Start is called before the first frame update
    void Start()
    {
        effector = GetComponent<PlatformEffector2D>();
        platformLayer = LayerMask.GetMask("Platform");
        pos = GameObject.FindGameObjectWithTag("Feet").transform;
    }

    // Update is called once per frame
    void Update()
    {
        platformed = Physics2D.OverlapCircle(pos.position, radius, platformLayer);
        if(platformed && Input.GetKeyDown(KeyCode.S))
        {
            StartCoroutine(Order());
        }
    }

    IEnumerator Order()
    {
        effector.rotationalOffset = 180f;
        yield return new WaitForSeconds(0.5f);
        effector.rotationalOffset = 0f;
    }
}
