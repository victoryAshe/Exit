using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleGame : MonoBehaviour
{
    public GameObject ShowUI;
    public Transform Player;

    void Start()
    {
        Player = GameObject.FindWithTag("PLAYER").transform;
    }


    void Update()
    {

        if (Vector3.Distance(Player.position, transform.position) <= 4.0f)
        {
            ShowUI.SetActive(true);
            GameManager.instance.isShowPanel = true;
        }
        else
        {
            ShowUI.SetActive(false);
            GameManager.instance.isShowPanel = false;
        }
    }
}
