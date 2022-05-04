using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Unpause()
    {
        gameObject.transform.parent.gameObject.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void ExitToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
