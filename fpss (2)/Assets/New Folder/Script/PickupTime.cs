using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupTime : PickupItem
{
    protected override void OnPicked()
    {
        GameModeManager.Inst.LimitTime += 5f;
        GameModeManager.Inst._player.SetHp(GameModeManager.Inst._player.GetHp() + 3);
    }
}
