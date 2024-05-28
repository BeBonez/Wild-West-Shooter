using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_script : MonoBehaviour
{
    public enum bossType { normal, tank, fast, zigzag }

    [SerializeField] GameObject manager;
    [SerializeField] GameObject goodParticles;

    [SerializeField] GameObject normalBandit;
    [SerializeField] GameObject tankBandit;
    [SerializeField] GameObject fastBandit;
    [SerializeField] GameObject zigzagBandit;

    int repeatTime = 0;
    float timer;

    public bossType type;
    public int health = 100;

    void Start()
    {
        // Get the manager reference
        manager = GameObject.FindGameObjectWithTag("Manager");

        // Enter from the top. Stop after a few seconds.

        // Start Attacking
        StartCoroutine(Wave());
    }
    IEnumerator Wave()
    {
        if ((int)type == 0)
        {
            yield return new WaitForSeconds(5);

            do
            {
                Spawn(1, normalBandit, 50f, 0f, 6, 10, 3f, 1);
                yield return new WaitForSeconds(timer);
            }
            while (manager.GetComponent<Game_Manager_script>().dangerLevel == 0);

            do
            {
                Spawn(1, normalBandit, 50f, 0f, 6, 10, 3f, 1);
                yield return new WaitForSeconds(timer);
            }
            while (manager.GetComponent<Game_Manager_script>().dangerLevel == 1);

            do
            {
                Spawn(1, normalBandit, 50f, 0f, 6, 10, 3f, 1);
                yield return new WaitForSeconds(timer);
            }
            while (manager.GetComponent<Game_Manager_script>().dangerLevel == 2);

            do
            {
                Spawn(1, normalBandit, 50f, 0f, 6, 10, 3f, 1);
                yield return new WaitForSeconds(timer);
            }
            while (manager.GetComponent<Game_Manager_script>().dangerLevel == 3);
        }

        if ((int)type == 1)
        {
            do
            {
                Spawn(1, tankBandit, 50f, 0f, 6, 10, 3f, 1);
                yield return new WaitForSeconds(timer);
            }
            while (manager.GetComponent<Game_Manager_script>().dangerLevel == 0);

            do
            {
                Spawn(1, tankBandit, 50f, 0f, 6, 10, 3f, 1);
                yield return new WaitForSeconds(timer);
            }
            while (manager.GetComponent<Game_Manager_script>().dangerLevel == 1);

            do
            {
                Spawn(1, tankBandit, 50f, 0f, 6, 10, 3f, 1);
                yield return new WaitForSeconds(timer);
            }
            while (manager.GetComponent<Game_Manager_script>().dangerLevel == 2);

            do
            {
                Spawn(1, tankBandit, 50f, 0f, 6, 10, 3f, 1);
                yield return new WaitForSeconds(timer);
            }
            while (manager.GetComponent<Game_Manager_script>().dangerLevel == 3);
        }

        if ((int)type == 2)
        {
            do
            {
                Spawn(1, fastBandit, 50f, 0f, 6, 10, 3f, 1);
                yield return new WaitForSeconds(timer);
            }
            while (manager.GetComponent<Game_Manager_script>().dangerLevel == 0);

            do
            {
                Spawn(1, fastBandit, 50f, 0f, 6, 10, 3f, 1);
                yield return new WaitForSeconds(timer);
            }
            while (manager.GetComponent<Game_Manager_script>().dangerLevel == 1);

            do
            {
                Spawn(1, fastBandit, 50f, 0f, 6, 10, 3f, 1);
                yield return new WaitForSeconds(timer);
            }
            while (manager.GetComponent<Game_Manager_script>().dangerLevel == 2);

            do
            {
                Spawn(1, fastBandit, 50f, 0f, 6, 10, 3f, 1);
                yield return new WaitForSeconds(timer);
            }
            while (manager.GetComponent<Game_Manager_script>().dangerLevel == 3);
        }

        if ((int)type == 3)
        {
            do
            {
                Spawn(1, zigzagBandit, 50f, 0f, 6, 10, 3f, 1);
                yield return new WaitForSeconds(timer);
            }
            while (manager.GetComponent<Game_Manager_script>().dangerLevel == 0);

            do
            {
                Spawn(1, zigzagBandit, 50f, 0f, 6, 10, 3f, 1);
                yield return new WaitForSeconds(timer);
            }
            while (manager.GetComponent<Game_Manager_script>().dangerLevel == 1);

            do
            {
                Spawn(1, zigzagBandit, 50f, 0f, 6, 10, 3f, 1);
                yield return new WaitForSeconds(timer);
            }
            while (manager.GetComponent<Game_Manager_script>().dangerLevel == 2);

            do
            {
                Spawn(1, zigzagBandit, 50f, 0f, 6, 10, 3f, 1);
                yield return new WaitForSeconds(timer);
            }
            while (manager.GetComponent<Game_Manager_script>().dangerLevel == 3);
        }
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
            Instantiate(enemy, gameObject.transform.position, Quaternion.identity);
        }
        repeatTime--;
    }

    void Update()
    {
        Health();
    }
    void Health()
    {
        if (health <= 0)
        {
            Audio_script.Instance.TocarSFX(4);
            manager.GetComponent<Game_Manager_script>().dangerLevel++;
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // When being hit by a bullet
        if (other.CompareTag("PianoBullet"))
        {
            Audio_script.Instance.TocarSFX(1);
            Instantiate(goodParticles, gameObject.transform.position, Quaternion.identity);
            health -= other.GetComponent<Bullet_script>().damage;
            Destroy(other.gameObject);
            Health();
        }

        if (other.CompareTag("Bullet"))
        {
            Audio_script.Instance.TocarSFX(2);
            Instantiate(goodParticles, gameObject.transform.position, Quaternion.identity);
            health -= other.GetComponent<Bullet_script>().damage;
            Destroy(other.gameObject);
            Health();
        }

        if (other.CompareTag("SlowingBullet"))
        {
            Audio_script.Instance.TocarSFX(3);
            Instantiate(goodParticles, gameObject.transform.position, Quaternion.identity);
            health -= other.GetComponent<Bullet_script>().damage;
            Destroy(other.gameObject);
            Health();
        }
    }
}
