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

    void Start()
    {
        startNew.onClick.AddListener(() => OnClickStart());

        StartCoroutine(FadeIn(showText01));

    }

    void Update()
    {
        
    }

    void OnClickStart()
    {
        SceneManager.LoadScene("InGame");
    }

    IEnumerator FadeIn(Text target)
    {
        yield return new WaitForSeconds(0.03f);

        Color x = target.color;
        float fadeCount = 0f; //처음 알파값
        target.gameObject.SetActive(true);

        while (fadeCount < 1.0f)
        {
            fadeCount += 0.01f;
            yield return new WaitForSeconds(0.01f);
            x.a = fadeCount;
            target.color = x;//해당 변수값으로 알파값 지정
        }

        yield return new WaitForSeconds(1.5f);
        StartCoroutine(FadeOut(target));
    }


    IEnumerator FadeOut(Text target)
    {
        yield return new WaitForSeconds(0.03f);
        Color x = target.color;
        float fadeCount = 1.0f; //처음 알파값
        while (fadeCount > 0)
        {
            fadeCount -= 0.01f;
            yield return new WaitForSeconds(0.01f);
            x.a = fadeCount;
            target.color = x;//해당 변수값으로 알파값 지정
        }
        target.gameObject.SetActive(false);
        StartCoroutine(ScrollText());
    }

    IEnumerator ScrollText()
    {
        float y1 = showText02.GetComponent<RectTransform>().anchoredPosition.y;
        while (y1 < 0)
        {
            y1 += 0.5f;
            yield return new WaitForSeconds(0.001f);
            showText02.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, y1);

        }

        float x1 = showText02.rectTransform.eulerAngles.x;
        while (x1 > 0)
        {
            x1 -= 1;
            yield return new WaitForSeconds(0.01f);
            showText02.GetComponent<RectTransform>().eulerAngles = new Vector3(x1, 0, 0);
        }

        startNew.gameObject.SetActive(true);
    }
}
