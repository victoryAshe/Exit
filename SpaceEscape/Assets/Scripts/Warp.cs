using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Warp : MonoBehaviour
{
    public GameObject StartPos;
    public GameObject EndPos;

    bool isTriggered = false;

    public AudioClip WarpClip;
    public bool isTrue;

    CommonUICtrl commonUICtrl;
    AudioCtrl audioCtrl;


    void Start()
    {
        commonUICtrl = CommonUICtrl.instance;
        audioCtrl = AudioCtrl.instance;

    }

    void warpRoutine()
    {
        
        StartPos.transform.position = EndPos.transform.position;

    }

    private IEnumerator OnTriggerEnter(Collider col)
    {
        //Application.targetFrameRate = 30;

        if (col.gameObject.CompareTag("PLAYER"))
        {
            if (isTriggered == true) yield break;

            StartPos = col.gameObject;
            GameManager.instance.isShowScript = true;

            audioCtrl.PlaySFX(WarpClip, 1.0f);
            

            //2초뒤 warp 실행
            yield return commonUICtrl.FadeIn(true);
            StartCoroutine(FadeOut());
        }
    }


    IEnumerator FadeOut()
    {
        Invoke("warpRoutine", 1.5f);
        yield return new WaitForSeconds(1.5f);

        if (!isTrue)
        {
            GameManager.instance.questId = 4;
            GameManager.instance.enemyQuantity = 20;
            GameManager.instance.SetTimer(0);
        }

        else if (isTrue && GameManager.instance.questId < 3)
        {
            GameManager.instance.questId += 1;
            GameManager.instance.SetTimer(300);

        }

        commonUICtrl.FadeIn(false);
        GameManager.instance.isShowScript = false;
    }
}