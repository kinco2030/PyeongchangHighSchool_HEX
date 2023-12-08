using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Movement2D movement2D;

    private void Awake()
    {
        movement2D = GetComponent<Movement2D>();
    }

    private void Update()
    {
        // player move
        float x = Input.GetAxisRaw("Horizontal");
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
