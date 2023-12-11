using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    /*
     Move ai,
     */
    private Rigidbody2D rigid;
    private float nextThinkTime;

    public int nextMove;
    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();

        Invoke("Think", nextThinkTime);
    }

    private void FixedUpdate()
    {
        rigid.velocity = new Vector2(nextMove, rigid.velocity.y);

        Vector2 frontVec = new Vector2(rigid.position.x + nextMove * 1.5f, rigid.position.y);
        Debug.DrawRay(frontVec, Vector3.down, Color.yellow);
        RaycastHit2D rayHit = Physics2D.Raycast(frontVec, Vector3.down, 1, LayerMask.GetMask("Ground"));
        if (rayHit.collider == null)
        {
            nextMove *= -1;
            CancelInvoke();
        }
    }

    public void Think()
    {
        nextMove = Random.Range(-1, 2);
        nextThinkTime = Random.Range(2f, 6f);
        
        Invoke("Think", nextThinkTime);
    }
}