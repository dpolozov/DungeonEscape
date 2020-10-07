using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy
{
    private Vector3 currentTarget;
    private Animator anim;
    private SpriteRenderer spiderSprite;

    // Start is called before the first frame update
    void Start()
    {
        currentTarget = pointB.position;
        anim = GetComponentInChildren<Animator>();
        spiderSprite = GetComponentInChildren<SpriteRenderer>();
    }

    public override void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            return;
        }

        Movement();

    }

    void Movement()
    {

        if (currentTarget == pointA.position)
        {
            spiderSprite.flipX = true;
        }
        else
        {
            spiderSprite.flipX = false;
        }

        if (transform.position == pointA.position)
        {
            currentTarget = pointB.position;
            anim.SetTrigger("Idle");
        }
        else if (transform.position == pointB.position)
        {
            currentTarget = pointA.position;
            anim.SetTrigger("Idle");
        }

        transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);
    }

}
