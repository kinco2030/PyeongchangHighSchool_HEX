using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turrat : MonoBehaviour
{
    public GameObject firePrefab;
    public bool isRight;
    public float fire_speed = 10f;

    private float direction;

    private void Start()
    {
        direction = 90;
        if (isRight == true)
        {
            direction = 90;
        }
        else
        {
            direction = 270;
        }
        StartCoroutine(ShotFire());
    }

    private IEnumerator ShotFire()
    {
        while (true)
        {
            yield return null;
            yield return new WaitForSeconds(3);
            GameObject fire = Instantiate(firePrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            fire.transform.rotation = Quaternion.Euler(new Vector3(0, 0, direction));
            Rigidbody2D fire_rigid = fire.GetComponent<Rigidbody2D>();

            if (isRight == true)
            {
                fire_rigid.velocity = Vector2.right * fire_speed;
            }
            else if (isRight == false)
            {
                fire_rigid.velocity = Vector2.left * fire_speed;
            }

            yield return new WaitForSeconds(10);
            Destroy(fire);
        }
    }
}
