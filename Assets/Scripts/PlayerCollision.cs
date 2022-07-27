using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement movement;
    public AudioClip deathSound;
    // Update is called once per frame
    void OnCollisionEnter(Collision collisionInfo) {
        if (collisionInfo.collider.tag == "Obstacle")
        {
            movement.enabled = false;

            AudioSource.PlayClipAtPoint(deathSound, GetComponent<Rigidbody>().position, 10);
            FindObjectOfType<GameManager>().EndGame();
            Rigidbody rb = movement.GetComponentInParent<Rigidbody>();
            rb.angularDrag = 0;
            rb.mass = 0;
        }
    }
}