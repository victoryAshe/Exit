using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room1mini : MonoBehaviour
{
    public GameObject Player;

    void Update()
    {
        //플레이어와 물체의 사이 거리가 5 이하이고, f 버튼을 누른다면
        if (Vector3.Distance(Player.transform.position, transform.position) < 5 && Input.GetKeyDown(KeyCode.F))
        {
            Vector3 dir;
            dir = Player.transform.position - transform.position;
            //서랍을 연다.
            transform.position += Time.deltaTime * dir;
        }
    }
       
}
