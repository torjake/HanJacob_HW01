using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvincibilityPowerup : PowerUpBase
{
    /*
    a.Create a Cyan materialfor this
    b.On PowerUp(), change player color
    c.While active, protect player from damage (though knockback is fine)
    d.On PowerDown(), revert player color
    */
    protected override void PowerUp(Player player) 
    {
        player.gameObject.GetComponentInChildren<Renderer>().material.color = Color.white;
        //
        this.GetComponent<BoxCollider>().enabled = false;
        this.GetComponent<Renderer>().enabled = false;
        //
        player.GetComponent<Player>().canTakeDamage = false;
    }
    protected override void PowerDown(Player player)
    {
        player.gameObject.GetComponentInChildren<Renderer>().material.color = Color.green;
        //
        player.GetComponent<Player>().canTakeDamage = true;
        //
        gameObject.SetActive(false);
    }
}
