using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room1mini : MonoBehaviour
{

    public GameObject Player;
    public bool open=false;

    void Start()
    {
        Player = GameObject.FindWithTag("PLAYER");
    }
    void Update ()
    {
        Vector3 dir;
        //player�� ���� ������ �Ÿ�=dir
        dir = Player.transform.position - transform.position;

        //�÷��̾�� ��ü�� ���� �Ÿ��� 1 ���ϰ�, f�� ������
        if (Vector3.Distance(Player.transform.position, transform.position) < 1 && Input.GetKeyDown(KeyCode.F))
        {
            //open�� false�� ��������.
            if(open==false)
            {
                transform.position += Time.deltaTime * dir;
                //�̷��ԵǸ� open�� true�� �ȴ�.
                open = true;
            }
            //open�� true�� �� ��
            else
            {
                transform.position -= Time.deltaTime * dir;
            }
            
        }
             
    }
       
}
