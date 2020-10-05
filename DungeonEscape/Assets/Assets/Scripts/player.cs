﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{

    private Rigidbody2D _rigid;

    [SerializeField]

    private float _jumpForce = 5.0f;

    private bool _resetJump = false;

    void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();
    }



    // Update is called once per frame

    void Update()
    {
        Movement();
   
    }



    void Movement()
    {
        float move = Input.GetAxisRaw("Horizontal");


        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded() == true)
        {
            Debug.Log("Jump!");
            _rigid.velocity = new Vector2(_rigid.velocity.x, _jumpForce);
            StartCoroutine(ResetJumpRoutine());
        }

        _rigid.velocity = new Vector2(move, _rigid.velocity.y);


    }



    bool IsGrounded()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, 1.0f, 1 << 8);
        Debug.DrawRay(transform.position, Vector2.down, Color.green);
        if (hitInfo.collider != null)
        {
            if (_resetJump == false)
                return true;
        }
        return false;
    }



    IEnumerator ResetJumpRoutine()
    {
        _resetJump = true;
        yield return new WaitForSeconds(0.1f);
        _resetJump = false;
    }

}


