using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private Animator anim;

    private Transform cam;

    [SerializeField]
    private float moveSpeed = 20f;
    [SerializeField]
    private float jumpForce = 10f;
    private float jumpTime = 0.2f;
    [SerializeField]
    private float maxVelocity = 10f;

    public bool isGrounded = true;
    [SerializeField]private bool jump = false;

    private float mouseX = 0;
    [SerializeField]
    private float cameraSpeed = 900f;
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
        if (rb.velocity != Vector3.zero)
            anim.SetBool("isMoving", true);
        else
            anim.SetBool("isMoving", false);

    }

    private void FixedUpdate()
    {
        if(jump == true && jumpTime > 0)
        {
            rb.AddForce(jumpForce * Vector3.up, ForceMode.Impulse);
            jump = false;
            isGrounded = false;
            anim.SetBool("isJumping", false);
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

        float y = rb.velocity.y;

        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxVelocity);

        Vector3 localVelocity = transform.InverseTransformDirection(rb.velocity);
        localVelocity.y = y;

        rb.velocity = transform.TransformDirection(localVelocity);
        
    }

    private void playerMove()
    {
        if (jump == false && isGrounded == true)
        {
            jump = Input.GetKeyDown(KeyCode.Space);
            if (jump == true)
            {
                if (anim.GetCurrentAnimatorStateInfo(0).IsName("Standing Jump"))
                    anim.Play("Standing Jump", 0, 0f);
                anim.SetBool("isJumping", true);
            }
        }

    }

    private void playerAim()
    {
        mouseX = Input.GetAxis("Mouse X");

        Quaternion rot = this.transform.rotation * Quaternion.Euler(0, mouseX * cameraSpeed * Time.deltaTime, 0);

        this.transform.rotation = Quaternion.Lerp(this.transform.rotation, rot, 0.1f);
    }

    private void playerAttack()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Standing Idle") && anim.GetBool("isAttacking") == true)
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
