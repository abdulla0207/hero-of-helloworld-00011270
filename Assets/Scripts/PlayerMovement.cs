using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    private Animator animator;
    public GameObject Weapon;

    public float Speed = 2.5f;
    public float gravity = -9f;
    public float jumpHeight = 2f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;
    byte eCounter = 0;
    Vector3 velocity;
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0) 
        {
            velocity.y = -2f;
        }

        //Player movement
        Vector3 move = transform.right * Input.GetAxis("Horizontal") + transform.forward * Input.GetAxis("Vertical");
        controller.Move(move * Speed * Time.deltaTime);

        //Gravity of the Player
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        //If the user presses the Space bar and the player is on Ground
        // the player will jump
        if(Input.GetKey(KeyCode.Space) && isGrounded)
        {
            animator.SetBool("isSpaceBarPressed", true);
            velocity.y = Mathf.Sqrt(jumpHeight * (-1) * gravity);
        }
        

        //Checks for the keyboard input and by changing the value of booleans
        // different animation will play
        Animation(move);
        FireAnimation();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Cube")
        {
            animator.SetBool("nearBlock", true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Cube")
        {
            animator.SetBool("nearBlock", false);
        }
    }
    private void Animation(Vector3 move)
    {
        if (move != Vector3.zero)
        {
            animator.SetBool("isMoving", true);
            if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
            {
                animator.SetBool("isRunning", true);
                controller.Move(move * (Speed*1.2f) * Time.deltaTime);
            }
            else
            {
                animator.SetBool("isRunning", false);
            }
            if (Input.GetKey(KeyCode.S))
            {
                animator.SetBool("isSPressed", true);
            }
            else
            {
                animator.SetBool("isSPressed", false);
            }
        }
        else
        {
            animator.SetBool("isMoving", false);
        }

        if (Input.GetKeyDown(KeyCode.E) && animator.GetBool("nearBlock"))
        {
            Weapon.SetActive(false);
            animator.SetBool("isEPressed", true);
            eCounter++;
        }
        if (eCounter == 2)
        {
            Weapon.SetActive(true);
            animator.SetBool("isEPressed", false);
            eCounter = 0;
        }
    }

    private void FireAnimation()
    {
    }
}
