using System.Linq;
using UnityEngine;

public class OnCollideSFX : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [Header("Bounce SFX")]
    public AudioClip bounceSFX;

    public string[] canCollitionTags;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        UnityEngine.Debug.Log($"Colision con tag: {collision.gameObject.tag}", this);
        if(canCollitionTags.Contains(collision.gameObject.tag)) AudioSource.PlayClipAtPoint(bounceSFX, transform.position);
    }
}
