using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Movement2D movement2D;
    private Animator anim;

    private void Awake()
    {
        movement2D = GetComponent<Movement2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        // player move
        float x = Input.GetAxisRaw("Horizontal");

        // player rotate
        if (x > 0f)
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        else if (x < 0f)
            transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));

        // Animation
        // Run
        if (x != 0f)
            anim.SetBool("isRun", true);
        else
            anim.SetBool("isRun", false);

        // Jump
        if (movement2D.isGrounded == true)
            anim.SetBool("isJump", false);
        else if (movement2D.isGrounded == false)
            anim.SetBool("isJump", true);

        movement2D.Move(x);

        // player jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            movement2D.Jump();
        }

        // space down => isLongJump = true
        if (Input.GetKey(KeyCode.Space))
        {
            movement2D.isLongJump = true;
        }
        // space up => isLongJump = false
        if (Input.GetKeyUp(KeyCode.Space))
        {
            movement2D.isLongJump = false;
        }
    }
}
