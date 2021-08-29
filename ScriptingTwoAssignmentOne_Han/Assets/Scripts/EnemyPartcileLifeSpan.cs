using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPartcileLifeSpan : MonoBehaviour
{
    public float timer = 1f;

    ParticleSystem parts;

    private void Start()
    {
        timer = 1f;
        parts = this.GetComponent<ParticleSystem>();
    }
    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
            Kill();
    }
    void Kill() 
    {
        timer = 1f;
        //this.GetComponent<ParticleSystem>().enableEmission = false;
    }
}
