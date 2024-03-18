using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PrologueUICtrl : MonoBehaviour
{
    public Text showText01;
    public Text showText02;
    public Button startNew;
    public Button skip;

    WaitForSeconds wfs01 = new WaitForSeconds(0.001f);
    WaitForSeconds wfs1 = new WaitForSeconds(0.01f);
    WaitForSeconds wfs3 = new WaitForSeconds(0.03f);

    CommonUICtrl commonUICtrl;

    IEnumerator Start()
    {
        commonUICtrl = CommonUICtrl.instance;
        StartCoroutine(AudioCtrl.instance.PlayBgm(Enums.bgmType.프롤로그_및_튜토리얼));
        yield return commonUICtrl.FadeIn(true);

        startNew.onClick.AddListener(() => StartCoroutine(commonUICtrl.OnClickStartNew()));
        skip.onClick.AddListener(() => OnClickSkip());

        yield return wfs3;

        //FadeIn text01
        Color x = showText01.color;
        float fadeCount = 0f; //처음 알파값
        showText01.gameObject.SetActive(true);

        while (fadeCount < 1.0f)
        {
            fadeCount += 0.01f;
            yield return wfs1;
            x.a = fadeCount;
            showText01.color = x;//해당 변수값으로 알파값 지정
        }

        yield return new WaitForSeconds(1.5f);

        //FadeOut text01
        yield return wfs3;
        while (fadeCount > 0)
        {
            fadeCount -= 0.01f;
            yield return wfs1;
            x.a = fadeCount;
            showText01.color = x;//해당 변수값으로 알파값 지정
        }
        showText01.gameObject.SetActive(false);


        //scroll text02
        float y1 = showText02.GetComponent<RectTransform>().anchoredPosition.y;
        while (y1 < 0)
        {
            y1 += 0.5f;
            yield return wfs01;
            showText02.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, y1);

        }

        float x1 = showText02.rectTransform.eulerAngles.x;
        while (x1 > 0)
        {
            x1 -= 1;
            yield return wfs1;
            showText02.GetComponent<RectTransform>().eulerAngles = new Vector3(x1, 0, 0);
        }

        startNew.gameObject.SetActive(true);
    }

    void OnClickSkip()
    {
        AudioCtrl.instance.PlayButtonClick();

        StopAllCoroutines();
        showText01.gameObject.SetActive(false);
        showText02.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
        showText02.GetComponent<RectTransform>().eulerAngles = Vector3.zero;
        skip.gameObject.SetActive(false);
        startNew.gameObject.SetActive(true);
            
    }
}
