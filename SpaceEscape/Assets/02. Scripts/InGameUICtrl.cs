using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class InGameUICtrl : MonoBehaviour
{
    public Button startNew;
    public Button quit;
    public Button setUp;

    public Image NotificationField;
    public TextMeshProUGUI notification;


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

    public void OnClickStart()
    {
        SceneManager.LoadScene("InGame");
    }

    public void OnClickQuit()
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

    public void OnNotification(string msg)
    {
        if (NotificationField.gameObject.activeSelf) return;

        float fadeCount = 1.0f;

        NotificationField.color = new Color(0, 0, 0, fadeCount);//해당 변수값으로 알파값 지정
        notification.color = new Color(255, 255, 255, fadeCount);

        notification.text = msg;
        NotificationField.gameObject.SetActive(true);

        StartCoroutine(OffNotification());

    }

    public IEnumerator OffNotification()
    {
        yield return new WaitForSeconds(0.03f);

        float fadeCount = 1.0f; //처음 알파값
        NotificationField.color = new Color(0, 0, 0, fadeCount);

        while (fadeCount > 0)
        {
            fadeCount -= 0.01f;
            yield return new WaitForSeconds(0.01f);
            NotificationField.color = new Color(0, 0, 0, fadeCount);//해당 변수값으로 알파값 지정
            notification.color = new Color(255, 255, 255, fadeCount);
        }

        NotificationField.gameObject.SetActive(false);


    }
}
