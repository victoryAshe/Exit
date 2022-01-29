using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class warp : MonoBehaviour
{
    public GameObject StartPos;
    public GameObject EndPos;

    void warpRoutine()
    {
        StartPos.transform.position = EndPos.transform.position;
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            StartPos = col.gameObject;

            //2�ʵ� warp ����
            Invoke("warpRoutine", 2);
        }
    }

}