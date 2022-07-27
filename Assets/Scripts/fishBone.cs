using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fishBone : MonoBehaviour
{
    public bool collisionTriggered = false;
    private Material myMat;
    public GameObject particleEffect;
    public AudioClip coinSound;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (collisionTriggered == true) {

        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            collisionTriggered = true;
            AudioSource.PlayClipAtPoint(coinSound, GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>().position, 10);
            GameObject memMang = Instantiate(particleEffect, GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>().position, new Quaternion(0,0,0,0));
            GameObject.FindGameObjectWithTag("Respawn").GetComponent<Score>().addScore(100);
            Destroy(gameObject);
        }
    }
}
