using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room1mini : MonoBehaviour
{

    public GameObject Player;
    void Start()
    {
        Player = GameObject.FindWithTag("PLAYER");
    }
    void Update ()
    {
        Vector3 dir;
        //player�� ���� ������ �Ÿ�=dir
        dir = Player.transform.position - transform.position;

        //�÷��̾�� ��ü�� ���� �Ÿ��� 5 �����̰�, f ��ư�� �����ٸ�
        if (Vector3.Distance(Player.transform.position, transform.position) < 5 && Input.GetKeyDown(KeyCode.F))
        {
            //������ ����.
            transform.position += Time.deltaTime * dir;
        }
        
        if(Input.GetKeyDown(KeyCode.F))
        {
            //������ �ݴ´�. 
            transform.position -= Time.deltaTime * dir;
        }
        
    }
       
}
