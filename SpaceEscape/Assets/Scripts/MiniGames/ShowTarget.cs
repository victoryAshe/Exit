using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowTarget : MonoBehaviour
{
    Transform player;
    public GameObject target;
    public float targetDistance;

    IEnumerator Start()
    {
        yield return new WaitUntil(()=>PlayerMove.instance != null);
        player = PlayerMove.instance.transform;
    }

    void Update()
    {
        if (player == null) return;

        if (Vector3.Distance(player.position, transform.position) <= targetDistance)
        {
            GameManager.instance.isShowAlpha = true;
            target.SetActive(true);
        }
        else
        {
            GameManager.instance.isShowAlpha = false;
            target.SetActive(false);
        }
    }
}
