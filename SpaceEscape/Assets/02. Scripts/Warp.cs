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

            //2�ʵ� warp ����
            StartCoroutine(FadeIn());
            
        }
    }


    IEnumerator FadeIn()
    {
        Black.gameObject.SetActive(true);

        float fadeCount = 0f; //ó�� ���İ�
        while (fadeCount <= 1.0f)
        {
            fadeCount += 0.01f;
            yield return new WaitForSeconds(0.01f);
            Black.color = new Color(0, 0, 0, fadeCount);//�ش� ���������� ���İ� ����
        }
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        Invoke("warpRoutine", 2);
        yield return new WaitForSeconds(1.5f);

        float fadeCount = 1.0f; //ó�� ���İ�
        while (fadeCount > 0)
        {
            fadeCount -= 0.01f;
            yield return new WaitForSeconds(0.01f);
            Black.color = new Color(0, 0, 0, fadeCount);//�ش� ���������� ���İ� ����
        }
        Black.gameObject.SetActive(false);
    }
}