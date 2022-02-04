using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCam : MonoBehaviour
{
    //회전 값 변수
    private float mx = 0; private float my = 0;
    private float rotSpeed = 200f;

    void Start()
    {

    }

    void Update()
    {
        if (GameManager.instance.isGameOver || GameManager.instance.isGamePaused || GameManager.instance.isShowScript || GameManager.instance.isShowPanel) return;

        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        //회전 값 변수에 마우스 입력 값만큼 미리 누적시킴
        mx += mouseX * rotSpeed * Time.deltaTime;
        my += mouseY * rotSpeed * Time.deltaTime;

        //상하 이동 회전(y축) 값을 -90~90도 사이로 제한
        my = Mathf.Clamp(my, -90f, 90f);

        //상하 회전(x축) 값을 -90~90도 사이로 제한
        //* 주석처리 하지 않으면 계속 돌아가서 Player 얼굴이 보인다. 주석 처리 시 정상 작동
        //mx = Mathf.Clamp(mx, -90f, 90f);

        transform.eulerAngles = new Vector3(-my, mx, 0);
    }
}
