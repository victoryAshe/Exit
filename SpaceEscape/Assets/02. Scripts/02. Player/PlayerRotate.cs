using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotate : MonoBehaviour
{
    private float rotSpeed = 200f;
    private float mx = 0; //회전 값 변수
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isGameOver || GameManager.instance.isGamePaused 
            || GameManager.instance.isShowScript || GameManager.instance.isShowPanel|| GameManager.instance.isShowAlpha) return;

        float mouseX = Input.GetAxis("Mouse X");
        mx += mouseX * rotSpeed * Time.deltaTime;
        transform.eulerAngles = new Vector3(0, mx, 0);
    }
}
