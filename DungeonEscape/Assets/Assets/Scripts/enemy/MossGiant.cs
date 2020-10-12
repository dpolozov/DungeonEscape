﻿using System.Collections;
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
            if (Health < 0)
            {
                anim.SetTrigger("Death");
                isDead = true;
            }
        }
    }
}
