using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyScript : MonoBehaviour
{
    [SerializeField]
    public Transform player;

    [SerializeField]
    GameObject pfb_bullet;

    [SerializeField]
    protected int hp;

    [SerializeField]
    protected float distance;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    protected float time = 0f;
    protected abstract void Update();

    protected void Shoot() 
    {
        Transform b = Instantiate(pfb_bullet, transform.position + transform.forward * 1.5f, Quaternion.Euler(transform.forward)).transform;

        b.rotation = transform.rotation;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet")) 
        {
            Ouch();
            Destroy(collision.gameObject);
        }

        else if (collision.gameObject.CompareTag("Bullet3"))
        {
            Ouch(4);
            Destroy(collision.gameObject);
        }

    }

    protected void Ouch(int amount = 1)
    {
        hp -= amount;
        if (hp <= 0)
        {
            Die();
        }
    }
    protected abstract void Die();
}
