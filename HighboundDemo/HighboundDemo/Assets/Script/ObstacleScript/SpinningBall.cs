using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningBall : MonoBehaviour
{
    Vector3 hitVelocity = new Vector3(1f, 1f, 1f);
    int damage = 5;

    private void OnCollisionEnter(Collision c)
    {
        PlayerStats hit = c.gameObject.GetComponent<PlayerStats>();
        if (hit != null)
            if (gameObject.GetComponent<Rigidbody>().velocity.x > hitVelocity.x
                || gameObject.GetComponent<Rigidbody>().velocity.y > hitVelocity.y
                || gameObject.GetComponent<Rigidbody>().velocity.z > hitVelocity.z)
                hit.hitPlayer(damage);
    }
}
