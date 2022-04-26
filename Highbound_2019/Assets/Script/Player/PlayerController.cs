using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private Animator anim;

    private Transform cam;

    private float moveSpeed = 20f;
    private float jumpForce = 10f;
    private float jumpTime = 0.2f;
    private float maxVelocity = 10f;

    public bool isGrounded = true;
    [SerializeField]private bool jump = false;

    private float mouseX = 0;
    private float cameraSpeed = 500f;
    private Vector3 camF;
    private Vector3 camR;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        anim = gameObject.transform.GetChild(0).GetComponent<Animator>();
        cam = GameObject.Find("Main Camera").transform;
    }

    private void Update()
    {
        if (isGrounded == false && jumpTime > 0)
        {
            jumpTime -= Time.deltaTime;
        }
        playerMove();
        playerAim();
        playerAttack();
    }

    private void FixedUpdate()
    {
        if(jump == true && jumpTime > 0)
        {
            rb.AddForce(jumpForce * Vector3.up, ForceMode.Impulse);
            jump = false;
            isGrounded = false;
        }

        if (Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
        {
            rb.AddForce(moveSpeed * transform.forward);
        }
        else if (Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.W))
        {
            rb.AddForce(moveSpeed * -transform.forward);
        }

        if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
        {
            rb.AddForce(moveSpeed * transform.right);
        }
        else if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            rb.AddForce(moveSpeed * -transform.right);
        }

        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxVelocity);
    }

    private void playerMove()
    {
        if (jump == false && isGrounded == true)
            jump = Input.GetKeyDown(KeyCode.Space);
    }

    private void playerAim()
    {
        mouseX = Input.GetAxis("Mouse X");

        this.transform.rotation = this.transform.rotation * Quaternion.Euler(0, mouseX * cameraSpeed * Time.deltaTime, 0);
    }

    private void playerAttack()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Sword And Shield Idle") && anim.GetBool("isAttacking") == true)
        {
            anim.SetBool("isAttacking", false);
        }

        if (anim.GetBool("isAttacking") == false && Input.GetMouseButtonDown(0))
        {
            anim.SetBool("isAttacking", true);
        }
    }

    private void OnTriggerStay(Collider c)
    {
        isGrounded = true;
        jumpTime = 0.2f;
    }
}
