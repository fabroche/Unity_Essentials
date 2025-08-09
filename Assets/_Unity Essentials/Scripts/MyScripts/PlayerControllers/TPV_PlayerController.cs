using UnityEngine;

public class TPV_PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [Header("Camera Settings")]
    public Camera playerCamera;
    public float baseFOV = 60f;
    public float sprintFOV = 75f;
    public float fovSpeed = 2f;
    public bool useFOV = true;
    private float _targetFOV;
    
    [Header("Movement Settings")]
    [SerializeField] private float speed = 2f;
    [SerializeField] private float rotationSpeed = 100f;
    
    [Header("Input Settings")]
    [SerializeField] private string verticalInputAxis = "Vertical";
    [SerializeField] private string horizontalInputAxis = "Horizontal";
    
    // Cached components
    private Rigidbody _rb;
    
    // Input caching for performance
    private float _moveVertical;
    private float _moveHorizontal;
    
    private void Awake()
    {
        // Cache Rigidbody component once
        _rb = GetComponent<Rigidbody>();
        
        // Validate required components
        if (_rb == null)
        {
            UnityEngine.Debug.LogError($"Rigidbody component missing on {gameObject.name}");
            enabled = false;
        }
    }
    
    private void Start()
    {
        if (playerCamera == null) {
            playerCamera = Camera.main;
        }
        
        baseFOV = playerCamera.fieldOfView;
        _targetFOV = baseFOV;
    }

    private void Update()
    {
        // Capture input in Update for better responsiveness
        CaptureInput();
        
        if (useFOV)
        {
            HandleFOV();
        }
    }

    private void FixedUpdate()
    {
        // Apply movement and rotation in FixedUpdate for physics
        HandleMovement();
        HandleRotation();
    }

    private void CaptureInput()
    {
        _moveVertical = Input.GetAxis(verticalInputAxis);
        _moveHorizontal = Input.GetAxis(horizontalInputAxis);
    }

    private void HandleFOV()
    {
        _targetFOV = _moveVertical > 0.1f ? sprintFOV : baseFOV;

        playerCamera.fieldOfView = Mathf.Lerp(
            playerCamera.fieldOfView,
            _targetFOV,
            fovSpeed * Time.deltaTime
        );
    }

    private void HandleMovement()
    {
        // Early return if no vertical input
        if (_moveVertical == 0f)
            return;

        Vector3 movement = transform.forward * _moveVertical * speed * Time.fixedDeltaTime;
        _rb.MovePosition(_rb.position + movement);
    }

    private void HandleRotation()
    {
        // Early return if no horizontal input
        if (_moveHorizontal == 0f)
            return;

        float turn = _moveHorizontal * rotationSpeed * Time.fixedDeltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
        _rb.MoveRotation(_rb.rotation * turnRotation);
    }

    // Optional: Method to update speed at runtime
    public void SetMovementSpeed(float newSpeed)
    {
        speed = Mathf.Max(0f, newSpeed);
    }

    public void SetRotationSpeed(float newRotationSpeed)
    {
        rotationSpeed = Mathf.Max(0f, newRotationSpeed);
    }
}
