using System.Collections;
using System.Globalization;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{      
    /*[REFERENCES]*/
    public PlayerBridgeData playerBridgeData;
    public Animator animator;

    /*[===VARIABLES===]*/
    public Rigidbody rg;
    [SerializeField] float speed = 5.0f;
    [SerializeField] float sprintSpeed = 10.0f;
    [SerializeField] AudioClip walkClip;
    [SerializeField] AudioSource audioSource;
    private float currentSpeed = 0f;
    private float mouseSensitivity = 2.0f;
    private float verticalRotation = 0.0f;
    private Transform cameraTransform;
    private Vector3 movementInput;
    private bool isWalking = false;

    void Awake()
    {
        playerBridgeData = PlayerBridgeData.Instance;
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        playerBridgeData = PlayerBridgeData.Instance; 
        rg.position = playerBridgeData.lastPos;
        rg.freezeRotation = true;
        cameraTransform = Camera.main.transform;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        playerBridgeData.lastPos = playerBridgeData.currPos; 
        playerBridgeData.currPos = rg.transform.position;

        HandleFootstepSound();
        RotateCamera();
        GetMovementInput(); 
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

        isWalking = movementInput.magnitude > 0;
        animator.SetBool("isWalking", isWalking);
    }

    private void HandleFootstepSound()
    {
        if (isWalking && !audioSource.isPlaying)
        {
            audioSource.clip = walkClip;
            audioSource.Play();
        }
        else if (!isWalking && audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }

    private void Movement()
    {
        currentSpeed = Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : speed;
        
        if (movementInput.magnitude > 0)
        {
            Vector3 forward = transform.forward;
            Vector3 right = transform.right;
            
            Vector3 moveDirection = (forward * movementInput.z + right * movementInput.x).normalized;
            Vector3 targetVelocity = moveDirection * currentSpeed;
            rg.linearVelocity = targetVelocity;
            isWalking = true;
        }
        else
        {
            Vector3 velocity = rg.linearVelocity;
            velocity.x = 0;
            velocity.z = 0;
            rg.linearVelocity = velocity;
            isWalking = false;
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