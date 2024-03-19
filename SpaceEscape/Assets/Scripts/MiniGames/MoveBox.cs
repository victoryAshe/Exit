using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBox : MonoBehaviour
{
    GameObject player;
    public bool isOpened = false;
    bool isOpening = false;
    public GameObject EndPos;
    Vector3 originPos;
    private float speed = 5.0f;

    WaitForSeconds wfs = new WaitForSeconds(0.01f);

    void Start()
    {
        originPos = transform.localPosition;
        player = GameObject.FindWithTag("PLAYER");

    }

    void Update()
    {
        //f버튼을 누르고, player과 상자 사이의 거리가 3 미만이면 문열닫기함
        if (Input.GetKeyDown(KeyCode.F) && Vector3.Distance(player.transform.position, transform.position) < 5)
        {
            if (isOpening) return;
            isOpening = true;
            if (isOpened)
                StartCoroutine(OpenFalse());
            else
                StartCoroutine(OpenTrue());
        }
    }

    IEnumerator OpenTrue()
    {
        Vector3 dir = (EndPos.transform.position - transform.position).normalized;
        while (Vector3.Distance(EndPos.transform.position, transform.position) > 0.3)
        {
            transform.position += dir * Time.deltaTime * speed;
            
            dir = (EndPos.transform.position - transform.position).normalized;
            yield return wfs;
        }
        isOpened = true;
        isOpening = false;
    }

    IEnumerator OpenFalse()
    {
        Vector3 dir = (originPos - transform.localPosition).normalized;
        
        while (Vector3.Distance(transform.localPosition, originPos) > 0.1)
        {
            transform.localPosition += dir * Time.deltaTime * speed;
            dir = (originPos - transform.localPosition).normalized;
            yield return wfs;
        }
        isOpened = false;
        isOpening = false;
    }


}
 