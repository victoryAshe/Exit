using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class pwCtrl : MonoBehaviour
{
    public string password;
    private int id;
    public GameObject keyObject;
    public bool isTrue;

    public GameObject pwPanel;
    public Button exit;
    public TMP_InputField input;
    TextMeshProUGUI hintText;

    public Transform door;  private float speed = 5.0f;
    public Transform endPos;
    Transform player;

    Material mat;

    ObjectData data;
    InGameUICtrl gui;

    public AudioClip DoorOpenClip;
    private new AudioSource audio;

    void Start()
    {

        data = GetComponent<ObjectData>();
        id = data.objectId;
        password = data.password;
        audio = GetComponent<AudioSource>();

        GameObject canvas = GameObject.Find("UIcanvas");
        pwPanel = canvas.transform.Find("InputPanel").gameObject;
        input = pwPanel.GetComponentInChildren<TMP_InputField>();
        exit = pwPanel.GetComponentInChildren<Button>();
        exit.onClick.AddListener(() => OnExitClick());

        gui = GameObject.Find("GameManager").GetComponent<InGameUICtrl>();
        input.onSubmit.AddListener((string pw) => CheckInput(pw));

        mat = gameObject.GetComponent<MeshRenderer>().material;

        player = GameObject.FindWithTag("PLAYER").transform;

        //hintText 변경
        hintText = pwPanel.GetComponentInChildren<TextMeshProUGUI>();
        if (id == 131 || id == 132)
            hintText.text = "";
        else if (id == 208 || id == 209)
            hintText.text = "[Hint] Array Num";
        else if (id == 305)
            hintText.text = "[Hint] 지금은 __C, The Ark의 함장의 ID는 ______";

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (data.hasKey)
                HasKey();
            else
                HasntKey();
        }
    }

    void HasKey()
    {
        if (GameObject.Find(data.keyId.ToString())
            && Vector3.Distance(GameObject.Find(data.keyId.ToString()).transform.position, transform.position) < 5.0f)
        {
            mat.SetColor("_EmissionColor", Color.green);
            StartCoroutine(GoInput());
        }
    }

    void HasntKey()
    {
        if (Vector3.Distance(player.position, transform.position) < 5.0f)
        {
            mat.SetColor("_EmissionColor", Color.green);
            StartCoroutine(GoInput());
        }
    }


    IEnumerator GoInput()
    {
        GameManager.instance.isShowScript = true;
        yield return new WaitForSeconds(1.5f);
        isTrue = true;
        pwPanel.SetActive(true);
        
    }

    public void CheckInput(string pw)
    {
        if (!isTrue) return;

        if (pw == password)
        {
            gui.OnNotification("맞는 비밀번호 입니다.");
            input.text = "Enter Password...";
            StartCoroutine(OpenDoor());
        }
        else 
        {
            gui.OnNotification("틀린 비밀번호 입니다.");
            input.text = "Enter Password...";
            pwPanel.SetActive(false);
            isTrue = false;
            GameManager.instance.isShowScript = false;
            mat.SetColor("_EmissionColor", Color.yellow);

        }
    }

    public void OnExitClick()
    {
        pwPanel.SetActive(false);
        mat.SetColor("_EmissionColor", Color.yellow);
        GameManager.instance.isShowScript = false;
        isTrue = false;

    }

    IEnumerator OpenDoor()
    {
        audio.PlayOneShot(DoorOpenClip, 2.0f);

        yield return new WaitForSeconds(2.0f);
        pwPanel.SetActive(false);
        isTrue = false;
        //문 열기
        for (int i=0; i<100;i++)
        {
            yield return new WaitForSeconds(0.01f);
            Vector3 dir = (endPos.position - door.position).normalized;

            door.position += dir * Time.deltaTime * speed;

        }

        if (data.hasKey)
        {
            //Game Clear
            yield return new WaitForSeconds(1.5f);
            GameManager.instance.EndKey = true;

            StartCoroutine(GameManager.instance.GameOver());
        }
        else
        {
            GameManager.instance.isShowScript = false;
        }


    }


}
