using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class UI_script : MonoBehaviour
{
    [SerializeField] GameObject mainButtons;
    [SerializeField] GameObject rulesStuff;
    [SerializeField] GameObject audioStuff;

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
        if (Input.GetKeyDown(KeyCode.F3))
        {
            SceneManager.LoadScene(2);
        }
    }
    public void Play() {
        Audio_script.Instance.TocarSFX(0);
        SceneManager.LoadScene(1);
    }

    public void Retry()
    {
        Audio_script.Instance.TocarSFX(0);
        Scene current_scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(current_scene.buildIndex);
    }

    public void Next()
    {
        Audio_script.Instance.TocarSFX(0);
        SceneManager.LoadScene(2);
    }

    public void Options()
    {
        Audio_script.Instance.TocarSFX(0);
        mainButtons.SetActive(false);
        audioStuff.SetActive(true);
    }

    public void Rules()
    {
        Audio_script.Instance.TocarSFX(0);
        mainButtons.SetActive(false);
        rulesStuff.SetActive(true);
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
