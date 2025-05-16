using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsEnemyDead : MonoBehaviour
{
    public GameObject Door;

    void Start()
    {
        Door.SetActive(false);
    }
    void Update()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies.Length == 0)
        {
            Door.SetActive(true);
        }
    }
}
