using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Enemy : MonoBehaviour
{
    [SerializeField] int _damageAmount = 1;
    [SerializeField] ParticleSystem _impactParticles;
    [SerializeField] AudioClip _impactSound;

    Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        TankController tankCont = collision.gameObject.GetComponent<TankController>();
        if (player != null && player.GetComponent<Player>().canTakeDamage == true) 
        {
            PlayerImpact(player);
            ImpactFeedback();
        }
    }
    protected virtual void PlayerSlowed(TankController tankCont) 
    {
        tankCont._moveSpeed = .1f;
    }
    protected virtual void PlayerImpact(Player player) 
    {
        player.DecreaseHealth(_damageAmount);
    }
    private void ImpactFeedback() 
    {
        //particles
        if (_impactParticles != null) 
        {
            _impactParticles = Instantiate(_impactParticles,
                transform.position, Quaternion.identity);
        }
        //audio. TODO - object pooling
        if (_impactSound != null) 
        {
            AudioHelper.PlayClip2D(_impactSound, 1);
        }
    }

    private void FixedUpdate()
    {
        Move();
    }
    public void Move()
    {
        
    }
}
