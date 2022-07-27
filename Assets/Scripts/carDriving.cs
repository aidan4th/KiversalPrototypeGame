using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carDriving : MonoBehaviour
{
    public float setX;
    public Rigidbody rb;
    public AudioClip coinSound;
    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = new Vector3(0,0,-1000);
        rb.angularVelocity = new Vector3(0,0,0);
        rb.rotation = Quaternion.Euler(new Vector3(0,0,0));
    }
    public void start()
    {
        AudioSource.PlayClipAtPoint(coinSound, GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>().position, 10);
    }
}
