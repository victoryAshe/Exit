using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class InGameUICtrl : MonoBehaviour
{
    public Button startNewBtn;
    public Button quitBtn;
    public Button setUpBtn;

    public Image NotificationField;
    public TextMeshProUGUI notification;

    CommonUICtrl commonUICtrl;
    void Start()
    {
        commonUICtrl = CommonUICtrl.instance;

        StartCoroutine(commonUICtrl.FadeIn(true));

        startNewBtn.onClick.AddListener(() => StartCoroutine(commonUICtrl.OnClickStartNew()));
        quitBtn.onClick.AddListener(() => StartCoroutine(commonUICtrl.OnClickQuit()));
        setUpBtn.onClick.AddListener(() => commonUICtrl.OnClickSetUp(true));

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            commonUICtrl.OnClickSetUp(false);
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

        float fadeCount = 0.5f; //처음 알파값
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
