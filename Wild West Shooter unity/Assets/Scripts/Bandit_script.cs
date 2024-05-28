using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class Bandit_script : MonoBehaviour
{
    public float speed;
    public float vSpeed;
    public int health;
    public int steal;
    [SerializeField] GameObject goodParticles;
    [SerializeField] GameObject badParticles;
    GameObject manager; 

    // Start is called before the first frame update
    void Start()
    {
        // checkSide();
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
        transform.Translate(speed * Time.deltaTime, 0f, 0f);
        CheckBoundaries();
        transform.Translate(vSpeed * Time.deltaTime, 0f, 0f);
    }
    void Health()
    {
        if (health <= 0)
        {
            Audio_script.Instance.TocarSFX(4);
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
            if (speed > 20) 
            {
                speed -= 20;
            }
            
            Health();
        }

        // When Attacking the Player:
        if (other.CompareTag("Player"))
        {
            Audio_script.Instance.TocarSFX(5);
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
