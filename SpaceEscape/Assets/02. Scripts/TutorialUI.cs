using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class TutorialUI : MonoBehaviour
{
    public Button NextButton;
    public Button StartButton;
    public Button UndoButton;
    public Image image;
    public int index = 1;

    void Start()
    {
        NextButton.onClick.AddListener(() => OnClickNext());
        UndoButton.onClick.AddListener(() => OnClickUndo());
        StartButton.onClick.AddListener(() => OnClickStart());
        image = GetComponent<Image>();
        
    }

    
    void Update()
    {
    }


    void OnClickNext()
    {
        index += 1;
        // NexrButton 누르면 다음 이미지로 변경
        image.sprite = Resources.Load<Sprite>("TutorialImage/Tutorial(" + index + ")");

        if (index == 6)
        {
            NextButton.gameObject.SetActive(false);
        }
        if (index == 2)
        {
            UndoButton.gameObject.SetActive(true);
        }

    }

    void OnClickUndo()
    {
        index -= 1;
        // UndoButton 누르면 전 이전 이미지로 변경
        image.sprite = Resources.Load<Sprite>("TutorialImage/Tutorial(" + index + ")");

        if (index == 1)
        {
            UndoButton.gameObject.SetActive(false);
        }
        if (index == 5)
        {
            NextButton.gameObject.SetActive(true);
        }
    }

    void OnClickStart()
    {
        // 플레이 씬 열기
        SceneManager.LoadScene("InGame");
        SceneManager.LoadScene("Player", LoadSceneMode.Additive);

    }
}
