using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator anim;
    private SpriteRenderer spriteRenderer;
    private Animator swordAnimation;
    private SpriteRenderer swordArcSprite;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        swordAnimation = transform.GetChild(1).GetComponent<Animator>();
        swordArcSprite = transform.GetChild(1).GetComponent<SpriteRenderer>();
    }

    public void Move(float move)
    {
        if (move < 0)
        {
            spriteRenderer.flipX = true;
            swordArcSprite.flipX = true;
            swordArcSprite.flipY = true;

            Vector3 newPos = swordArcSprite.transform.localPosition;
            newPos.x = -0.9f;
            swordArcSprite.transform.localPosition = newPos;
        }
        else if (move > 0)
        {
            spriteRenderer.flipX = false;
            swordArcSprite.flipX = false;
            swordArcSprite.flipY = false;

            Vector3 newPos = swordArcSprite.transform.localPosition;
            newPos.x = 0.9f;
            swordArcSprite.transform.localPosition = newPos;
        }
        anim.SetFloat("Move", Mathf.Abs(move));
    }

    public void Jump(bool jumping)
    {
        anim.SetBool("jumping", jumping);
    }

    public void Attack()
    {
        anim.SetTrigger("Attack");
        swordAnimation.SetTrigger("SwordAnimation");
    }
}