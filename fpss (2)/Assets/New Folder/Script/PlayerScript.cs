using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : EnemyScript
{
    // Start is called before the first frame update
    void Start()
    {
        hp = 10;
    }
    protected override void Update()
    {
        
    }

    public bool bPowered = false;
    public int GetHp() { return hp; }
    public void SetHp(int _hp) { hp = _hp; }
    protected override void Die()
    {
        GameModeManager.Inst.YouLose();
    }

    public void Powered() 
    {
        bPowered = true;
        Invoke("DePowered", 3f);
    }
    void DePowered() 
    {
        bPowered = false;
    }
}
