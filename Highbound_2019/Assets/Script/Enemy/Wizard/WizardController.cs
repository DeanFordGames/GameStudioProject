using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardController : MonoBehaviour
{
    private Animator anim;

    private Transform player;

    private float shootTimerReset = 2.5f;
    private float shootTimer = 2.5f;
    [SerializeField]
    private GameObject fireballPrefab;
    private Transform shootPos;

    private EnemyHealth health;
    private bool dead = false;

    [SerializeField]
    private GameObject endDoorPrefab;

    private void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        player = GameObject.Find("Player").transform;
        shootPos = gameObject.transform.GetChild(3);
        health = gameObject.GetComponent<EnemyHealth>();
    }

    private void Update()
    {
        float dis = Vector3.Distance(this.transform.position, player.position);

        if(health.getHealth() <= 0 && dead == false)
        {
            dead = true;
            Invoke("death", 1.5f);
            anim.SetBool("isDead", true);
        }

        if(dead == false)
        {
            if (dis < 10)
            {
                rotateToPlayer();
                if (shootTimer <= 0.0f)
                {
                    anim.SetBool("isAttacking", true);
                    Invoke("shootFireball", 0.5f);
                    shootTimer = shootTimerReset;
                }
                else
                {
                    shootTimer -= Time.deltaTime;
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

    private void shootFireball()
    {
        Instantiate(fireballPrefab, shootPos.position, this.transform.rotation);
        anim.SetBool("isAttacking", false);
    }

    private void death()
    {
        Instantiate(endDoorPrefab, this.transform.position + new Vector3(0, 1, 0), Quaternion.Euler(-90, 0, 0));
        Destroy(gameObject);
    }
}
