using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rigid;
    private Animator anim;

    private bool isKnockback = false;

    public float maxSpeed;
    public float jumpPower;
    public bool isLongJump = false;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (isKnockback == false)
        {
            Jump();
        }


        // space down => isLongJump = true
        if (Input.GetKey(KeyCode.Space))
        {
            isLongJump = true;
        }
        // space up => isLongJump = false
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isLongJump = false;
        }

        // Stop move
        if (Input.GetButtonUp("Horizontal"))
        {
            rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.5f, rigid.velocity.y);
        }

        // sprite rotation
        if (Input.GetAxisRaw("Horizontal") < 0)
            transform.rotation = Quaternion.Euler(0, 180, 0);
        else if (Input.GetAxisRaw("Horizontal") > 0)
            transform.rotation = Quaternion.Euler(0, 0, 0);

        // animation
        if (Mathf.Abs(rigid.velocity.x) < 0.3f)
            anim.SetBool("isRun", false);
        else
            anim.SetBool("isRun", true);

        // Long Jump
        if (isLongJump && rigid.velocity.y > 0)
        {
            rigid.gravityScale = 4.0f;
        }
        else
        {
            rigid.gravityScale = 10.0f;
        }
    }

    private void FixedUpdate()
    {
        if (isKnockback == true)
        {
            return;
        }

        // move
        Move();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 targetPos = collision.transform.position;

        if (collision.gameObject.CompareTag("Ground"))
        {
            anim.SetBool("isJump", false);
        }

        if (collision.gameObject.CompareTag("Monster"))
        {
            OnDamaged(targetPos);
        }

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            OnDamaged(targetPos);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Vector2 targetPos = collision.transform.position;

        if (collision.gameObject.CompareTag("Fire"))
        {
            OnDamaged(targetPos);
        }

        if (collision.gameObject.CompareTag("Dead"))
        {
            transform.position = new Vector3(0, 0, 0);
        }
    }

    /* MOVE */
    private void Move()
    {
        // move
        float h = Input.GetAxisRaw("Horizontal");

        rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);


        // move controll by maxspeed
        if (rigid.velocity.x > maxSpeed)
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
        else if (rigid.velocity.x < -maxSpeed)
            rigid.velocity = new Vector2(-maxSpeed, rigid.velocity.y);
    }

    /* JUMP */
    private void Jump()
    {
        // Jump
        if (Input.GetKeyDown(KeyCode.Space) && !anim.GetBool("isJump"))
        {
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            anim.SetBool("isJump", true);
        }
    }

    private void OnDamaged(Vector2 targetPos)
    {
        int dirc = transform.position.x - targetPos.x > 0 ? 1 : -1;
        StartCoroutine(ChangeMaxSpeedAfterDelay(3f, 100f, 5f));
        rigid.AddForce(new Vector2(dirc, 1) * 30, ForceMode2D.Impulse);
    }

    private IEnumerator ChangeMaxSpeedAfterDelay(float delay, float newMaxSpeed, float originalMaxSpeed)
    {
        isKnockback = true;
        anim.SetBool("isFalling", true);
        // MaxSpeed를 변경
        maxSpeed = newMaxSpeed;
        // 다시 1초 동안 대기
        yield return new WaitForSeconds(delay);
        // MaxSpeed를 복구
        maxSpeed = originalMaxSpeed;
        isKnockback = false;
        anim.SetBool("isFalling", false);
    }
}