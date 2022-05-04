using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningPlatform : MonoBehaviour
{
    private float spinSpeed = 0.2f;

    [SerializeField] private bool dir = false;

    private void Update()
    {
        if(dir == false)
            transform.rotation = transform.rotation * Quaternion.Euler(0, spinSpeed, 0);
        else if(dir == true)
            transform.rotation = transform.rotation * Quaternion.Euler(0, -spinSpeed, 0);
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
