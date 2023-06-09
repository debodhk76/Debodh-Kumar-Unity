using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float rotationSpeed = 720f;
    public float jumpButtonGracePeriod;
    public float jumpSpeed = 5f;

    [SerializeField] private float jumpHorizontalSpeed;
    private CharacterController characterController;
    [SerializeField] private Transform cameraTransform;
    private float ySpeed;
    private float originalStepOffset;
    private float? lastGroundedTime;
    private float? jumpButtonPressedTime;
    private Animator animator;
    private bool isJumping;
    private bool IsGrounded;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator= GetComponent<Animator>();
        originalStepOffset = characterController.stepOffset;
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(horizontalInput, 0f, verticalInput);

        float inputMagnitude = Mathf.Clamp01(movementDirection.magnitude);

        if(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            inputMagnitude /= 2;
        }

        animator.SetFloat("Input Magnitude", inputMagnitude, 0.07f, Time.deltaTime);

        movementDirection = Quaternion.AngleAxis(cameraTransform.rotation.eulerAngles.y, Vector3.up) * movementDirection;

        movementDirection.Normalize();

        ySpeed += Physics.gravity.y * Time.deltaTime;

        if(characterController.isGrounded)
        {
            lastGroundedTime = Time.time;
        }

        if(Input.GetButtonDown("Jump"))
        {
            jumpButtonPressedTime = Time.time;
        }

        if (Time.time - lastGroundedTime <= jumpButtonGracePeriod)
        {
            characterController.stepOffset = originalStepOffset;
            ySpeed = -0.5f;
            animator.SetBool("IsGrounded", true); 
            IsGrounded= true;
            animator.SetBool("IsJumping", false);
            isJumping= false;
            animator.SetBool("IsFalling", false);

            if (Time.time - jumpButtonPressedTime <= jumpButtonGracePeriod)
            {
                ySpeed = jumpSpeed;
                animator.SetBool("IsJumping", true);
                isJumping = true;
                jumpButtonPressedTime = null;
                lastGroundedTime = null;
            }
        }

        else
        {
            characterController.stepOffset = 0;
            animator.SetBool("IsGrounded", false);
            IsGrounded= false;

            if((isJumping && ySpeed < 0) || ySpeed < -2)
            {
                animator.SetBool("IsFalling", true);
            }
        }

        

        if(movementDirection != Vector3.zero) 
        {
            animator.SetBool("IsMoving", true);

            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
        else
        {
            animator.SetBool("IsMoving", false);
        }

        if(IsGrounded == false)
        {
            Vector3 velocity = movementDirection * inputMagnitude * jumpHorizontalSpeed;
            velocity.y = ySpeed;

            characterController.Move(velocity * Time.deltaTime);
        }

    }

    private void OnAnimatorMove()
    {
        if (IsGrounded)
        {
            Vector3 velocity = animator.deltaPosition;

            velocity.y = ySpeed * Time.deltaTime;

            characterController.Move(velocity);
        }
    }

    private void OnApplicationFocus(bool focus)
    {
        if(focus)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
