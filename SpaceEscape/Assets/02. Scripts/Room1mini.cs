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
        //player와 서랍 사이의 거리=dir
        dir = Player.transform.position - transform.position;

        //플레이어와 물체의 사이 거리가 1 이하고, f를 누르면
        if (Vector3.Distance(Player.transform.position, transform.position) < 1 && Input.GetKeyDown(KeyCode.F))
        {
            //open이 false면 문을연다.
            if(open==false)
            {
                transform.position += Time.deltaTime * dir;
                //이렇게되면 open은 true가 된다.
                open = true;
            }
            //open이 true면 문 닫
            else
            {
                transform.position -= Time.deltaTime * dir;
            }
            
        }
             
    }
       
}
