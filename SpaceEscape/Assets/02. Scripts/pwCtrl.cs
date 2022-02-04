using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class pwCtrl : MonoBehaviour
{
    private string password;
    public GameObject keyObject;

    public GameObject pwPanel;
    public Button exit;
    public TMP_InputField input;

    public Transform door;  private float speed = 5.0f;
    public Transform endPos;

    Material mat;

    ObjectData data;
    InGameUICtrl gui;

    void Start()
    {
        data = GetComponent<ObjectData>();
        password = data.password;

        GameObject canvas = GameObject.Find("Canvas");
        pwPanel = canvas.transform.Find("InputPanel").gameObject;
        input = pwPanel.GetComponentInChildren<TMP_InputField>();
        exit = pwPanel.GetComponentInChildren<Button>();
        exit.onClick.AddListener(() => OnExitClick());

        gui = GameObject.Find("GameManager").GetComponent<InGameUICtrl>();
        input.onSubmit.AddListener((string pw) => CheckInput(pw));

        mat = gameObject.GetComponent<MeshRenderer>().material;

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && GameObject.Find(data.keyId.ToString()))
        {
            keyObject = GameObject.Find(data.keyId.ToString());

            if (Vector3.Distance(keyObject.transform.position, transform.position) < 5.0f)
            {
                mat.SetColor("_EmissionColor", Color.green);
                StartCoroutine(GoInput());
            }

        }
    }

    IEnumerator GoInput()
    {
        GameManager.instance.isShowScript = true;
        yield return new WaitForSeconds(1.5f);
        pwPanel.SetActive(true);
        
    }

    public void CheckInput(string pw)
    {
        if (pw == password)
        {
            gui.OnNotification("맞는 비밀번호 입니다.");
            StartCoroutine(OpenDoor());
        }
        else 
        {
            gui.OnNotification("틀린 비밀번호 입니다.");
            input.text = "Enter Password...";
            pwPanel.SetActive(false);
            GameManager.instance.isShowScript = false;
            mat.SetColor("_EmissionColor", Color.yellow);

        }
    }

    public void OnExitClick()
    {
        pwPanel.SetActive(false);
        mat.SetColor("_EmissionColor", Color.yellow);
        GameManager.instance.isShowScript = false;

    }

    IEnumerator OpenDoor()
    {
        yield return new WaitForSeconds(2.0f);
        pwPanel.SetActive(false);
        //문 열기
        for (int i=0; i<100;i++)
        {
            yield return new WaitForSeconds(0.01f);
            Vector3 dir = (endPos.position - door.position).normalized;
            door.position += dir * Time.deltaTime * speed; 
        }
        yield return new WaitForSeconds(1.5f);
        GameManager.instance.EndKey = true;
        StartCoroutine(GameManager.instance.GameOver());
    }
}
