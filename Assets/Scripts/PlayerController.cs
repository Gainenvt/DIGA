using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private PlayerInputActions input;
    private Rigidbody rb;
    private Vector2 moveInput;
    private Vector2 lookInput;
    private float xRotation = 0f;
    public float JumpForce = 5f;
    public float moveSPD = 3f;
    public float LookSpeed = 10f;
    public Transform PlayerCamera;
    public bool isSwiming = false;

    
    private void Awake()
    {
        input = new PlayerInputActions();
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        input.Enable();

        input.Player.Move.performed += OnMove;
        input.Player.Move.canceled += OnMove;

        input.Player.Look.performed += OnLook;
        input.Player.Look.canceled += OnLook;

        input.Player.Jump.performed += OnJump;
    }

    private void OnDisable()
    {
        input.Player.Move.performed -= OnMove;
        input.Player.Move.canceled -= OnMove;

        input.Player.Look.performed -= OnLook;
        input.Player.Look.canceled -= OnLook;

        input.Player.Jump.performed -= OnJump;

        input.Disable();
    }
    private void FixedUpdate()
    {
        Move();


    }
    private void Update()
    {
        Look();
       
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    private void OnLook(InputAction.CallbackContext context)
    {
        lookInput = context.ReadValue<Vector2>();
    }

    private void OnJump(InputAction.CallbackContext context)
    {
        Jump();
    }

    private void Move()
    {   Vector3 movement = transform.right * moveInput.x + transform.forward * moveInput.y;

    rb.linearVelocity = new Vector3(movement.x * moveSPD, rb.linearVelocity.y, movement.z * moveSPD);

    }


    private void Look()
    {   //horizontal mouse movement x 
        transform.Rotate(Vector3.up * lookInput.x * LookSpeed * Time.deltaTime);
        //vertical mouse movement v
        xRotation -= lookInput.y * LookSpeed * Time.deltaTime;
        //clamp prevention 
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        PlayerCamera.localRotation = Quaternion.Euler(xRotation, 0f , 0f);
    }

    private void Jump()
    {
        rb.AddForce(Vector3.up * JumpForce, ForceMode .Impulse);
    }

    private void OnTriggerEnter(Collider PlayerCollider)
    {
        if (PlayerCollider.CompareTag("Player"))
        {
            
        }
    }

//u aint done it only checks if this is the player
}