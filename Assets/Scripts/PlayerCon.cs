using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// Player Controler, using new input system of Unity.
// Controls: WASD or Arrow Keys

public class PlayerCon : MonoBehaviour
{
    private CostumInput input = null;
    private Vector2 moveVector = Vector2.zero;
    private Rigidbody2D RB = null;
    public float MoveSpeed = 5;
    private Animator animator = null;
    private bool isRotated = false;
    private bool isFacingRight = true;
    public GameObject Box;
    public GameObject Shop;
    public bool nearshop = false;
   
    private void Awake()
    {
        input = new CostumInput();
        RB = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    private void OnEnable()
    {
        input.Enable();
        input.Player.Movement.performed += OnMovementPerformed;
        input.Player.Movement.canceled += OnMovementCancelled;
    }
    private void OnDisable()
    {
        input.Disable();
        input.Player.Movement.performed -= OnMovementPerformed;
        input.Player.Movement.canceled -= OnMovementCancelled;
        
    }
    private void Update()
    {
        // Flip the player character based on the movement direction
        if (moveVector.x < 0 && isFacingRight)
        {
            FlipCharacter();
        }
        else if (moveVector.x > 0 && !isFacingRight)
        {
            FlipCharacter();
        }

        // Set the appropriate animation based on the movement direction
        if (Mathf.Approximately(moveVector.x, 0))
        {
            animator.SetBool("IsRunning", false);
        }
        else
        {
            animator.SetBool("IsRunning", true);
        }

        if (nearshop)
        {
            bool isSpaceKeyHeld = input.Player.Space.ReadValue<float>() > 0.1f;
            if (isSpaceKeyHeld)
            {
                Shop.SetActive(true);
                nearshop = false;
            }
        }
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Box"))
        {
            Box.SetActive(true);
            nearshop = true;
        }
       
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Box"))
        {
            Box.SetActive(false);
            nearshop = false;
        }

    }
    private void FixedUpdate()
    {
        RB.velocity = moveVector * MoveSpeed;
        animator.SetFloat("Speed", moveVector.magnitude);
        Debug.Log(moveVector);
    }
    private void OnMovementPerformed(InputAction.CallbackContext value)
    {
        moveVector = value.ReadValue<Vector2>();
        animator.SetFloat("X", moveVector.x);
        animator.SetFloat("Y", moveVector.y);
        animator.SetBool("IsWalking", true);
       
    }
    private void OnMovementCancelled(InputAction.CallbackContext value)
    {
        moveVector = Vector2.zero;
        animator.SetBool("IsWalking", false);
    }
    private void FlipCharacter()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}
