using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Warp : MonoBehaviour
{
    public GameObject StartPos;
    public GameObject EndPos;
    public Image Black;

    void Start()
    {
        Black = GameObject.Find("UIcanvas").transform.Find("blackPanel").GetComponent<Image>();
    }

    void warpRoutine()
    {
        
        StartPos.transform.position = EndPos.transform.position;

    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("PLAYER"))
        {
            StartPos = col.gameObject;

            //2초뒤 warp 실행
            StartCoroutine(FadeIn());
            
        }
    }


    IEnumerator FadeIn()
    {
        Black.gameObject.SetActive(true);

        float fadeCount = 0f; //처음 알파값
        while (fadeCount <= 1.0f)
        {
            fadeCount += 0.01f;
            yield return new WaitForSeconds(0.01f);
            Black.color = new Color(0, 0, 0, fadeCount);//해당 변수값으로 알파값 지정
        }
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        Invoke("warpRoutine", 2);
        yield return new WaitForSeconds(1.5f);

        float fadeCount = 1.0f; //처음 알파값
        while (fadeCount > 0)
        {
            fadeCount -= 0.01f;
            yield return new WaitForSeconds(0.01f);
            Black.color = new Color(0, 0, 0, fadeCount);//해당 변수값으로 알파값 지정
        }
        Black.gameObject.SetActive(false);
    }
}