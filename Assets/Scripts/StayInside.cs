using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayInside : MonoBehaviour
{
 


    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -5.5f, 5.5f),
            Mathf.Clamp(transform.position.y, -5.5f, 5.5f), transform.position.z);
    }
}
