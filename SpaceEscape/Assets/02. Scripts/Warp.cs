using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class warp : MonoBehaviour
{
    public GameObject StartPos;
    public GameObject EndPos;

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            StartPos = col.gameObject;

            StartPos.transform.position = EndPos.transform.position;
        }
    }

}
