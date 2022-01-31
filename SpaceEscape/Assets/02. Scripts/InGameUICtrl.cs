using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InGameUICtrl : MonoBehaviour
{
    public Button startNew;
    public Button quit;
    public Button setUp;

    public GameObject setupPanel;

    void Start()
    {
        startNew.onClick.AddListener(() => OnClickStart());
        quit.onClick.AddListener(() => OnClickQuit());
        setUp.onClick.AddListener(() => OnClickSetUp());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            OnClickSetUp();
    }

    void OnClickStart()
    {
        SceneManager.LoadScene("InGame");
    }

    void OnClickQuit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); // 어플리케이션 종료
#endif
    }

    void OnClickSetUp()
    {
        if (setupPanel.activeSelf == false)
        {
            GameManager.instance.isGamePaused = true;
            setupPanel.SetActive(true);
            setUp.interactable = false; setUp.interactable = true;

        }
        else
        {
            GameManager.instance.isGamePaused = false;
            setupPanel.SetActive(false);
            setUp.interactable = false; setUp.interactable = true;
        }
    }
}
