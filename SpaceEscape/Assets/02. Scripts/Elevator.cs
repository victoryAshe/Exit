using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public float speed = 1.5f;
    public GameObject elevator;
    private void OnTriggerStay()
    {
        elevator.transform.position += elevator.transform.forward * speed * Time.deltaTime;
    }
}
