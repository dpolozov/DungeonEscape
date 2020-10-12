using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiant : Enemy, IDamageable
{
    public int Health { set; get; }

    public override void Init()
    {
        base.Init();
        Health = base.health;
    }

    public void Damage()
    {
        if (!isDead)
        {
            //Debug.Log("Damage");
            Health--;
            anim.SetTrigger("Hit");
            if (Health < 1)
            {
                anim.SetTrigger("Death");
                GameObject diamond = Instantiate(diamondPrefab, transform.position, Quaternion.identity) as GameObject;
                diamond.GetComponent<Diamond>().gems = base.gems;
                isDead = true;
            }
        }
    }
}
