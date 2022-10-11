using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindController : MonoBehaviour
{

    public Vector3 WindForceDir;
    public float m_fWindStrength;

    private void Start()
    {
        
    }
    private void Update()
    {
        if (WindForceDir.sqrMagnitude > 1)
            WindForceDir.Normalize();
    }
    //private void OnTriggerEnter(Collider other)
    private void OnTriggerStay(Collider other)
    {
        Debug.Log("trigger");
        if (other.gameObject.tag != "BULLET")
            return;

        Rigidbody bullet_rb = other.GetComponent<Rigidbody>();
        bullet_rb.AddForce(WindForceDir * m_fWindStrength,ForceMode.Force);
        Debug.Log("Bullet");
    }
}
