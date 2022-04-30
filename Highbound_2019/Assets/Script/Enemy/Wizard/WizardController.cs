using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardController : MonoBehaviour
{
    private Animator anim;

    private Transform player;

    private void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        player = GameObject.Find("Player").transform;
    }

    private void Update()
    {
        float dis = Vector3.Distance(this.transform.position, player.position);

        if(dis < 10)
        {
            rotateToPlayer();
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
