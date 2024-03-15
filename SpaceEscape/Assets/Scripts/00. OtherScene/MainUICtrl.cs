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
    //����� �κ�
    public AudioClip ButtonClip;     
    private new AudioSource audio;  

    void Awake()
    {
        StartCoroutine(FadeOut());
        
    }

    void Start()
    {
        audio = GetComponent<AudioSource>();

        tutorial.onClick.AddListener(() => StartCoroutine(OnClickTuto()));
        startNew.onClick.AddListener(() => StartCoroutine(OnClickStart()));
        quit.onClick.AddListener(() => StartCoroutine(OnClickQuit()));
        setUp.onClick.AddListener(() => StartCoroutine(OnClickSetUp()));

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            StartCoroutine(OnClickSetUp());
    }

    IEnumerator OnClickTuto()
    {
        audio.PlayOneShot(ButtonClip, 1.0f);
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("Tutorial");
        

    }

    IEnumerator OnClickStart()
    {
        audio.PlayOneShot(ButtonClip, 1.0f);
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("Prologue");

    }

    IEnumerator OnClickQuit()
    {
        audio.PlayOneShot(ButtonClip, 1.0f);
        yield return new WaitForSeconds(0.5f);
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); // ���ø����̼� ����
#endif
    }

    IEnumerator OnClickSetUp()
    {
        audio.PlayOneShot(ButtonClip, 1.0f);
        yield return new WaitForSeconds(0.5f);

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