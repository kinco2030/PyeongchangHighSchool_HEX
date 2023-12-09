using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2D : MonoBehaviour
{
    [SerializeField]
    private float speed = 5.0f;     // move speed
    [SerializeField]
    private float jumpForce = 8.0f; // jump power
    private Rigidbody2D rigid;
    [HideInInspector]
    public bool isLongJump = false; // low jump, high jump check

    [SerializeField]
    private LayerMask groundLayer;
    private CapsuleCollider2D capsuleCollider2D;
    private Vector3 footPosition;
    public bool isGrounded;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        capsuleCollider2D = GetComponent<CapsuleCollider2D>();
    }

    private void FixedUpdate()
    {
        Bounds bounds = capsuleCollider2D.bounds;
        footPosition = new Vector2(bounds.center.x, bounds.min.y);
        isGrounded = Physics2D.OverlapCircle(footPosition, 0.1f, groundLayer);

        if (isLongJump && rigid.velocity.y > 0)
        {
            rigid.gravityScale = 1.0f;
        }
        else
        {
            rigid.gravityScale = 2.5f;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(footPosition, 0.1f);
    }

    public void Move(float x)
    {
        rigid.velocity = new Vector2(x * speed, rigid.velocity.y);
    }

    public void Jump()
    {
        if (isGrounded == true)
        {
            rigid.velocity = Vector2.up * jumpForce;
        }
    }
}
