using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turrat : MonoBehaviour
{
    public GameObject firePrefab;

    private void Start()
    {
        StartCoroutine(ShotFire());
    }

    private IEnumerator ShotFire()
    {
        while (true)
        {
            yield return null;
            yield return new WaitForSeconds(3);
            GameObject fire = Instantiate(firePrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            fire.transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0));
            yield return new WaitForSeconds(3);
            Destroy(fire);
        }
    }
}
