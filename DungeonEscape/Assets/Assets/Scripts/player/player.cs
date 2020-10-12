using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour, IDamageable
{
    public int diamonds;

    private Rigidbody2D _rigid;
    [SerializeField] private float _jumpForce = 6.0f;
    [SerializeField] private float _speed = 2.5f;
    private bool _resetJump = false;
    private bool grounded = false;

    private PlayerAnimation anim;

    public int Health { get ; set; }

    void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<PlayerAnimation>();
    }



    // Update is called once per frame

    void Update()
    {
        Movement();

        if(Input.GetMouseButtonDown(0) && IsGrounded())
        {
            anim.Attack();
        }
   
    }



    void Movement()
    {
        float move = Input.GetAxisRaw("Horizontal");
        grounded = IsGrounded();

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded() == true)
        {
            _rigid.velocity = new Vector2(_rigid.velocity.x, _jumpForce);
            StartCoroutine(ResetJumpRoutine());
            anim.Jump(true);
        }

        _rigid.velocity = new Vector2(move * _speed, _rigid.velocity.y);

        anim.Move(move);

    }



    bool IsGrounded()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, 1.0f, 1 << 8);
        //Debug.DrawRay(transform.position, Vector2.down, Color.green);
        if (hitInfo.collider != null)
        {
            if (_resetJump == false)
            {
                //Debug.Log("Grounded");
                anim.Jump(false);
                return true;
            }
        }
        return false;
    }



    IEnumerator ResetJumpRoutine()
    {
        _resetJump = true;
        yield return new WaitForSeconds(0.1f);
        _resetJump = false;
    }

    public void Damage()
    {
        Debug.Log("player damage called");
    }
}


