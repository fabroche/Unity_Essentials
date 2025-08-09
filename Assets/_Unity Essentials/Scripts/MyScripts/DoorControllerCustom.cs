using UnityEngine;

public class DoorControllerCustom : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject door;
    public KeyCode openDoorKey = KeyCode.E;

    private bool _isOpen = false;
    private bool _isPlayerInside = false;
    private Animator _doorAnimator;
    
    void Start()
    {
        _doorAnimator = door.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) _isPlayerInside = true;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) _isPlayerInside = true;
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) _isPlayerInside = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(openDoorKey) && _isPlayerInside)
        {
            if (_isOpen)
            {
                CloseDoor();
            }
            else
            {
                OpenDoor();
            }
        }
    }

    private void OpenDoor()
    {
        _isOpen = true;
        UnityEngine.Debug.Log("Open the door");
        _doorAnimator.SetBool("Is_Open", _isOpen);
    }

    private void CloseDoor()
    {
        _isOpen = false;
        UnityEngine.Debug.Log("Close the door");
        _doorAnimator.SetBool("Is_Open", _isOpen);
    }
}