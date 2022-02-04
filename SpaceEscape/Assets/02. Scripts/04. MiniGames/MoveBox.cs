using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBox : MonoBehaviour
{
    public GameObject player;
    public bool open = false;
    public GameObject EndPos;
    Vector3 originPos;
    void Start()
    {
        originPos = transform.position;
        originPos.z -= 3.0f;
        player = GameObject.FindWithTag("PLAYER");

    }
    IEnumerator OpenTrue()
    {
        for (int num = 0; num < 5; num++)
        {
            Vector3 dir = EndPos.transform.position - transform.position;
            dir = dir.normalized;
            yield return new WaitForSeconds(0.1f);
            //open �Һ����� false���

            //������ ����.
            transform.position += dir * Time.deltaTime;
            //open�� true�� �ٲ۴�.

        }
        open = true;
    }
    IEnumerator OpenFalse()
    {
        //�÷��̾�� ���������� �Ÿ��� 3�̸��ϵ���
        for (int num = 0; num < 5; num++)
        {
            Vector3 dir = originPos - transform.position;
            dir = dir.normalized;

            yield return new WaitForSeconds(0.1f);
            //open �Һ����� true ���

            transform.position -= Time.deltaTime * dir;
        }
        open = false;
    }
    void Update()
    {
        //f��ư�� ������, player�� ���� ������ �Ÿ��� 3 �̸��̸� �����ݱ���
        if (Input.GetKeyDown(KeyCode.F)&&Vector3.Distance(player.transform.position,transform.position)<3)
        {
            if (open)
                StartCoroutine(OpenFalse());
            else
                StartCoroutine(OpenTrue());
        }
    }

}
 