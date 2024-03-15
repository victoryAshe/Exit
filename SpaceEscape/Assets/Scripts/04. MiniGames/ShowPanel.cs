using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowPanel : MonoBehaviour
{
    Transform player;
    GameObject targetPanel;
    void Start()
    {
        player = GameObject.FindWithTag("PLAYER").transform;
        targetPanel = GameObject.Find("UIcanvas").transform.Find("hintPanel").gameObject;
    }

    void Update()
    {
        if (GameManager.instance.isShowScript)
        {
            targetPanel.SetActive(false);
            return;
        } 

        if (Vector3.Distance(player.position, transform.position) <= 3.0f)
        {
            targetPanel.SetActive(true);
        }
        else
            targetPanel.SetActive(false);

    }
}
