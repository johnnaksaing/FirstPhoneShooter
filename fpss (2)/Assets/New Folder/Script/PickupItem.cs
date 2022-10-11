using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PickupItem : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player")|| collision.transform.CompareTag("Bullet") || collision.transform.CompareTag("Bullet3"))
        {
            OnPicked();
        }

        Destroy(gameObject);
    }

    private void Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * 15f);
    }

    protected abstract void OnPicked();
}
