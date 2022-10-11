using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulltroller : MonoBehaviour
{
    Rigidbody m_rigidbody;

    public float duration = 3f;
    public float speed = 1000f;
    // Start is called before the first frame update
    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();

        Destroy(gameObject,duration);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        m_rigidbody.AddForce(speed * transform.forward);
    }
}
