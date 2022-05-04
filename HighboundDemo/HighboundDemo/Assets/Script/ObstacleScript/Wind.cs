using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
    private float speed = 15f;
    private float hitForce = 30f;

    private float decay = 3f;

    private void Update()
    {
        gameObject.transform.position += transform.forward * speed * Time.deltaTime;
        if(decay <= 0)
        {
            Destroy(gameObject);
        }else
        {
            decay -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider c)
    {
        Rigidbody hit = c.gameObject.GetComponent<Rigidbody>();

        if (hit == null)
            return;

        hit.AddForce((this.transform.forward + (this.transform.up / 2.5f)) * hitForce, ForceMode.Impulse);
    }
}
