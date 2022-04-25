using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : MonoBehaviour
{
    private Rigidbody rb;

    private float flapTimer = 1f;
    private bool flap = true;
    private float flapForce = 76.5f;

    private float distance;
    private bool chase = false;
    private float moveSpeed = 5f;

    private Transform player;
    private Transform shootPoint;
    [SerializeField]
    private GameObject screech;

    private float shootTimer = 2f;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        player = GameObject.Find("Player").transform;
        shootPoint = transform.GetChild(0);
    }

    private void Update()
    {
        distance = Vector3.Distance(gameObject.transform.position, player.position);
        if (flap == false)
        {
            if (flapTimer <= 0)
            {
                flap = true;
                flapTimer = 1f;
            }
            else
            {
                flapTimer -= Time.deltaTime;
            }
        }

        if(distance <= 20)
        {
            chase = true;
        }else if(distance >= 60)
        {
            chase = false;
        }

        if(chase == true)
        {
            if (distance > 5)
            {
                gameObject.transform.position += transform.forward * moveSpeed * Time.deltaTime;
            }

            gameObject.transform.LookAt(player);

            if (shootTimer <= 0)
            {
                shootTimer = 2f;
                Instantiate(screech, shootPoint.position, transform.rotation);
            }else
            {
                shootTimer -= Time.deltaTime;
            }
        }
    }

    private void FixedUpdate()
    {
        if(flap == true)
        {
            rb.velocity = Vector3.zero;
            flapForce = Random.Range(75f, 78f);
            rb.AddForce(transform.up * flapForce);
            flap = false;
        }
    }
}
