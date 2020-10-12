using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public GameObject diamondPrefab;

    [SerializeField] protected int health;
    [SerializeField] protected float speed;
    [SerializeField] protected int gems;
    [SerializeField] protected Transform pointA, pointB;

    protected Vector3 currentTarget, lastTarget;
    protected Animator anim;
    protected SpriteRenderer sprite;

    protected player player;
    protected float distance;
    [SerializeField] protected bool inCombat = false;
    protected Vector3 direction;
    protected bool isDead = false;



    public virtual void Init()
    {
        anim = GetComponentInChildren<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        currentTarget = pointB.position;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<player>();
    }

    private void Start()
    {
        Init();
    }

    public virtual void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle") ||
            anim.GetCurrentAnimatorStateInfo(0).IsName("Hit") ||
            anim.GetCurrentAnimatorStateInfo(0).IsName("Attack") )
        {
            return;
        }

        if(!isDead) Movement();

    }

    public virtual void Movement()
    {

        distance = Vector3.Distance(transform.position, player.transform.position);

        if (distance < 2.5) inCombat = true;

        if (inCombat)
        {
           
            currentTarget.x = player.transform.position.x;

            if(distance < 0.5)
            {
                anim.SetTrigger("Attack");
            }
        }

        if(distance > 2.5 && inCombat)
        {
            inCombat = false;
            currentTarget = pointA.position;
        }

        //Debug.Log(currentTarget);
        direction = transform.position - currentTarget;

        if (direction.x > 0)
        {
            sprite.flipX = true;
        }
        else
        {
            sprite.flipX = false;
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
