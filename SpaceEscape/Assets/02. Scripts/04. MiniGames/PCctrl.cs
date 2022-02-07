using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PCctrl : MonoBehaviour
{
    // TODO: 2번방 PC-Panel Ctrl
    Transform player;
    public GameObject mainPanel;    public GameObject[] panels;
    public Button[] oButtons;       public Button[] cButtons;
    // unknown 사진
    public Button UnknownImageButton;
    public GameObject UnknownImagePanel;
    public Button UnknownImageX;
    // 28(num)사진
    public Button PanelNumButton;
    public GameObject PanelNumImage;
    public Button PanelNumImageX;


    void Start()
    {
        player = GameObject.FindWithTag("PLAYER").transform;

        UnknownImageButton.onClick.AddListener(() => Panel_Array());
        PanelNumButton.onClick.AddListener(() => Panel_Num());

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

    public void Panel_Array()
    {
        if (!UnknownImagePanel.activeSelf)
            UnknownImagePanel.SetActive(true);
        else
            UnknownImagePanel.SetActive(false);
    }

    public void Panel_Num()
    {
        if (!UnknownImagePanel.activeSelf)
            PanelNumImage.SetActive(true);
        else
            PanelNumImage.SetActive(false);
    }   
    

}
