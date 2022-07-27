using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This object eats other objects that are out of screen.
public class gobble : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    public GameObject levelPrefab;
    public GameObject[] obstaclePrefab;
    void Update()
    {
        transform.position = player.position + offset;
    }
    void OnTriggerEnter(Collider other) {
        if (other.gameObject.name == "BackgroundCreator") {
            Debug.Log("New background level created");
            GameObject memMang = Instantiate(levelPrefab, offset + new Vector3(-19.54819f,-1.4704612f, player.position.z + 355), new Quaternion(0,0,0,0));
            GameObject memMang2 = Instantiate(obstaclePrefab[Random.Range(0,obstaclePrefab.Length)], offset + new Vector3(-10+2.515f,1+0.138261f, player.position.z + 200), new Quaternion(0,0,0,0));
            Destroy(memMang, 15f);
            Destroy(memMang2, 15f);
        }
        //Debug.Log("Object Destroyed");
        Destroy(other.gameObject);
    }
}

