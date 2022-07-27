using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killYourSelf : MonoBehaviour
{
    public GameObject thisOb;
    void Start()
    {
        Destroy(thisOb, 12f);
    }
}
