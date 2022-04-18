using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerAttack : MonoBehaviour
{
    private Animator anim;
    private int damage = 10;

    [SerializeField]
    private bool hitOnce = false;

    private void Start()
    {
        anim = GameObject.Find("Player").transform.GetChild(0).GetComponent<Animator>();
    }

    private void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Sword And Shield Idle"))
        {
            hitOnce = false;
        }
    }

    private void OnTriggerStay(Collider c)
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Standing Melee Attack Downward") && hitOnce == false)
        {
            EnemyHealth hit = c.gameObject.GetComponent<EnemyHealth>();
            if (hit != null)
            {
                hit.getHit(damage);
                hitOnce = true;
            }
        }
    }
}
