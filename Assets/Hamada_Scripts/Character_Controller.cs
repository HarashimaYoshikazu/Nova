using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Controller : MonoBehaviour
{
     Rigidbody rb;
    public float jumpForce = 4000.0f;
    private bool isGround;

    float inputHorizontal;
    float inputVertical;

    Vector3 moving, latestPos;
    public float speed = 10f;

    Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        

        this.animator = GetComponent<Animator>();
    }

    void Update()
    {
        float charaSpeed = rb.velocity.magnitude;

        Debug.Log(charaSpeed);
        //MovementController();
        // Movement();
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxisRaw("Vertical");

        if (isGround == true)
        {
            if (Input.GetKeyDown("space"))
            {

                isGround = false;
                Invoke("Jumping", 0.5f);

                animator.SetTrigger("Jump");
            }


        }
        if(isGround == true)
        {
            
            
                if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
                {
                    animator.SetBool("Walk", true);
                    animator.SetFloat("Speed",charaSpeed);

                }

            if (!Input.anyKey&&charaSpeed < 0.1f)
            {
                animator.SetBool("Walk", false);
                animator.SetFloat("Speed",0.0f);
            }

        }
        
      
        
    }

        void FixedUpdate()
    {
        // RotateToMovingDirection();

        Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
        Vector3 moveForward = cameraForward * inputVertical + Camera.main.transform.right * inputHorizontal;
        rb.velocity = moveForward * speed + new Vector3(0, rb.velocity.y, 0);
        if (moveForward != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.localRotation, Quaternion.LookRotation(moveForward), 0.5f);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Ground")
        {
            isGround = true;

        }

    }

    void Jumping()
    {
        rb.AddForce(new Vector3(0, jumpForce, 0));
    }
    
    /*void MovementController()
    {
        moving = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        moving.Normalize();
        moving = moving * speed;

    }

    void RotateToMovingDirection()
    {
        if (moving.magnitude > 0.001f)
        {
            transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.LookRotation(moving), 0.5f);


        }
        

    }

    void Movement()
    {

        rb.velocity = moving; 
    }
    */
}
