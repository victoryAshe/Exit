using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainUICtrl : MonoBehaviour
{
    public Button tutorialBtn;
    public Button startBtn;
    public Button quitBtn;
    public Button setUpBtn;


    WaitForSeconds wfs = new WaitForSeconds(1.5f);
    CommonUICtrl commonUICtrl;

    void Awake()
    {
        commonUICtrl = CommonUICtrl.instance;
        StartCoroutine(commonUICtrl.FadeIn(true));
        
    }

    void Start()
    {
        tutorialBtn.onClick.AddListener(() => StartCoroutine(OnClickTuto()));
        startBtn.onClick.AddListener(() => StartCoroutine(OnClickStart()));
        quitBtn.onClick.AddListener(() => StartCoroutine(commonUICtrl.OnClickQuit()));
        setUpBtn.onClick.AddListener(() => commonUICtrl.OnClickSetUp(true));

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            commonUICtrl.OnClickSetUp(false);
    }

    IEnumerator OnClickTuto()
    {
        commonUICtrl.PlayButtonClick();
        yield return commonUICtrl.FadeIn(false);
        SceneManager.LoadScene("Tutorial");
   

    }

    IEnumerator OnClickStart()
    {
        commonUICtrl.PlayButtonClick();
        yield return commonUICtrl.FadeIn(false);
        SceneManager.LoadScene("Prologue");

    }



}