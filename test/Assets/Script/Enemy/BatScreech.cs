using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatScreech : MonoBehaviour
{
    private float speed = 20f;
    private float decay = 4f;

    private int damage = 10;
    private void Update()
    {
        if(decay <= 0)
        {
            Destroy(gameObject);
        }else
        {
            speed -= Time.deltaTime;
            transform.position += transform.forward * speed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider c)
    {
        if (c.gameObject == gameObject)
            return;

        PlayerStats hit = c.gameObject.GetComponent<PlayerStats>();
        if (hit != null)
            hit.hitPlayer(damage);

        Destroy(gameObject);
    }
}
