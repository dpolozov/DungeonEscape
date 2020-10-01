using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{

    private Rigidbody2D rigid;
    private float horizontalInput;
    [SerializeField] private float jumpForce = 0.5f;
    [SerializeField] private bool resetJump = false;


    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        rigid.velocity = new Vector2(horizontalInput, rigid.velocity.y);

        if(Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            Debug.Log("Jump");
            rigid.velocity = new Vector2(rigid.velocity.x, jumpForce);
            StartCoroutine(ResetJumpRoutine());
        }

    }

    bool IsGrounded()
    {
        RaycastHit2D hitInfo =  Physics2D.Raycast(transform.position, Vector2.down, 0.7f, 1 << 8);
        if(hitInfo.collider != null)
        {
            if (!resetJump) return true;
        }

        return false;
    }

    IEnumerator ResetJumpRoutine()
    {
        resetJump = true;
        yield return new WaitForSeconds(0.1f);
        resetJump = false;
    }

}
