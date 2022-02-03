using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCam : MonoBehaviour
{
    //ȸ�� �� ����
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

        //ȸ�� �� ������ ���콺 �Է� ����ŭ �̸� ������Ŵ
        mx += mouseX * rotSpeed * Time.deltaTime;
        my += mouseY * rotSpeed * Time.deltaTime;

        //���� �̵� ȸ��(y��) ���� -90~90�� ���̷� ����
        my = Mathf.Clamp(my, -90f, 90f);

        //���� ȸ��(x��) ���� -90~90�� ���̷� ����
        //* �ּ�ó�� ���� ������ ��� ���ư��� Player ���� ���δ�. �ּ� ó�� �� ���� �۵�
        //mx = Mathf.Clamp(mx, -90f, 90f);

        transform.eulerAngles = new Vector3(-my, mx, 0);
    }
}
