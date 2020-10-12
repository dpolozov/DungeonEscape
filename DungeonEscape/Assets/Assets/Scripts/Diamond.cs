using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    public int gems = 1;
    
    private void OnTriggerEnter2D(Collider2D other)
    {

       
        if(other.tag == "Player")
        {
            player pl = other.GetComponent<player>();

            if(pl != null)
            {
                pl.diamonds += gems;
                Destroy(this.gameObject);
            }
        }
    }
}
