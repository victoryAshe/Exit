using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public bool isGameOver; public Image overPanel;

    //게임의 종료 여부를 저장할 프로퍼티
    public bool IsGameOver
    {
        get { return isGameOver; }
        set
        {
            isGameOver = value;
            if (isGameOver)
            {
                //StartCoroutine(SoundFadeout());


                StartCoroutine(GameOver());
            }
        }

    }

    public bool isGamePaused;
    public bool isShowScript;

    public Text timeText;
    public float minute = 0f;  public float second = 0f;  
    float Timer
    { 
        get { return minute * 60 + second; } 
        set {} 
    }

    public static GameManager instance = null;

    void Awake()
    {
        // 싱글턴
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);

    }

    void Start()
    {
        //test
        SetTimer(1, 30);
    }

    void Update()
    {
        if (isGamePaused || IsGameOver) return;

        if (Timer > 0)
        {
            if (second >= 1) second -= Time.deltaTime;
            else if (minute >= 1)
            {
                minute -= 1; second = 60f;
            }
            else
            {
                Timer = 0;
            }
            timeText.text = Mathf.Floor(minute) + ":" + Mathf.Floor(second);

        }
    }

    IEnumerator GameOver()
    {
        //Set Enemy Active False
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("ENEMY");
        foreach (GameObject enemy in enemies)
        {
            enemy.SetActive(false);
        }

        //ShowOverPanel
        float fadeCount = 0; //처음 알파값
        overPanel.color = new Color(0, 0, 0, fadeCount);
        overPanel.gameObject.SetActive(true);

        while (fadeCount < 0.8f)
        {
            fadeCount += 0.01f;
            yield return new WaitForSeconds(0.01f);
            overPanel.color = new Color(0, 0, 0, fadeCount);
        }
    }

    /*
    IEnumerator SoundFadeout()
    {

        AudioSource bgAudio = GameObject.Find("Background").GetComponent<AudioSource>();

        for (float i = 0; i <= 1.0f; i += 0.01f)
        {
            bgAudio.volume -= i;
            yield return new WaitForSeconds(0.1f);
        }
    }
    */

    public void CreateEnemy()
    {
        // TODO: Enemy를 적절한 자리에 Instantiate, Level을 Random으로 정해줌
    }

    public void SetTimer(int m, int s)
    {
        //m = minutes, s = seconds
        minute = m; second = s;
        Timer = minute * 60 + second;
        timeText.text = m + ":" + s;
    }


}
