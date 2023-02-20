using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TImmeeeeeee : MonoBehaviour
{
    [SerializeField] Timer timer1;

    private void Start()
    {
        timer1.SetDuration(40).Begin();
    }
}



