using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_script : MonoBehaviour
{
    // Do I try to make this more reusable?
    // I Could do a change in how much damage it gives to enemies with public variables
    // I could add a Serialized area to make the slowness or push factor

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
