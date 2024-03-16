using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommonUICtrl : MonoBehaviour
{
    public static CommonUICtrl instance;

    private AudioSource sfxSource;
    public AudioClip buttonClip;

    public GameObject setupPanel;
    public Button closeSetupBtn;
    public Image fadeImage;

    WaitForSeconds fadeWfs = new WaitForSeconds(0.01f);

    private void Awake()
    {
        if (instance == null) instance = this;
        DontDestroyOnLoad(gameObject);
        TryGetComponent<AudioSource>(out sfxSource);

        closeSetupBtn.onClick.AddListener(OnClickCloseSetting) ;
    }

    void OnClickCloseSetting()
    {
        sfxSource.PlayOneShot(buttonClip, 1.0f);
        setupPanel.SetActive(false);
    }


    public IEnumerator OnClickQuit()
    {
        sfxSource.PlayOneShot(buttonClip, 1.0f);
        yield return new WaitForSeconds(0.5f);
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); // 어플리케이션 종료
#endif
    }

    public void PlayButtonClick()
    {
        sfxSource.PlayOneShot(buttonClip, 1.0f);
    }

    public void OnClickSetUp(bool isButtonInput)
    {
        if(isButtonInput) sfxSource.PlayOneShot(buttonClip, 1.0f);

        if (setupPanel.activeSelf == false)
            setupPanel.SetActive(true);
        else
            setupPanel.SetActive(false);
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
