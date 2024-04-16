using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret_script : MonoBehaviour
{
    [SerializeField] private float chooseTurret;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        chooseTurret = Input.GetAxisRaw("Vertical");
        shoot();
    }

    void shoot()
    {
        // Instantiate(bullet,)
    }
}
