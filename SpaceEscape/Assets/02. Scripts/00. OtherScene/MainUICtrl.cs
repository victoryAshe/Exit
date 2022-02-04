using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainUICtrl : MonoBehaviour
{
    public Button tutorial;
    public Button startNew;
    public Button quit;
    public Button setUp;

    public GameObject setupPanel;

    public Image logo;

    void Awake()
    {
        StartCoroutine(FadeOut());
        
    }

    void Start()
    {

        tutorial.onClick.AddListener(() => OnClickTuto());
        startNew.onClick.AddListener(() => OnClickStart());
        quit.onClick.AddListener(() => OnClickQuit());
        setUp.onClick.AddListener(() => OnClickSetUp());


    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            OnClickSetUp();
    }

    void OnClickTuto()
    {
        SceneManager.LoadScene("Tutorial");
    }

    void OnClickStart()
    {
        SceneManager.LoadScene("Prologue");

    }

    void OnClickQuit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); // ���ø����̼� ����
#endif
    }

    void OnClickSetUp()
    {
        if (setupPanel.activeSelf == false)
            setupPanel.SetActive(true);
        else
            setupPanel.SetActive(false);
    }


    IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(1.5f);

        float fadeCount = 1.0f; //ó�� ���İ�
        while (fadeCount > 0)
        {
            fadeCount -= 0.01f;
            yield return new WaitForSeconds(0.01f);
            logo.color = new Color(255, 255, 255, fadeCount);//�ش� ���������� ���İ� ����
        }
        logo.gameObject.SetActive(false);
    }
}