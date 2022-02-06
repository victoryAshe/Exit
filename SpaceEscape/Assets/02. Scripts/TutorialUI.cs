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

    public AudioClip ButtonClip;  
    private new AudioSource audio;

    void Start()
    {
        NextButton.onClick.AddListener(() => StartCoroutine(OnClickNext()));
        UndoButton.onClick.AddListener(() => StartCoroutine(OnClickUndo()));
        StartButton.onClick.AddListener(() => StartCoroutine(OnClickStart()));
        image = GetComponent<Image>();

        audio = GetComponent<AudioSource>();
        
    }

    
    void Update()
    {
    }


    IEnumerator OnClickNext()
    {
        audio.PlayOneShot(ButtonClip, 1.0f);
        yield return new WaitForSeconds(1.0f);

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

    IEnumerator OnClickUndo()
    {
        audio.PlayOneShot(ButtonClip, 1.0f);
        yield return new WaitForSeconds(1.0f);

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

    IEnumerator OnClickStart()
    {
        audio.PlayOneShot(ButtonClip, 1.0f);
        yield return new WaitForSeconds(1.0f);

        // 플레이 씬 열기
        SceneManager.LoadScene("InGame");
        SceneManager.LoadScene("Player", LoadSceneMode.Additive);

    }
}
