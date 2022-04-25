using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    private Transform posA;
    private Transform posB;

    [SerializeField]
    private float speed = 2f;
    [SerializeField]
    private bool dirA = false;

    private void Start()
    {
        posA = gameObject.transform.parent.GetChild(0);
        posB = gameObject.transform.parent.GetChild(1);
    }

    private void Update()
    {
        if (dirA == false)
        {
            gameObject.transform.position += transform.right * speed * Time.deltaTime;    
        }else
        {
            gameObject.transform.position += -transform.right * speed * Time.deltaTime;
        }

        if(gameObject.transform.position.x >= posB.position.x)
        {
            dirA = true;
        }else if(gameObject.transform.position.x <= posA.position.x)
        {
            dirA = false;
        }
    }

    private void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.name == "Player")
            c.gameObject.transform.SetParent(gameObject.transform);
    }

    private void OnTriggerExit(Collider c)
    {
        if (c.gameObject.name == "Player")
            c.gameObject.transform.parent = null;
    }

}
