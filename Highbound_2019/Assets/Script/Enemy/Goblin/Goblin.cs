using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : MonoBehaviour
{
    private Animator anim;
    private Rigidbody rb;

    private float playerDistance = 0;
    private Transform player;
    private float maxDis = 8;
    private float minDis = 3;

    private float moveSpeed = 5f;
    private float attackMoveSpeed = 3f;

    private EnemyHealth health;
    private bool dead = false;

    private void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        player = GameObject.Find("Player").transform;
        rb = gameObject.GetComponent<Rigidbody>();
        health = gameObject.GetComponent<EnemyHealth>();
    }

    private void Update()
    {
        if (player == null)
            return;

        if (health.getHealth() <= 0)
        {
            dead = true;
            Invoke("death", 1.5f);
            anim.SetBool("isDead", true);
        }

        if(dead == false)
        {
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("Sword And Shield Idle") && anim.GetBool("isAttacking") == true)
            {
                anim.SetBool("isAttacking", false);
            }

            playerDistance = Vector3.Distance(gameObject.transform.position, player.position);

            if (playerDistance <= maxDis && playerDistance > minDis && anim.GetBool("isAttacking") == false)
            {
                anim.SetBool("isMoving", true);
                rotateToPlayer();
                transform.position += transform.forward * moveSpeed * Time.deltaTime;
            }
            else if (playerDistance > maxDis || playerDistance <= minDis)
            {
                anim.SetBool("isMoving", false);
                if (playerDistance <= minDis)
                {
                    if (anim.GetBool("isAttacking") == false)
                    {
                        anim.SetBool("isAttacking", true);
                        rotateToPlayer();
                    }
                    else
                    {
                        transform.position += transform.forward * attackMoveSpeed * Time.deltaTime;
                    }
                }
            }
        }
    }

    private void rotateToPlayer()
    {
        var lookPos = player.position - transform.position;
        lookPos.y = 0.0f;
        var rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = rotation;
    }

    private void death()
    {
        Destroy(gameObject);
    }
}
