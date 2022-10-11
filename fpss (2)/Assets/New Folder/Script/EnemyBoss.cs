using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoss : EnemyScript
{

    // Start is called before the first frame update
    void Start()
    {
        hp = 30;
    }

    // Update is called once per frame
    protected override void Update()
    {
        transform.LookAt(player);
        time += Time.deltaTime;
        if (!GameModeManager.Inst.bEnemyStunned && time >= 1.5f && Vector3.Distance(transform.position, player.position) < distance)
        {
            time = 0f;
            Shoot();
        }
    }

    protected override void Die()
    {
        GameModeManager.Inst.YouWin();
        Destroy(gameObject);
    }
}
