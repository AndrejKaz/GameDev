using UnityEngine;

public class PlayerController : MonoBehaviour
{
    /*[===MOVEMENT===]*/
    public Rigidbody rg;
    [SerializeField] float speed = 5.0f;
    [SerializeField] float sprintSpeed = 10.0f;
    private float currentSpeed = 0f;
    
    /*[===CAMERA===]*/
    private float mouseSensitivity = 2.0f;
    private float verticalRotation = 0.0f;
    private Transform cameraTransform;
    private Vector3 movementInput;

    void Start()
    {
        rg.freezeRotation = true;
        
        cameraTransform = Camera.main.transform;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        GetMovementInput();
        RotateCamera();
    }

    void FixedUpdate()
    {
        Movement();
    }

    private void GetMovementInput()
    {
        movementInput = Vector3.zero;
        
        if (Input.GetKey(KeyCode.W))
            movementInput.z += 1;
        if (Input.GetKey(KeyCode.S))
            movementInput.z -= 1;
        if (Input.GetKey(KeyCode.A))
            movementInput.x -= 1;
        if (Input.GetKey(KeyCode.D))
            movementInput.x += 1;   
    }

    private void Movement()
    {
        currentSpeed = Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : speed;
        
        //Make sure there is no inverse movement when looking with the camera
        if (movementInput.magnitude > 0)
        {
            //Get the forward direction relative to where the character is facing
            Vector3 forward = transform.forward;
            Vector3 right = transform.right;
            
            //Make movement relative to character's rotation
            Vector3 moveDirection = (forward * movementInput.z + right * movementInput.x).normalized;
            
            //Apply movement
            Vector3 targetVelocity = moveDirection * currentSpeed;
            
            rg.linearVelocity = targetVelocity;
        }
        else
        {
            Vector3 velocity = rg.linearVelocity;
            velocity.x = 0;
            velocity.z = 0;
            rg.linearVelocity = velocity;
        }
    }

    private void RotateCamera()
    {
        float horizontalRotation = Input.GetAxis("Mouse X") * mouseSensitivity;
        transform.Rotate(0, horizontalRotation, 0);

        verticalRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        verticalRotation = Mathf.Clamp(verticalRotation, -30f, 45f);

        cameraTransform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);
    }
}