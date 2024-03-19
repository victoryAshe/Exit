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
    WaitForSeconds wfs =  new WaitForSeconds(0.01f);
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

        NotificationField.color = new Color(0, 0, 0, 1);//�ش� ���������� ���İ� ����
        notification.color = new Color(255, 255, 255, 1);

        notification.text = msg;
        NotificationField.gameObject.SetActive(true);

        StartCoroutine(OffNotification());

    }

    public IEnumerator OffNotification()
    {
        yield return new WaitForSeconds(1.5f);

        float fadeCount = 1f; //ó�� ���İ�
        NotificationField.color = new Color(0, 0, 0, fadeCount);

        while (fadeCount > 0)
        {
            fadeCount -= 0.01f;
            NotificationField.color = new Color(0, 0, 0, fadeCount);//�ش� ���������� ���İ� ����
            notification.color = new Color(255, 255, 255, fadeCount);
            yield return wfs;
        }

        NotificationField.gameObject.SetActive(false);


    }
}
