using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CommonUICtrl : MonoBehaviour
{
    public static CommonUICtrl instance;

    public GameObject setupPanel;
    public Button closeSetupBtn;
    public Image fadeImage;

    WaitForSeconds fadeWfs = new WaitForSeconds(0.01f);

    AudioCtrl audioCtrl;

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
        DontDestroyOnLoad(gameObject);

        audioCtrl = AudioCtrl.instance;

        closeSetupBtn.onClick.AddListener(OnClickCloseSetting) ;
    }

    public void OnClickSetUp(bool isButtonInput)
    {
        if (audioCtrl == null) audioCtrl = AudioCtrl.instance;
        if (isButtonInput) audioCtrl.PlayButtonClick();

        if (GameManager.instance)
        {
            if (!GameManager.instance.isGamePaused) GameManager.instance.isGamePaused = true;
            else GameManager.instance.isGamePaused = false;
        }

        if (setupPanel.activeSelf == false)
            setupPanel.SetActive(true);
        else
            setupPanel.SetActive(false);

        if (audioCtrl.hasInitedSetting == false) audioCtrl.InitSetting();
    }

    void OnClickCloseSetting()
    {
        audioCtrl.PlayButtonClick();
        if (GameManager.instance) GameManager.instance.isGamePaused = false;
        setupPanel.SetActive(false);
    }



    public IEnumerator OnClickStart()
    {
        if (audioCtrl == null) audioCtrl = AudioCtrl.instance;
        audioCtrl.PlayButtonClick();
        yield return FadeIn(false);
        SceneManager.LoadScene("Prologue");
    }

    public IEnumerator OnClickStartNew()
    {
        audioCtrl.PlayButtonClick();
        yield return FadeIn(false);

        SceneManager.LoadScene("InGame");
        SceneManager.LoadScene("Player", LoadSceneMode.Additive);
    }

    public IEnumerator OnClickQuit()
    {
        audioCtrl.PlayButtonClick();
        FadeIn(false);
        yield return audioCtrl.PlayBgm(Enums.bgmType.None);
        
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); // 어플리케이션 종료
#endif
    }






    public IEnumerator FadeIn(bool isIn)
    {
        float fadeCount = isIn ? 1.0f : 0f; //처음 알파값
        fadeImage.color = isIn ? Color.black : Color.clear;
        fadeImage.raycastTarget = true;

        while (isIn && fadeCount > 0f || !isIn && fadeCount <1f)
        {
            fadeCount = isIn ? fadeCount - 0.01f : fadeCount + 0.01f;
            yield return fadeWfs;
            fadeImage.color = new Color(0, 0, 0, fadeCount);//해당 변수값으로 알파값 지정
        }

        fadeImage.raycastTarget = false;
    }

}
