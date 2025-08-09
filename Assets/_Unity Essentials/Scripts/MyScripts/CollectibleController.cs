using UnityEngine;

public class CollectibleController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [Header("Rotation Settings")] 
    public float rotationSpeed = 0.2f;

    [Header("Collectible Settings")] 
    public GameObject onCollectVFX;
    public AudioClip onCollectSFX;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, rotationSpeed, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            Instantiate(onCollectVFX, transform.position, transform.rotation);
            AudioSource.PlayClipAtPoint(onCollectSFX, transform.position);
        }
    }
}