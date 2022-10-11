using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupAmmo : PickupItem
{
    protected override void OnPicked()
    {
        GameModeManager.Inst._player.gameObject.GetComponent<PlaceARObject>().curMagCount += 10;
    }
}
