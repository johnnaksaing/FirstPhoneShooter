using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;

        Invoke("Die",3f);
    }


    void Die() 
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(transform.forward * 3f);
    }
}
