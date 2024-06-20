using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UIElements;

public class Turret_script : MonoBehaviour
{
    // This Script is fully done!!!

    private float chooseTurret;
    private float rotate;
    [SerializeField] private float rotateStrengh;
    [SerializeField] private float chosenTurret;
    [SerializeField] private float shootTime;
    [SerializeField] private float reloadTime;
    [SerializeField] private GameObject bullet;
    [SerializeField] GameObject manager;

    // Start is called before the first frame update
    void Start()
    {
       // InvokeRepeating("Shoot", shootTime, shootTime);
    }

    // Update is called once per frame
    void Update()
    {
        shootTime += Time.deltaTime * manager.GetComponent<Game_Manager_script>().trainSpeed;
        if (shootTime >= reloadTime)
        {
            Shoot();
            shootTime = 0;
        }

        if (manager.GetComponent<Game_Manager_script>().trainSpeed > 1)
        {
            manager.GetComponent<Game_Manager_script>().trainSpeed -= 0.1f * Time.deltaTime;
        }
        chooseTurret = Input.GetAxisRaw("Vertical");
        rotate = Input.GetAxisRaw("Horizontal");
        Rotate();
    }

    void Shoot()
    {
        Instantiate(bullet, gameObject.transform.position, gameObject.transform.rotation);
    }

    void Rotate()
    {
        if (rotate == 1 && chooseTurret == chosenTurret)
        {
            gameObject.transform.Rotate(0f, rotateStrengh * Time.deltaTime, 0f);
        }
        if (rotate == -1 && chooseTurret == chosenTurret)
        {
            gameObject.transform.Rotate(0f, -rotateStrengh * Time.deltaTime, 0f);
        }
    }
}
