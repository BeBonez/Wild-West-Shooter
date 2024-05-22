using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawn_script : MonoBehaviour
{
    // There must be a way to improve this wave code in a further build...

    // [SerializeField] float levelProgression;

    [SerializeField] GameObject bandit;
    [SerializeField] GameObject tree;
    [SerializeField] GameObject trail;
    [SerializeField] GameObject box;

    int repeatTime = 0;
    float timer;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Wave());
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
            Spawn(1, bandit, 50f, 0f, 6, 25, 3f, 5);
            yield return new WaitForSeconds(timer);
        }
        while (repeatTime > 0);

        do
        {
            Spawn(2, bandit, 50f, 0f, 6, 25, 3f, 5);
            yield return new WaitForSeconds(timer);
        }
        while (repeatTime > 0);

        do
        {
            Spawn(3, bandit, 50f, 0f, 6, 25, 3f, 5);
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
            Instantiate(enemy, new Vector3(side, 5, Random.Range(-340, 400)), Quaternion.identity);
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
