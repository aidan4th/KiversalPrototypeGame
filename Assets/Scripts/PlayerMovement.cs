using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float forwardForce = 2000f;
    public float sidewaysForce = 2000f;

    //Here is the idea there are three different places that our car can be. So an int will hold the different values that the car can be
    public int[] lane = {-4,0,4};
    public int lanePlace = 1;
    private int laneMax; 
    public bool smoothedMovement = false;
    public GameObject carPrefab;

    // Start is called before the first frame update
    void Start()
    {
        laneMax = lane.Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("d"))
        {
            if (lanePlace != laneMax-1) {
                lanePlace++;
                smoothedMovement = false;
                //Debug.Log(lane[lanePlace].ToString());
            }
        }
        if (Input.GetKeyDown("a"))
        {
            if (lanePlace != 0) {
                lanePlace--;
                smoothedMovement = false;
                //Debug.Log(lane[lanePlace].ToString());
            }
        }
        if (Input.GetKeyDown("s"))
        {
            FindObjectOfType<GameManager>().spawnCar();
        }
    }

    //Like update, but is used to even out frames
    void FixedUpdate()
    {
        rb.AddForce(0,0, forwardForce * Time.deltaTime);
        if (rb.position.y < -10f)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
        if ((int)rb.position.x != lane[lanePlace])
        {
            if (rb.position.x > lane[lanePlace])
            {
                if (rb.velocity.x > 0) 
                {
                    rb.velocity = new Vector3(0,0,rb.velocity.z);
                }
                rb.AddForce(-sidewaysForce * Time.deltaTime, 0 ,0, ForceMode.VelocityChange);
            } else {
                if (rb.velocity.x < 0) 
                {
                    rb.velocity = new Vector3(0,0,rb.velocity.z);
                }
                rb.AddForce(sidewaysForce * Time.deltaTime, 0 ,0, ForceMode.VelocityChange);
            }
        } else 
        {
            if (smoothedMovement == false)
            {
                rb.velocity = new Vector3(0,rb.velocity.y,rb.velocity.z);
                rb.rotation = Quaternion.Euler(new Vector3(0,0,0));
                smoothedMovement = true;
            }
            rb.position = new Vector3(lane[lanePlace],rb.position.y,rb.position.z);
            //Debug.Log(rb.position.x);
        }
    }
}