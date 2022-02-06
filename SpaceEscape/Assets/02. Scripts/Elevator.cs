using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{

    public GameObject EndPos;

    public float speed = 1.5f;
    IEnumerator ElevatorRoutine()
    {
        yield return new WaitForSeconds(2f);
        while (Vector3.Distance(EndPos.transform.position, transform.position) > 0)
        {
            yield return new WaitForSeconds(0.01f);
            //startpos의 position을 계속 더해준다 

            Vector3 dir;
            dir = EndPos.transform.position - transform.position;

            transform.position += dir * Time.deltaTime * speed;


        }
    }

    //player의 충돌을 감지하면
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("PLAYER"))
        {

            other.gameObject.transform.parent = transform;


            StartCoroutine(ElevatorRoutine());
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("PLAYER"))
        {
            other.gameObject.transform.parent = null;
        }
    }
}