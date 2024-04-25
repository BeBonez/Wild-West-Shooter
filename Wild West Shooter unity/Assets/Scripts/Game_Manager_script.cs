using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Manager_script : MonoBehaviour
{
    // This script handle game States (which Scene && currency)
    // Another script for UI
    // Another script handle game Events = Spawn

    [SerializeField] GameObject VictoryPanel;
    [SerializeField] GameObject DefeatPanel;

    public int gold;
    public int defeated;
    private int goal;

    private void Awake()
    {
        Time.timeScale = 1.0f;
    }

    // Start is called before the first frame update
    void Start()
    {

        if (SceneManager.GetActiveScene().name == "Level1")
        {
            gold = 100;
            defeated = 0;
            goal = 30;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Lose();
        Win();
    }

    void Lose()
    {
        if (gold <= 0)
        {
            DefeatPanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }
    void Win()
    {
        if (defeated == goal)
        {
            VictoryPanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }
}
