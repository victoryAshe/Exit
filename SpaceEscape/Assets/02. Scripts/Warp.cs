using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Warp : MonoBehaviour
{
    public GameObject StartPos;
    public GameObject EndPos;
    public Image Black;

    public AudioClip WarpClip;
    private new AudioSource audio;
    public bool isTrue;

    void Start()
    {
        Black = GameObject.Find("UIcanvas").transform.Find("blackPanel").GetComponent<Image>();

        audio = GetComponent<AudioSource>();
    }

    void warpRoutine()
    {
        
        StartPos.transform.position = EndPos.transform.position;

    }

    private void OnTriggerEnter(Collider col)
    {
        //Application.targetFrameRate = 30;

        if (col.gameObject.CompareTag("PLAYER"))
        {
            StartPos = col.gameObject;
            GameManager.instance.isShowScript = true;

            audio.PlayOneShot(WarpClip, 1.0f);
            

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
        Invoke("warpRoutine", 1.5f);
        yield return new WaitForSeconds(1.5f);

        if (!isTrue)
        {
            GameManager.instance.questId = 4;
            GameManager.instance.enemyQuantity = 20;
            GameManager.instance.SetTimer(0, 0);
        }

        else if (isTrue && GameManager.instance.questId < 3)
        {
            GameManager.instance.questId += 1;
            GameManager.instance.SetTimer(5, 0);

        }

        float fadeCount = 1.0f; //처음 알파값
        while (fadeCount > 0)
        {
            fadeCount -= 0.01f;
            yield return new WaitForSeconds(0.01f);
            Black.color = new Color(0, 0, 0, fadeCount);//해당 변수값으로 알파값 지정
        }
        Black.gameObject.SetActive(false);
        GameManager.instance.isShowScript = false;

        

        //Application.targetFrameRate = 50;
    }
}