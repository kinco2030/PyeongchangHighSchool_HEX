using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    /*
     Move ai,
     */
    private Rigidbody2D rigid;
    private int nextMove = 1;

    public float monsterSpeed;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rigid.velocity = new Vector2(nextMove * monsterSpeed, rigid.velocity.y);

        Vector2 frontVec = new Vector2(rigid.position.x + nextMove * 1.5f, rigid.position.y);
        Debug.DrawRay(frontVec, Vector3.down, Color.yellow);
        RaycastHit2D rayHit = Physics2D.Raycast(frontVec, Vector3.down, 1, LayerMask.GetMask("Ground"));
        if (rayHit.collider == null)
        {
            nextMove *= -1;
        }

        if (nextMove < 0)
            transform.rotation = Quaternion.Euler(0, 180, 0);
        else if (nextMove > 0)
            transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}