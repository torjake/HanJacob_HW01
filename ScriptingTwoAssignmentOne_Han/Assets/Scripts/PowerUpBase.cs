using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class PowerUpBase : MonoBehaviour
{
    /*
    a.Contains a ‘powerupDuration’ field
    b.On Player Enter Trigger, calls PowerUp() abstract method

    c.Disables Visuals and Collider(to keep the script active for powerup duration)
    d.After PowerupDuration has elapsed, calls PowerDown() abstract method
    e.DisablePowerup GameObject completely once PowerDown() runs
    */
    [SerializeField] float _powerUpDuration = 5f;
    Rigidbody _rb;

    Player player;

    protected abstract void PowerUp(Player player);
    protected abstract void PowerDown(Player player);

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        player = collision.gameObject.GetComponent<Player>();
        if (player != null) 
        {
            PowerUp(player);
            Invoke("RunPowerDown", _powerUpDuration);
        }
    }
    private void RunPowerDown() 
    {
        PowerDown(player);
    }
}
