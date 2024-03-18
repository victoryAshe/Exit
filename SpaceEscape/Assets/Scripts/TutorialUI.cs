using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialUI : MonoBehaviour
{
    public Button NextButton;
    public Button StartButton;
    public Button UndoButton;
    public Image informImage;
    public Sprite[] informSprites;
    int imageIndex = 0;
    AudioCtrl audioCtrl;

    void Start()
    {
        audioCtrl = AudioCtrl.instance;
        StartCoroutine(CommonUICtrl.instance.FadeIn(true));

        NextButton.onClick.AddListener(() => OnClickNext());
        UndoButton.onClick.AddListener(() => OnClickUndo());
        StartButton.onClick.AddListener(() => StartCoroutine(OnClickStart()));
    }

    void OnClickNext()
    {
        audioCtrl.PlayButtonClick();

        informImage.sprite = informSprites[++imageIndex];

        if (imageIndex == 5)
        {
            NextButton.gameObject.SetActive(false);
        }
        if (imageIndex == 1)
        {
            UndoButton.gameObject.SetActive(true);
        }

    }

    void OnClickUndo()
    {
        audioCtrl.PlayButtonClick();

        informImage.sprite = informSprites[--imageIndex];

        if (imageIndex == 0)
        {
            UndoButton.gameObject.SetActive(false);
        }
        if (imageIndex == 4)
        {
            NextButton.gameObject.SetActive(true);
        }
    }

    IEnumerator OnClickStart()
    {
        audioCtrl.PlayButtonClick();

        yield return CommonUICtrl.instance.FadeIn(false);
        SceneManager.LoadScene("Prologue");

    }
}
