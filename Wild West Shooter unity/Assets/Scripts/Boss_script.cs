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

    [SerializeField] float enterTimer = 0;

    int repeatTime = 0;
    float timer;

    public bossType type;
    public int health = 100;

    void Start()
    {
        // Get the manager reference
        manager = GameObject.FindGameObjectWithTag("Manager");

        // Start Attacking
        StartCoroutine(Attack());
    }

    IEnumerator Attack()
    {
        yield return new WaitForSeconds(2);

        if ((int)type == 0)
        {
            do
            {
                Spawn(1, normalBandit, 25f, 45f, 5, 10, 6f, 1);
                yield return new WaitForSeconds(timer);
            }
            while (manager.GetComponent<Game_Manager_script>().dangerLevel == 0);

            do
            {
                Spawn(1, normalBandit, 45f, 65f, 7, 20, 6f, 1);
                yield return new WaitForSeconds(timer);
            }
            while (manager.GetComponent<Game_Manager_script>().dangerLevel == 1);

            do
            {
                Spawn(1, normalBandit, 45f, 85f, 7, 20, 4f, 1);
                yield return new WaitForSeconds(timer);
            }
            while (manager.GetComponent<Game_Manager_script>().dangerLevel == 2);

            do
            {
                Spawn(1, normalBandit, 45f, 85f, 9, 30, 2f, 1);
                yield return new WaitForSeconds(timer);
            }
            while (manager.GetComponent<Game_Manager_script>().dangerLevel == 3);
        }

        if ((int)type == 1)
        {
            do
            {
                Spawn(1, tankBandit, 30f, 45f, 12, 25, 10f, 1);
                yield return new WaitForSeconds(timer);
            }
            while (manager.GetComponent<Game_Manager_script>().dangerLevel == 0);

            do
            {
                Spawn(1, tankBandit, 30f, 45f, 16, 25, 10f, 1);
                yield return new WaitForSeconds(timer);
            }
            while (manager.GetComponent<Game_Manager_script>().dangerLevel == 1);

            do
            {
                Spawn(1, tankBandit, 30f, 90f, 20, 25, 8f, 1);
                yield return new WaitForSeconds(timer);
            }
            while (manager.GetComponent<Game_Manager_script>().dangerLevel == 2);

            do
            {
                Spawn(1, tankBandit, 50f, 90f, 25, 40, 5f, 1);
                yield return new WaitForSeconds(timer);
            }
            while (manager.GetComponent<Game_Manager_script>().dangerLevel == 3);
        }

        if ((int)type == 2)
        {
            do
            {
                Spawn(1, fastBandit, 50f, 50f, 2, 5, 8f, 1);
                yield return new WaitForSeconds(timer);
            }
            while (manager.GetComponent<Game_Manager_script>().dangerLevel == 0);

            do
            {
                Spawn(1, fastBandit, 70f, 50f, 2, 5, 8f, 1);
                yield return new WaitForSeconds(timer);
            }
            while (manager.GetComponent<Game_Manager_script>().dangerLevel == 1);

            do
            {
                Spawn(1, fastBandit, 70f, 50f, 2, 10, 4f, 1);
                yield return new WaitForSeconds(timer);
            }
            while (manager.GetComponent<Game_Manager_script>().dangerLevel == 2);

            do
            {
                Spawn(1, fastBandit, 70f, 100f, 5, 15, 2f, 1);
                yield return new WaitForSeconds(timer);
            }
            while (manager.GetComponent<Game_Manager_script>().dangerLevel == 3);
        }

        if ((int)type == 3)
        {
            do
            {
                Spawn(1, zigzagBandit, 30f, 70f, 4, 10, 7f, 1);
                yield return new WaitForSeconds(timer);
            }
            while (manager.GetComponent<Game_Manager_script>().dangerLevel == 0);

            do
            {
                Spawn(1, zigzagBandit, 30f, 110f, 4, 10, 7f, 1);
                yield return new WaitForSeconds(timer);
            }
            while (manager.GetComponent<Game_Manager_script>().dangerLevel == 1);

            do
            {
                Spawn(1, zigzagBandit, 30f, 110f, 6, 15, 5f, 1);
                yield return new WaitForSeconds(timer);
            }
            while (manager.GetComponent<Game_Manager_script>().dangerLevel == 2);

            do
            {
                Spawn(1, zigzagBandit, 50f, 110f, 6, 25, 3f, 1);
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
        if (enterTimer < 2)
        {
            // Enter from the top. Stop after a few seconds.
            transform.Translate(Vector3.forward * Time.deltaTime * 400);
            enterTimer += Time.deltaTime;
        }
        Health();
    }
    void Health()
    {
        if (health <= 0)
        {
            GameObject[] otherBosses = GameObject.FindGameObjectsWithTag("boss");
            for (int i = 0; i < otherBosses.Length; i++)
            {
                otherBosses[i].GetComponent<Boss_script>().health += 30;
            }
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
