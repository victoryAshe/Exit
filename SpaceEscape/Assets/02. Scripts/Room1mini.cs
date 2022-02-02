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
        //player와 서랍 사이의 거리=dir
        dir = Player.transform.position - transform.position;

        //플레이어와 물체의 사이 거리가 5 이하이고, f 버튼을 누른다면
        if (Vector3.Distance(Player.transform.position, transform.position) < 5 && Input.GetKeyDown(KeyCode.F))
        {
            //서랍을 연다.
            transform.position += Time.deltaTime * dir;
        }
        
        if(Input.GetKeyDown(KeyCode.F))
        {
            //서랍을 닫는다. 
            transform.position -= Time.deltaTime * dir;
        }
        
    }
       
}
