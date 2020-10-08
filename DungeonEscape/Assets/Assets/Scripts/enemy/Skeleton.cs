using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy, IDamageable
{
    public int Health { set; get; }

    public override void Init()
    {
        base.Init();
        Health = base.health;
    }

    public void Damage()
    {
        Debug.Log("Damage");
        Health--;

        if (Health < 0)
        {
            Destroy(this.gameObject);
        }
    }
}
