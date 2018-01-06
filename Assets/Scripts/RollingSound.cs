using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingSound : MonoBehaviour {
    private float speed;
    private Rigidbody rigidBody;
    private AudioSource ballSoundSource;
    private AudioSource hitSoundSource;

    // Use this for initialization
    void Start () {
        rigidBody = GetComponent<Rigidbody>();
        if (rigidBody == null)
            Debug.LogError("Rigidbody not found");
        var sources = GetComponents<AudioSource>();
        ballSoundSource = sources[0];
        hitSoundSource = sources[1];
        if (ballSoundSource == null)
            Debug.LogError("Ball-AudioSource not found");
        if (hitSoundSource == null)
            Debug.LogError("Hit-AudioSource not found");
    }

    private void FixedUpdate()
    {
        speed = rigidBody.velocity.magnitude;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Wall") && collision.relativeVelocity.magnitude >= 3f)
        {
            hitSoundSource.volume = collision.relativeVelocity.magnitude * 0.005f;
            Debug.Log("volume = " + hitSoundSource.volume);
            hitSoundSource.Play();
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        ballSoundSource.volume = speed * 0.1f;
        if (ballSoundSource.isPlaying == false && speed >= 0.2f)
        {
            ballSoundSource.Play();
        }
        else if (ballSoundSource.isPlaying == true && speed < 0.2f)
        {
            ballSoundSource.Pause();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (ballSoundSource.isPlaying == true)
        {
            ballSoundSource.Pause();
        }
    }
}
