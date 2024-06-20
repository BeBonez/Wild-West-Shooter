using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEditor;
using static Boss_script;

public class Game_Manager_script : MonoBehaviour
{
    // This script handle game States (Win, lose) as well as the HUD

    [Header("HUD")]
    [SerializeField] GameObject VictoryPanel;
    [SerializeField] GameObject DefeatPanel;
    [SerializeField] GameObject PausePanel;
    [SerializeField] Slider progressBar;

    [Header("Gold")]
    [SerializeField] TMP_Text currentGold;
    public int gold;

    [Header("Power Ups")]
    [SerializeField] TMP_Text currentFakeGold;
    public int fakeGold;
    public float trainSpeed;

    [Header("Game States")]
    [SerializeField] GameObject boss;
    public int defeated;
    public int dangerLevel;

    // Game States
    Scene level;
    private int goal;
    private float timer;
    private int bossAlive = 0;

    private void Awake()
    {
        Time.timeScale = 1.0f;
    }

    // Start is called before the first frame update
    void Start()
    {
        level = SceneManager.GetActiveScene();

        // Level 1 goals
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            gold = 100;
            fakeGold = 0;
            defeated = 0;
            goal = 42;
        }

        // Level 2 goals
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            gold = 100;
            fakeGold = 0;
            defeated = 0;
            goal = 88;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // No less than 0
        if (fakeGold < 0)
        {
            fakeGold = 0;
        }
        if (gold < 0)
        {
            gold = 0;
        }

        // HUD
        currentGold.text = "Gold: " + gold;
        if (fakeGold > 0)
        {
            currentFakeGold.text = "Fake Gold: " + fakeGold;
        }
        else
        {
            currentFakeGold.text = " ";
        }

        if (Input.GetKeyDown(KeyCode.Escape) && defeated < goal)
        {
            Pause();
        }
 
        UpdateProgress();

        // If not lose, then win!
        Lose();
        if (level.buildIndex == 1) 
        {
            Win();
        }
        if (level.buildIndex == 2)
        {
            if (Input.GetKeyDown(KeyCode.F5))
            {
                SpawnBoss();
                bossAlive++;
            }

            if (defeated >= goal)
            {
                SpawnBoss();
                bossAlive++;
            }

            if (dangerLevel >= 4)
            {
                timer += Time.deltaTime;
                if (timer >= 0.5f)
                {
                    VictoryPanel.SetActive(true);
                    Time.timeScale = 0f;
                }
            }
        }    
    }

    public void SpawnBoss()
    {
        if (bossAlive == 0)
        {
            GameObject spawnedBoss;

            spawnedBoss = Instantiate(boss, new Vector3(700, 25, -1120), Quaternion.identity);
            spawnedBoss.GetComponent<Boss_script>().type = bossType.tank;

            spawnedBoss = Instantiate(boss, new Vector3(-700, 25, -1120), Quaternion.identity);
            spawnedBoss.GetComponent<Boss_script>().type = bossType.zigzag;

            spawnedBoss = Instantiate(boss, new Vector3(700, 25, -700), Quaternion.identity);
            spawnedBoss.GetComponent<Boss_script>().type = bossType.fast;

            spawnedBoss = Instantiate(boss, new Vector3(-700, 25, -700), Quaternion.identity);
            spawnedBoss.GetComponent<Boss_script>().type = bossType.normal;
        }
    }
    public void UpdateProgress()
    {
        progressBar.value = (float)defeated / goal;
    }
    private void Pause()
    {
        if (Time.timeScale == 1.0f)
        {
            Time.timeScale = 0f;
            PausePanel.SetActive(true);
        } else
        {
            Time.timeScale = 1.0f;
            PausePanel.SetActive(false);
        }
        
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
        if (defeated >= goal)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            for (int i = 0; i < enemies.Length; i++)
            {
                Destroy(enemies[i]);
            }

            timer += Time.deltaTime;
            if (timer >= 1.5f)
            {
                VictoryPanel.SetActive(true);
                Time.timeScale = 0f;
            }
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
}
