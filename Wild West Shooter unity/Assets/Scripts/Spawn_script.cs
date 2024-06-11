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

    IEnumerator Wave() // This level contains waves that start very easy and amp up as it teaches all of the main concepts and with smooth curve contaning some downtime and a challenge for each enemy type.
    {
        do
        {
            Spawn(1, normalBandit, 45f, 0f, 6, 10, 3f, 5); // Wave 1 - Show enemies can come both sides.
            yield return new WaitForSeconds(timer);
        }
        while (repeatTime > 0);

        do
        {
            Spawn(2, normalBandit, 40f, 0f, 6, 10, 3f, 2); // Wave 2 - show multiple enemies can spawm.
            yield return new WaitForSeconds(timer);
        }
        while (repeatTime > 0);
        
        do
        {
            Spawn(1, tankBandit, 25f, 0f, 22, 30, 3f, 3); // Wave 3 - show there are different types of enemies, introducing the tank.
            yield return new WaitForSeconds(timer);
        }
        while (repeatTime > 0);

        yield return new WaitForSeconds(3); // Gives some downtime so the fast enemies don't overwhelm the player.

        do
        {
            Spawn(1, fastBandit, 80f, 0f, 4, 15, 3f, 4); // Wave 4 - Introduces the fast enemy.
            yield return new WaitForSeconds(timer);
        }
        while (repeatTime > 0);

        do
        {
            Spawn(1, fastBandit, 80f, 0f, 4, 15, 1.5f, 4); // Wave 5 - Introduces the concept that waves can come quicker, challenging the player.
            yield return new WaitForSeconds(timer);
        }
        while (repeatTime > 0);

        do
        {
            Spawn(1, tankBandit, 35f, 0f, 42, 50, 5f, 3); // Wave 6 - develops a neat little challenge: quicker and stronger tanky enemies.
            yield return new WaitForSeconds(timer);
        }
        while (repeatTime > 0);

        do
        {
            Spawn(1, normalBandit, 60f, 0f, 8, 20, 3f, 5); // Wave 7 - gives some downtime with a relatively easier normal wave, also introduces the concept that enemies can have varying stats.
            yield return new WaitForSeconds(timer);
        }
        while (repeatTime > 0);

        do
        {
            Spawn(2, zigzagBandit, 40f, 50f, 8, 10, 3f, 4); // Wave 8 - Introduces the last enemy: zig zag, which is harder to aim at.
            yield return new WaitForSeconds(timer);
        }
        while (repeatTime > 0);

        do
        {
            Spawn(1, zigzagBandit, 30f, 200f, 8, 20, 1.5f, 3); // Wave 9 - Develops a challenge by adding tons of vertical speed to the enemies.
            yield return new WaitForSeconds(timer);
        }
        while (repeatTime > 0);

        do
        {
            Spawn(1, tankBandit, 30f, 25f, 18, 30, 1f, 3); // Wave 10 - Shows that the zigzag variation is related to it's vertical speed and no stat is limited to a single enemy.
            yield return new WaitForSeconds(timer);
        }
        while (repeatTime > 0);
    }

    IEnumerator Wave2() // This level challenges the player by adding vertical speed to all enemies and developing new challenges though stat combos as well as finishing with an interesting boss battle.
    {
        do
        {
            Spawn(3, normalBandit, 45f, 15f, 8, 5, 4f, 3); // Wave 1 - Start with buffed normals. Introduce having 3 enemies at a time.
            yield return new WaitForSeconds(timer);
        }
        while (repeatTime > 0);

        do
        {
            Spawn(1, normalBandit, 30f, 20f, 8, 5, 0.5f, 10); // Wave 2 - swarms the player with normals, giving a little scare but not being actually too hard
            yield return new WaitForSeconds(timer);
        }
        while (repeatTime > 0);

        do
        {
            Spawn(3, tankBandit, 25f, 30f, 32, 40, 10f, 2); // Wave 3 - With slow entrance this wave gives downtime while improving upon the hard-to-aim tanks challenge
            yield return new WaitForSeconds(timer);
        }
        while (repeatTime > 0);

        do
        {
            Spawn(1, fastBandit, 90f, 20f, 4, 10, 4f, 4); // Wave 4 - Quick enemies that will shoot while tanks protect them!
            yield return new WaitForSeconds(timer);
        }
        while (repeatTime > 0);

        yield return new WaitForSeconds(3); // Gives some downtime so that the next enemy combo don't overlap

        do
        {
            Spawn(1, fastBandit, 160f, 0f, 1, 10, 1f, 5); // Wave 5 - Immenselly speedy enemies as if the last wave came improved
            yield return new WaitForSeconds(timer);
        }
        while (repeatTime > 0);

        do
        {
            Spawn(2, tankBandit, 5f, 40f, 100, 80, 2f, 2); // Wave 6 - Very Tanky and slow bandits last for more waves
            yield return new WaitForSeconds(timer);
        }
        while (repeatTime > 0);

        do
        {
            Spawn(4, normalBandit, 55f, 25f, 8, 35, 7f, 3); // Wave 7 - a little stronger buffed enemy, higher quantity per spawn!
            yield return new WaitForSeconds(timer);
        }
        while (repeatTime > 0);

        //FINISHING

        do
        {
            Spawn(2, zigzagBandit, 45f, 70f, 12, 15, 3f, 4); // Wave 8 - Zigzag enemy comeback with higher health!
            yield return new WaitForSeconds(timer);
        }
        while (repeatTime > 0);

        do
        {
            Spawn(3, zigzagBandit, 30f, 250f, 12, 30, 2f, 3); // Wave 9 - Extreme vertical speed with higher health!
            yield return new WaitForSeconds(timer);
        }
        while (repeatTime > 0);

        do
        {
            Spawn(2, tankBandit, 60f, 25f, 28, 30, 2f, 2); // Wave 10 - Finishes with speedy tankers almost as if the ultimate challenge, just before the boss!
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
