using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : MonoBehaviour
{
    private Animator anim;
    private Rigidbody rb;

    private float playerDistance = 0;
    private Transform player;
    private float maxDis = 30;
    private float minDis = 5;

    private float moveSpeed = 5f;
    private float attackMoveSpeed = 6f;

    private void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        player = GameObject.Find("Player").transform;
        rb = gameObject.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (player == null)
            return;

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Sword And Shield Idle") && anim.GetBool("isAttacking") == true)
        {
            anim.SetBool("isAttacking", false);
        }

        playerDistance = Vector3.Distance(gameObject.transform.position, player.position);

        if(playerDistance <= maxDis && playerDistance > minDis && anim.GetBool("isAttacking") == false)
        {
            anim.SetBool("isMoving", true);
            rotateToPlayer();
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }else if(playerDistance > maxDis || playerDistance <= minDis)
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

    private void rotateToPlayer()
    {
        var lookPos = player.position - transform.position;
        lookPos.y = 0.0f;
        var rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = rotation;
    }
}
