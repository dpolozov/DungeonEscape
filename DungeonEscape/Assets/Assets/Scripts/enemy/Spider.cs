using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy, IDamageable
{
    public int Health { set; get; }

    public GameObject acidEffectPrefab;

    public override void Init()
    {
        base.Init();
        Health = base.health;
    }

    public void Damage()
    {
        if (!isDead)
        {
            Health--;
            if (Health < 1)
            {
                anim.SetTrigger("Death");
                GameObject diamond = Instantiate(diamondPrefab, transform.position, Quaternion.identity) as GameObject;
                diamond.GetComponent<Diamond>().gems = base.gems;
                isDead = true;
            }
        }
    }

    public void Attack()
    {
        Instantiate(acidEffectPrefab, transform.position, Quaternion.identity);
    }
}
