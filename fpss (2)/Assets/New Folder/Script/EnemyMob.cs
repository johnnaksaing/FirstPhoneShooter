using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMob : EnemyScript
{


    // Start is called before the first frame update
    void Start()
    {
        hp = 3;    
    }

    protected override void Update()
    {
        transform.LookAt(player);
        time += Time.deltaTime;
        if (!GameModeManager.Inst.bEnemyStunned && time >= 1.5f && Vector3.Distance(transform.position, player.position) < distance)
        //if(time >= 1.5f)
        {
            time = 0f;
            Shoot();
        }
    }

    protected override void Die()
    {

        GameModeManager.Inst.score++;
        if (GameModeManager.Inst.score >= GameModeManager.Inst.CountToBoss) 
        {
            GameModeManager.Inst.SpawnEnemyBoss();
        }

        Debug.Log(GameModeManager.Inst.score);
        Destroy(gameObject);
    }
}
