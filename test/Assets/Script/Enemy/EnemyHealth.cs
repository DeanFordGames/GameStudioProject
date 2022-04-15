using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private int health = 10;

    public void getHit(int damage)
    {
        health -= damage;
        if (health <= 0)
            Destroy(gameObject);
    }
}
