using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Manager_script : MonoBehaviour
{
    // This script handle game States (Win, lose) as well as the HUD

    [SerializeField] GameObject VictoryPanel;
    [SerializeField] GameObject DefeatPanel;

    public int gold;
    public int fakeGold;
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
            fakeGold = 0;
            defeated = 0;
            goal = 30;
        }
    }

    // Update is called once per frame
    void Update()
    {   
        if (fakeGold < 0)
        {
            fakeGold = 0;
        }
        if (gold < 0)
        {
            gold = 0;
        }
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

    public void TakeDamage(int amount)
    {
        if (fakeGold <= 0)
        {
            gold -= amount;
        } else
        {
            fakeGold -= amount;
        }
        
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }
}
