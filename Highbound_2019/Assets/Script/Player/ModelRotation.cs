using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelRotation : MonoBehaviour
{
    private float horizontalMove = 0;
    private float verticalMove = 0;

    private float lerpSpeed = 500f;
    private Quaternion movingRotation;

    private void Start()
    {
        movingRotation = gameObject.transform.parent.rotation;
    }

    private void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal");
        verticalMove = Input.GetAxisRaw("Vertical");

        if(horizontalMove == 1 && verticalMove == 0)
        {
            movingRotation = Quaternion.Euler(0, 90, 0) * gameObject.transform.parent.rotation;
        }else if(horizontalMove == 1 && verticalMove == -1)
        {
            movingRotation = Quaternion.Euler(0, 135, 0) * gameObject.transform.parent.rotation;
        }
        else if(horizontalMove == 1 && verticalMove == 1)
        {
            movingRotation = Quaternion.Euler(0, 45, 0) * gameObject.transform.parent.rotation;
        }
        else if (horizontalMove == -1 && verticalMove == 0)
        {
            movingRotation = Quaternion.Euler(0, -90, 0) * gameObject.transform.parent.rotation;
        }
        else if (horizontalMove == -1 && verticalMove == -1)
        {
            movingRotation = Quaternion.Euler(0, -135, 0) * gameObject.transform.parent.rotation;
        }
        else if (horizontalMove == -1 && verticalMove == 1)
        {
            movingRotation = Quaternion.Euler(0, -45, 0) * gameObject.transform.parent.rotation;
        }
        else if (horizontalMove == 0 && verticalMove == 1)
        {
            movingRotation = Quaternion.Euler(0, 0, 0) * gameObject.transform.parent.rotation;
        }
        else if (horizontalMove == 0 && verticalMove == -1)
        {
            movingRotation = Quaternion.Euler(0, 180, 0) * gameObject.transform.parent.rotation;
        }

        transform.rotation = Quaternion.RotateTowards(this.transform.rotation, movingRotation, lerpSpeed * Time.deltaTime);

        if (transform.localPosition.y != -0.9f)
            transform.localPosition = new Vector3(transform.localPosition.x, -0.9f, transform.localPosition.z);
    }
}
