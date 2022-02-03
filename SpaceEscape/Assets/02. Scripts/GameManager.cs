using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public bool isGameOver; public Image overPanel;
    public bool EndKey;
    public Text endTitle;    public Text endingText;
    private string endingString;
    public GameObject start; public GameObject quit;

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
    public bool isShowPanel;

    public Text timeText;
    public float minute = 0f;  public float second = 0f;
    float Timer
    { 
        get { return minute * 60 + second; } 
        set {} 
    }

    public GameObject enemy; public GameObject enemies; public int enemyQuantity;

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
        //SetTimer(1, 30);

        //test
        CreateEnemy(GameObject.FindWithTag("PLAYER").transform.position);
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
        if (EndKey == false)
        {
            endTitle.text = "You Failed!";
            endingString = "외계인에게 습격 당하여 목숨이 위태롭다. 이대로 끝나는 건가…";
        }
        else
        {
            endTitle.text = "Mission Clear!";
            endingString = "탈출에 성공해 새로운 행성에 도착했다! 정말 긴 하루였다. 새로운 삶이 기대된다...";
        }

        float fadeCount = 0; //처음 알파값
        overPanel.color = new Color(0, 0, 0, fadeCount);
        overPanel.gameObject.SetActive(true);

        while (fadeCount < 0.8f)
        {
            fadeCount += 0.01f;
            yield return new WaitForSeconds(0.01f);
            overPanel.color = new Color(0, 0, 0, fadeCount);
        }

        StartCoroutine(TypingEffect());
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

    public void CreateEnemy(Vector3 pos)
    {
        // TODO: Enemy를 적절한 자리에 Instantiate, Level을 Random으로 정해줌
        for(int i=0; i< enemyQuantity; i++)
        {
            float randomX = pos.x + Random.Range(0f, 15f);
            float randomZ = pos.z + Random.Range(0f, 15f);
            GameObject Temp = Instantiate(enemy, new Vector3(randomX, 0.0f, randomZ), Quaternion.identity);
            Temp.transform.parent = enemies.transform;
            Temp.SetActive(true);
        }

        //Zombie들 활성화
        enemies.SetActive(true);

    }

    public void SetTimer(int m, int s)
    {
        //m = minutes, s = seconds
        minute = m; second = s;
        Timer = minute * 60 + second;
        timeText.text = m + ":" + s;
    }

    IEnumerator TypingEffect()
    {
        for (int i = 0; i <= endingString.Length; i++)
        {
            endingText.text = endingString.Substring(0, i);
            yield return new WaitForSeconds(0.1f);

        }
        start.SetActive(true); quit.SetActive(true);
        
    }


}
