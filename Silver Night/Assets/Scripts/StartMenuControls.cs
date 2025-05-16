using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenuControls : MonoBehaviour
{

    public GameObject controlsButton;
    public GameObject controlsMenu;
    public GameObject startMenu;
    public GameObject backButton;


    // Start is called before the first frame update
    void Start()
    {
        controlsMenu.SetActive(false);
    }

    public void ControlsButton()
    {
        startMenu.SetActive(false);
        controlsMenu.SetActive(true);
    }

    public void BackButton()
    {
        controlsMenu.SetActive(false);
        startMenu.SetActive(true);
    }
}
