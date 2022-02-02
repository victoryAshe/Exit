using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pwCtrl : MonoBehaviour
{
    private string password;
    private GameObject keyObject;

    ObjectData data;
    void Start()
    {
        data = gameObject.GetComponent<ObjectData>();
        password = data.password;
        
        
    }

    void Update()
    {
        //if(Input.GetKeyDown(KeyCode.F))
    }

    void GoInput()
    {

    }
}
