using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_script : MonoBehaviour
{
    // This script is fully done! Till build2...

    public int damage;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 10f);   
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0f, 0f, 500f * Time.deltaTime);
    }
}
