using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupPower : PickupItem
{

    protected override void OnPicked()
    {
        GameModeManager.Inst._player.Powered();
    }
}
