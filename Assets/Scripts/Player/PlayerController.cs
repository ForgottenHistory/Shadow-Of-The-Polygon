using UnityEngine;

public class PlayerController : MonoBehaviour, IInitialize
{
    ////////////////////////////////////////////////////////////////////
    // PUBLIC VARIABLES
    ////////////////////////////////////////////////////////////////////

    public float speed = 3.0f;
    public float rotateSpeed = 3.0f;

    public float jumpSpeed = 8.0f;

    public float gravity = 1000.0f;

    ////////////////////////////////////////////////////////////////////
    // PRIVATE VARIABLES
    ////////////////////////////////////////////////////////////////////

    CharacterController controller;
    CameraController cameraController;
    Vector3 moveDirection = Vector3.zero;

    private float verticalVelocity = 0.0f;

    ////////////////////////////////////////////////////////////////////

    public bool isActive { get; set; } = false;

    ////////////////////////////////////////////////////////////////////

    public void Initialize()
    {
        controller = GetComponent<CharacterController>();
        cameraController = GetComponentInChildren<CameraController>();
        cameraController.Initialize();

        isActive = true;
    }

    ////////////////////////////////////////////////////////////////////

    public void Deinitialize()
    {
        isActive = false;
    }

    ////////////////////////////////////////////////////////////////////

    void Update()
    {
        if (!isActive) return;

        Movement();
    }

    ////////////////////////////////////////////////////////////////////

    void Movement()
    {
        // Get the inputs for horizontal and vertical axis (WASD or arrow keys by default)
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Create a new vector of direction for the character
        Vector3 move = new Vector3(moveHorizontal, 0, moveVertical);
        move = transform.TransformDirection(move);

        // Multiply it by the speed
        move *= speed;

        Jump();

        // Apply gravity to the vertical velocity
        verticalVelocity -= gravity * Time.deltaTime;

        // Assign verticalVelocity to moveDirection.y
        move.y = verticalVelocity;

        // Move the character
        controller.Move(move * Time.deltaTime);
    }
    
    ////////////////////////////////////////////////////////////////////

    void Jump()
    {
        // If the character is grounded and the player presses "Jump", then the character jumps
        if (controller.isGrounded)
        {
            // If we're grounded, the vertical velocity should be 0
            verticalVelocity = 0;

            if (Input.GetButtonDown("Jump"))
            {
                verticalVelocity = jumpSpeed;
            }
        }
    }

    ////////////////////////////////////////////////////////////////////
}

////////////////////////////////////////////////////////////////////

public interface IInitialize
{
    public bool isActive { get; set; }
    public void Initialize();
    public void Deinitialize();
}

////////////////////////////////////////////////////////////////////
