using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_script : MonoBehaviour
{
    public int damage;
    [SerializeField] GameObject manager;
    
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("Manager");
        Destroy(gameObject, 10f);   
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0f, 0f, 500f * Time.deltaTime);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp")) {
            Audio_script.Instance.TocarSFX(6);
            int select = Random.Range(0, 4);
            if (select <= 1)
            {
                manager.GetComponent<Game_Manager_script>().fakeGold += 25;
                Destroy(other.gameObject);
            } else
            {
                manager.GetComponent<Game_Manager_script>().trainSpeed += 3;
                Destroy(other.gameObject);
            }
        }
    }
}
