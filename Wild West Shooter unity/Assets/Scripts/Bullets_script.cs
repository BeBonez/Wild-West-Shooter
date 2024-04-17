using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets_script : MonoBehaviour
{
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
