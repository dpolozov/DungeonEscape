using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private bool cooldown;
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Hit: " + other.name);

        IDamageable hit = other.GetComponent<IDamageable>();

        if (hit != null && !cooldown)
        {
            hit.Damage();
            cooldown = true;
            StartCoroutine(StartCooldown());
        }
    }

    IEnumerator StartCooldown()
    {
        yield return new WaitForSeconds(0.5f);
        cooldown = false;
    }
}
