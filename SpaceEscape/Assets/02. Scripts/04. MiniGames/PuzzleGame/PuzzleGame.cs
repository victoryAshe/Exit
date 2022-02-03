using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleGame : MonoBehaviour
{
    public GameObject PuzzleUI;
    public GameObject PuzzleBoard;
    public GameObject Player;

    // 퍼즐 조각에 할당할 내용들
    public GameObject PuzzlePosSet;
    public GameObject PuzzlePieceSet;
       

    // Start is called before the first frame update
    void Start()
    {
        // Player와 Puzzleboard 거리 계산
        //transform.position = Player.transform.position - PuzzleBoard.transform.position;
        //float distance = Vector3.Distance(PlayerPos, PuzzleBoardpos);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 PuzzleBoardpos;
        PuzzleBoardpos = PuzzleBoard.gameObject.transform.position;

        Vector3 PlayerPos;
        PlayerPos = Player.gameObject.transform.position;

        if (Vector3.Distance(PlayerPos, PuzzleBoardpos) <= 3.0f)
        {
            // PuzzleUI 나타나게 만들기
            PopupPuzzleUI();
        }
        else
            return;
    }

    public void PopupPuzzleUI()
    {
        PuzzleUI.SetActive(true);
    }



}
