using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PCctrl : MonoBehaviour
{
    // TODO: 2¹ø¹æ PC-Panel Ctrl
    Transform player;
    public GameObject mainPanel;    public GameObject[] panels;
    public Button[] oButtons;       public Button[] cButtons;

    void Start()
    {
        player = GameObject.FindWithTag("PLAYER").transform;
    }

    void Update()
    {
        if (Vector3.Distance(player.position, transform.position) <= 3.0f)
        {
            mainPanel.SetActive(true);
            GameManager.instance.isShowPanel = true;
        }
        else
        {
            mainPanel.SetActive(false);
            GameManager.instance.isShowPanel = false;
        }
    }

    public void OpenPanel(int idx)
    {
        panels[idx].SetActive(true);
    }

    public void ClosePanel(int idx)
    {
        panels[idx].SetActive(false);
    }
}
