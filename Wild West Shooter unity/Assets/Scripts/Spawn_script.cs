using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawn_script : MonoBehaviour
{
    // There must be a way to improve this wave code in a further build...

    [Header("Enemies")]
    [SerializeField] GameObject normalBandit;
    [SerializeField] GameObject tankBandit;
    [SerializeField] GameObject fastBandit;
    [SerializeField] GameObject zigzagBandit;

    [Header("Parallax")]
    [SerializeField] GameObject tree;
    [SerializeField] GameObject trail;
    [SerializeField] GameObject box;

    [Header("Boss")]
    [SerializeField] GameObject normalBoss;
    [SerializeField] GameObject tankBoss;
    [SerializeField] GameObject fastBoss;
    [SerializeField] GameObject zigzagBoss;

    int repeatTime = 0;
    float timer;


    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            StartCoroutine(Wave());
        }
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            StartCoroutine(Wave2());
        }
        
        InvokeRepeating("Items", 5f, 5f);
        InvokeRepeating("Trails", 2f, 2f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Wave()
    {
        do
        {
            Spawn(1, normalBandit, 50f, 0f, 6, 10, 3f, 5); // Wave 1
            yield return new WaitForSeconds(timer);
        }
        while (repeatTime > 0);

        do
        {
            Spawn(2, normalBandit, 50f, 0f, 6, 10, 3f, 2); // Wave 2
            yield return new WaitForSeconds(timer);
        }
        while (repeatTime > 0);

        do
        {
            Spawn(3, normalBandit, 50f, 0f, 6, 10, 3f, 3); // Wave 3
            yield return new WaitForSeconds(timer);
        }
        while (repeatTime > 0);
        
        do
        {
            Spawn(1, tankBandit, 25f, 0f, 22, 40, 5f, 3); // Wave 4
            yield return new WaitForSeconds(timer);
        }
        while (repeatTime > 0);
        
        do
        {
            Spawn(1, fastBandit, 80f, 0f, 4, 15, 3f, 4); // Wave 5
            yield return new WaitForSeconds(timer);
        }
        while (repeatTime > 0);

        do
        {
            Spawn(1, fastBandit, 80f, 0f, 4, 15, 1.5f, 4); // Wave 6
            yield return new WaitForSeconds(timer);
        }
        while (repeatTime > 0);

        do
        {
            Spawn(2, fastBandit, 80f, 0f, 4, 15, 3f, 4); // Wave 7
            yield return new WaitForSeconds(timer);
        }
        while (repeatTime > 0);

        do
        {
            Spawn(1, tankBandit, 25f, 0f, 22, 50, 5f, 3); // Wave 8
            yield return new WaitForSeconds(timer);
        }
        while (repeatTime > 0);

        do
        {
            Spawn(2, normalBandit, 65f, 0f, 8, 20, 3f, 5); // Wave 9
            yield return new WaitForSeconds(timer);
        }
        while (repeatTime > 0);

        do
        {
            Spawn(2, zigzagBandit, 40f, 50f, 8, 10, 3f, 2); // Wave 10
            yield return new WaitForSeconds(timer);
        }
        while (repeatTime > 0);
    }

    IEnumerator Wave2()
    {
        do
        {
            Spawn(1, normalBandit, 50f, 0f, 6, 10, 3f, 5); // Wave 1
            yield return new WaitForSeconds(timer);
        }
        while (repeatTime > 0);
    }
    void Spawn(int qtd, GameObject enemy, float spd, float vspd, int hp, int dmg, float time, int repeat)
    {
        if (repeatTime <= 0)
        {
            repeatTime = repeat;
            timer = time;
        }
        
        enemy.GetComponent<Bandit_script>().speed = spd;
        enemy.GetComponent<Bandit_script>().vSpeed = vspd;
        enemy.GetComponent<Bandit_script>().health = hp;
        enemy.GetComponent<Bandit_script>().steal = dmg;

        for (int i = 0; i < qtd; i++)
        {
            int side = Random.Range(0, 2);
            if (side == 0)
            {
                side = 1100;
            }
            else
            {
                side = -1100;
            }
            Instantiate(enemy, new Vector3(side, 80, Random.Range(-340, 400)), Quaternion.identity);
        }
        repeatTime--;
    }
    void Items()
    {
        int ySpace;
        GameObject item;
        int select = Random.Range(0, 4);
        if (select == 0)
        {
            item = box; ySpace = 30;
        }
        else
        {
            item = tree; ySpace = 140;
        }

        select = Random.Range(0, 4);
        if (select <= 1)
        {
            Instantiate(item, new Vector3(Random.Range(300, 800), ySpace, 600), Quaternion.identity);            
        } else
        {
            Instantiate(item, new Vector3(Random.Range(-300, -800), ySpace, 600), Quaternion.identity);
        }
    }
    void Trails()
    {
        Instantiate(trail, new Vector3(0, 0, 863), Quaternion.identity);
    }

}
