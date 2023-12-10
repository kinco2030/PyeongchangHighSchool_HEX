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

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        // Jump
        if (Input.GetButtonDown("Jump") && !anim.GetBool("isJump"))
        {
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            anim.SetBool("isJump", true);
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
    }

    private void FixedUpdate()
    {
        if (isKnockback == true)
        {
            return;
        }
       
        // move
        float h = Input.GetAxisRaw("Horizontal");

        rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);
        
        
        // move controll by maxspeed
        if (rigid.velocity.x > maxSpeed)
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
        else if (rigid.velocity.x < -maxSpeed)
            rigid.velocity = new Vector2(-maxSpeed, rigid.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            anim.SetBool("isJump", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fire"))
        {
            Debug.Log("으악");
            OnDamaged(collision.transform.position);
        }
    }

    private void OnDamaged(Vector2 targetPos)
    {
        int dirc = transform.position.x - targetPos.x > 0 ? 1 : -1;
        StartCoroutine(ChangeMaxSpeedAfterDelay(3f, 100f, 5f));
        rigid.AddForce(Vector2.right * dirc * 30, ForceMode2D.Impulse);
    }

    private IEnumerator ChangeMaxSpeedAfterDelay(float delay, float newMaxSpeed, float originalMaxSpeed)
    {
        isKnockback = true;
        // MaxSpeed를 변경
        maxSpeed = newMaxSpeed;
        // 다시 1초 동안 대기
        yield return new WaitForSeconds(delay);
        // MaxSpeed를 복구
        maxSpeed = originalMaxSpeed;
        isKnockback = false;
    }






















    //private Movement2D movement2D;
    //private Animator anim;

    //private void Awake()
    //{
    //    movement2D = GetComponent<Movement2D>();
    //    anim = GetComponent<Animator>();
    //}

    //private void Update()
    //{
    //    // player move
    //    float x = Input.GetAxisRaw("Horizontal");

    //    // player rotate
    //    if (x > 0f)
    //        transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
    //    else if (x < 0f)
    //        transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));

    //    // Animation
    //    // Run
    //    if (x != 0f)
    //        anim.SetBool("isRun", true);
    //    else
    //        anim.SetBool("isRun", false);

    //    // Jump
    //    if (movement2D.isGrounded == true)
    //        anim.SetBool("isJump", false);
    //    else if (movement2D.isGrounded == false)
    //        anim.SetBool("isJump", true);

    //    movement2D.Move(x);

    //    // player jump
    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {
    //        movement2D.Jump();
    //    }

    //    // space down => isLongJump = true
    //    if (Input.GetKey(KeyCode.Space))
    //    {
    //        movement2D.isLongJump = true;
    //    }
    //    // space up => isLongJump = false
    //    if (Input.GetKeyUp(KeyCode.Space))
    //    {
    //        movement2D.isLongJump = false;
    //    }
    //}

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Fire"))
    //    {
    //        movement2D.OnDamaged(collision.transform.position);
    //    }
    //}
}
