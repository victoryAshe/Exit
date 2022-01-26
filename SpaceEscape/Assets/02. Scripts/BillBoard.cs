using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillBoard : MonoBehaviour
{
    public Transform target;

    void Start()
    {
        target = GameObject.FindWithTag("PLAYER").GetComponent<Transform>();
    }

    void Update()
    {
        transform.forward = target.forward;
        
    }
}
