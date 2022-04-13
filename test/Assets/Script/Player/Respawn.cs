using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    private void OnTriggerEnter(Collider c)
    {
        if(c.gameObject.name == "Player")
        {
            c.gameObject.transform.position = GameObject.Find("Spawn").transform.position;
        }
    }
}
