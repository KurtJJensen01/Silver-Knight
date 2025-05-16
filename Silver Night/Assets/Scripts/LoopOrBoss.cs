using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopOrBoss : MonoBehaviour
{
    public GameObject Texts;

    private IsEnemyDead IsEnemyDead;

    // Start is called before the first frame update
    void Start()
    {
        Texts.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies.Length == 0)
        {
            Texts.SetActive(true);
        }
    }
}
