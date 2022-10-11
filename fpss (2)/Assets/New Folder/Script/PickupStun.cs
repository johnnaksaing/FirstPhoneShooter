using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupStun : PickupItem
{
    protected override void OnPicked()
    {
        GameModeManager.Inst.StunEnemy();
    }
}
