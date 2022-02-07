using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private GameObject UIcanvas;
    public bool isGameOver; public Image overPanel;
    public bool EndKey;
    public Text endTitle;    public Text endingText;
    private string endingString;
    public GameObject start; public GameObject quit;

    public Transform[] doors; private float speed = 5.0f;
    public Transform[] endPoses;
    public AudioClip DoorOpenClip;
    private new AudioSource audio;

    //������ ���� ���θ� ������ ������Ƽ
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

    public bool isGamePaused;   public bool isShowScript;
    public bool isShowPanel;    public bool isShowAlpha;

    //PLAYER�� �ִ� ���� �˾Ƴ��� ENEMY�� CREATE�� ��� ���ϵ��� ���ִ� ID
    public int questId = 1;
    Vector3[] enemyPos = new Vector3[] 
    {
        new Vector3(8.47500038f, -0.800000012f, -19.3390007f),  //Room1
        new Vector3(60.9500008f, 0.400000006f, -66.75f),        //Room2
        new Vector3(138f, 0.400000006f, -28.529501f),           //Room3
        new Vector3(3.05999994f,-1.32459128f,18.3999996f)       //FakeRoom

    };

    public Text timeText;
    public float minute = 0f;  public float second = 0f;

    public float timer;
    public float Timer
    { 
        get { return timer; } 
        set 
        {
            timer = value;
            if (timer == 0)
            {
                CreateEnemy(enemyPos[questId - 1]);
            }
                
        } 
    }

    public GameObject enemy; public GameObject enemies; public int enemyQuantity;

    public static GameManager instance = null;

    void Awake()
    {

        // �̱���
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(instance.gameObject);
            instance = this;
        }

        DontDestroyOnLoad(this.gameObject);

    }

    void Start()
    {
        audio = GetComponent<AudioSource>();

        //TODO: Doors, EndPoses Scene���� ã�Ƽ� �Ҵ�
        TransformFinder finder = GameObject.Find("TransformFinder").GetComponent<TransformFinder>();
        doors = finder.doors;   endPoses = finder.endPoses;

        //Room1 Timer
        //SetTimer(5, 0);
        SetTimer(0, 5);
        //test
        //CreateEnemy(GameObject.FindWithTag("PLAYER").transform.position);

    }

    void Update()
    {
        if (isGamePaused || IsGameOver) return;

        if (timer > 0)
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

    public IEnumerator GameOver()
    {
        //Set Enemy Active False
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("ENEMY");
        foreach (GameObject enemy in enemies)
        {
            enemy.SetActive(false);
        }

        //ShowOverPanel
        if (EndKey)
        {
            endTitle.text = "Mission Clear!";
            endingString = "Ż�⿡ ������ ���ο� �༺�� �����ߴ�! ���� �� �Ϸ翴��. ���ο� ���� ���ȴ�...";
        }
        else
        {
            endTitle.text = "You Failed!";
            endingString = "�ܰ��ο��� ���� ���Ͽ� ����� ���·Ӵ�. �̴�� ������ �ǰ���";
        }

        float fadeCount = 0; //ó�� ���İ�
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
        // TODO: Enemy�� ������ �ڸ��� Instantiate, Level�� Random���� ������
        for(int i=0; i< enemyQuantity; i++)
        {
            float randomX = pos.x + Random.Range(0f, 2f);
            float randomZ = pos.z + Random.Range(0f, 3f);
            GameObject Temp = Instantiate(enemy, new Vector3(randomX, pos.y, randomZ), Quaternion.identity);
            Temp.transform.parent = enemies.transform;
            Temp.SetActive(true);
        }

        //Zombie�� Ȱ��ȭ
        enemies.SetActive(true);

        if (questId < 4) StartCoroutine(OpenDoor(questId - 1));
    }

    public void SetTimer(int m, int s)
    {
        //m = minutes, s = seconds
        minute = m; second = s;
        timer = minute * 60 + second;
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

    IEnumerator OpenDoor(int idx)
    {
        audio.PlayOneShot(DoorOpenClip, 2.0f);

        yield return new WaitForSeconds(0.5f);

        //�� ����
        for (int i = 0; i < 100; i++)
        {
            yield return new WaitForSeconds(0.01f);
            Vector3 dir = (endPoses[idx].position - doors[idx].position).normalized;

            doors[idx].position += dir * Time.deltaTime * speed;

        }


    }
}
