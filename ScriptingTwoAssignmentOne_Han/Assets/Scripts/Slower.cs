using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slower : Enemy
{
    [SerializeField] float _slowerSpeed = .1f;

    protected override void PlayerImpact(Player player)
    {
        //base.PlayerImpact(player);
        player.GetComponent<TankController>()._moveSpeed = _slowerSpeed;
    }
}
