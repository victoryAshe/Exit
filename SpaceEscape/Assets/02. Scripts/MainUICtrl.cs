using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainUICtrl : MonoBehaviour
{
    public Button prologue;
    public Button startNew;
    public Button quit;
    public Button setUp;

    public GameObject setupPanel;


    void Start()
    {

        prologue.onClick.AddListener(() => OnClickPro());
        startNew.onClick.AddListener(() => OnClickStart());
        quit.onClick.AddListener(() => OnClickQuit());
        setUp.onClick.AddListener(() => OnClickSetUp());


    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            OnClickSetUp();
    }

    void OnClickPro()
    {
        SceneManager.LoadScene("Prologue");
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
            setupPanel.SetActive(true);
        else
            setupPanel.SetActive(false);
    }
}

