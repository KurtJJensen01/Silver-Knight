using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoopDoor : MonoBehaviour
{
    public int index = 0;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StaticVariables.loop++;
            SceneManager.LoadScene(index);
        }
    }
}
