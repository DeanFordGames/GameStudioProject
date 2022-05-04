using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    private GameObject menu;

    private void Awake()
    {
        menu = GameObject.Find("PauseMenu");
        menu.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && menu.activeSelf == false)
        {
            menu.SetActive(true);
            Time.timeScale = 0.0f;
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && menu.activeSelf == true)
        {
            menu.SetActive(false);
            Time.timeScale = 1.0f;
        }
    }
}
