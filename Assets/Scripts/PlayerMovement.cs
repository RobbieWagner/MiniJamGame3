using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour {

    public CharacterController player;
    PlayerControls playerControls;

    [SerializeField] private float speed = 5f;
    private Vector2 moveInput;

    [SerializeField] private float gravity = -9.81f;
    private float velocityY;
    [SerializeField] private LayerMask groundMask;
    private bool isGrounded;

    public static PlayerMovement Instance {get; private set;}

    private void Awake() 
    {
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
        } 

        velocityY = 0;
        playerControls = new PlayerControls();
    }

    private void Update()
    {
        velocityY += gravity * Time.deltaTime;
        isGrounded = Physics.CheckSphere(transform.position, 1f, groundMask);
        if (isGrounded) 
        {
            velocityY = 0;
        }

        Vector3 velocity = (transform.right * moveInput.x + transform.forward * moveInput.y) * speed;
        velocity.y = velocityY;
        player.Move(velocity * Time.deltaTime);
    }

    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }
}