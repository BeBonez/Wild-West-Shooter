using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class Bandit_script : MonoBehaviour
{
    // Doing the slow factor could be a boolean: half the speed if true and set a timer within to defreeze.
    // Otherwise the push factor would be added depending on the enemy speed (+/-).

    public float speed;
    public float vSpeed;
    public int health;
    public int steal;
    [SerializeField] GameObject goodParticles;
    [SerializeField] GameObject badParticles;
    GameObject manager; 

    // how to add game manager stuff here?

    // Start is called before the first frame update
    void Start()
    {
        checkSide();
        manager = GameObject.FindGameObjectWithTag("Manager");
    }
    void checkSide()
    {
        if (gameObject.transform.position.x == 1100)
        {
            transform.Rotate(new Vector3(0, -90, 0));
        } else
        {
            transform.Rotate(new Vector3(0, 90, 0));
        }
    }

    // Movement and Health. 
    void Update()
    {
        Health();
        transform.Translate(0f, 0f, speed * Time.deltaTime);
        CheckBoundaries();
        transform.Translate(vSpeed * Time.deltaTime, 0f, 0f);
    }
    void Health()
    {
        if (health <= 0)
        {
            // Audio_script.Instance.TocarSFX();
            manager.GetComponent<Game_Manager_script>().defeated++;
            Destroy(gameObject);
        }
    }

    void CheckBoundaries()
    {
        if (transform.position.z > 340 || transform.position.z < -400)
        {
            vSpeed *= -1;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // When being hit by a bullet
        if (other.CompareTag("Bullet"))
        {
            Instantiate(goodParticles, gameObject.transform.position, Quaternion.identity);
            health -= other.GetComponent<Bullet_script>().damage;
            Destroy(other.gameObject);
            Health();
        }

        if (other.CompareTag("SlowingBullet"))
        {
            Instantiate(goodParticles, gameObject.transform.position, Quaternion.identity);
            health -= other.GetComponent<Bullet_script>().damage;
            Destroy(other.gameObject);
            if (speed > 20) 
            {
                speed -= 20;
            }
            
            Health();
        }

        // When Attacking the Player:
        if (other.CompareTag("Player"))
        {
            Instantiate(badParticles, gameObject.transform.position, Quaternion.identity);
            Damage();
            manager.GetComponent<Game_Manager_script>().defeated++;
            Destroy(gameObject);
        }
    }

    void Damage()
    {
        manager.GetComponent<Game_Manager_script>().TakeDamage(steal);
    }
}
