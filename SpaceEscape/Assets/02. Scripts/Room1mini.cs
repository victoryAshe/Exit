using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room1mini : MonoBehaviour
{
    public GameObject Player;

    void Update()
    {
        //�÷��̾�� ��ü�� ���� �Ÿ��� 5 �����̰�, f ��ư�� �����ٸ�
        if (Vector3.Distance(Player.transform.position, transform.position) < 5 && Input.GetKeyDown(KeyCode.F))
        {
            Vector3 dir;
            dir = Player.transform.position - transform.position;
            //������ ����.
            transform.position += Time.deltaTime * dir;
        }
    }
       
}
