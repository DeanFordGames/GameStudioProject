using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    private Transform posA;
    private Transform posB;

    [SerializeField]
    private float speed = 0.01f;
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
            float dis = Vector3.Distance(this.transform.position, posB.position);

            gameObject.transform.position = Vector3.Lerp(this.transform.position, posB.position, speed / dis);    
        }else
        {
            float dis = Vector3.Distance(this.transform.position, posA.position);

            gameObject.transform.position = Vector3.Lerp(this.transform.position, posA.position, speed / dis);
        }

        if(gameObject.transform.position.x + 1 >= posB.position.x && gameObject.transform.position.x - 1 <= posB.position.x &&
            gameObject.transform.position.y + 1 >= posB.position.y && gameObject.transform.position.y - 1 <= posB.position.y)
        {
            dirA = true;
        }else if(gameObject.transform.position.x + 1 >= posA.position.x && gameObject.transform.position.x - 1 <= posA.position.x &&
            gameObject.transform.position.y + 1 >= posA.position.y && gameObject.transform.position.y - 1 <= posA.position.y)
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
