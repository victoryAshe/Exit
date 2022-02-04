using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlphaGame : MonoBehaviour
{
    public GameObject ShowUI;
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("PLAYER");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 PlayerPos;
        PlayerPos = Player.transform.position;

        if (Vector3.Distance(PlayerPos, transform.position) <= 4.0f)
        {
            // PuzzleUI ��Ÿ���� �����
            Debug.Log("true");
            Debug.Log("true");
            ShowUI.SetActive(true);
            GameManager.instance.isShowPanel = true;
        }
        else
        {
            Debug.Log("false");
            ShowUI.SetActive(false);
            GameManager.instance.isShowPanel = false;
        }
    }
}
