using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class UI_script : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            SceneManager.LoadScene(0);
        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            SceneManager.LoadScene(1);
        }
        //if (Input.GetKeyDown(KeyCode.F3))
        //{
        //    SceneManager.LoadScene(2);
        //}
    }
    public void Play() {
        Audio_script.Instance.TocarSFX(0);
        SceneManager.LoadScene(1);
    }
    public void Exit()
    {
        Audio_script.Instance.TocarSFX(0);
        Application.Quit();
    }
    public void MainMenu()
    {
        Audio_script.Instance.TocarSFX(0);
        SceneManager.LoadScene(0);
    }
}
