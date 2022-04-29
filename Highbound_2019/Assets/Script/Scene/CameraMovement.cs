using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Transform player;
    private Transform camPos;
    private float lerpSpeed = 0.1f;

    private void Start()
    {
        player = GameObject.Find("Player").transform;
        camPos = player.GetChild(1);
    }

    private void Update()
    {
        if (player == null)
            return;

        transform.LookAt(player);

        transform.position = Vector3.Lerp(this.transform.position, camPos.position, lerpSpeed);
    }
}
