using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    private float decay = 2.5f;
    private int speed = 10;
    private int damage = 20;

    private void Update()
    {
        if(decay <= 0.0f)
        {
            Destroy(gameObject);
        }else
        {
            decay -= Time.deltaTime;
        }

        transform.position += transform.forward * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.name == "Wizard" || c.gameObject.name.Contains("hammer"))
            return;

        PlayerStats hit = c.gameObject.GetComponent<PlayerStats>();
        if (hit != null)
            hit.hitPlayer(damage);

        Destroy(gameObject);
    }
}
