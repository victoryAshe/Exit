using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBox : MonoBehaviour
{
    public GameObject player;
    public bool open = false;
    public GameObject EndPos;
    Vector3 originPos;
    private float speed = 2.0f;

    void Start()
    {
        originPos = transform.position;
        originPos.z -= 5.0f;
        player = GameObject.FindWithTag("PLAYER");

    }
    IEnumerator OpenTrue()
    {
        for (int num = 0; num < 18; num++)
        {
            Vector3 dir = EndPos.transform.position - transform.position;
            dir = dir.normalized;
            yield return new WaitForSeconds(0.1f);
            //open 불변수가 false라면

            //서랍을 연다.
            transform.position += dir * Time.deltaTime *speed;
            //open을 true로 바꾼다.

        }
        open = true;
    }
    IEnumerator OpenFalse()
    {
        //플레이어와 서랍사이의 거리가 3미만일동안
        for (int num = 0; num < 18; num++)
        {
            Vector3 dir = originPos - transform.position;
            dir = dir.normalized;

            yield return new WaitForSeconds(0.1f);
            //open 불변수가 true 라면

            transform.position -= Time.deltaTime * dir*speed;
        }
        open = false;
    }
    void Update()
    {
        //f버튼을 누르고, player과 상자 사이의 거리가 3 미만이면 문열닫기함
        if (Input.GetKeyDown(KeyCode.F)&&Vector3.Distance(player.transform.position,transform.position)<5)
        {
            if (open)
                StartCoroutine(OpenFalse());
            else
                StartCoroutine(OpenTrue());
        }
    }

}
 