using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class Bandit_script : MonoBehaviour
{
    // I need to choose whether the bullets or the bandits are going to see the damage factor.
    // Doing the slow factor could be a boolean: half the speed if true and set a timer within to defreeze.
    // Otherwise the push factor would be added depending on the enemy speed (+/-).

    private float speed = 100f;
    private int health = 3;
    private int damage = 25;

    // how to add game manager stuff here?

    // Start is called before the first frame update
    void Start()
    {
        checkSide();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * Time.deltaTime, 0f, 0f);
        Health();

    }

    void checkSide()
    {
        if (gameObject.transform.position.x == 1100)
        {
            speed *= -1;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Damage();
            Destroy(gameObject);
        }
    }

    void Health()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    void Damage()
    {
        // remove gold which is in game manager script
    }
}
