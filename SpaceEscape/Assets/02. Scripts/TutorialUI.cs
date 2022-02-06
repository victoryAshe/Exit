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
        // NexrButton ������ ���� �̹����� ����
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
        // UndoButton ������ �� ���� �̹����� ����
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
        // �÷��� �� ����
        SceneManager.LoadScene("InGame");
        SceneManager.LoadScene("Player", LoadSceneMode.Additive);

    }
}
