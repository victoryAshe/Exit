using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptManager : MonoBehaviour
{

    //Dictionary<int objectId, Talk[]>: questId에 따라 objectId별로 talk을 선언
    public Dictionary<int, string> Script = new Dictionary<int, string>()
    {
        { 0, "체력을 15 회복시켜주는 아이템이다." },
        { 100, "나무판을 발견했다."+ System.Environment.NewLine + "이건 어디에 쓰는 판일까?" },
        { 120, "알파벳들이 쓰인 판이다."+ System.Environment.NewLine + "무슨 의미가 있을까?"},
        { 121, "알파벳 M이 쓰인 카드다."},
        { 122, "알파벳 S가 쓰인 카드다."},
        { 123, "알파벳 H가 쓰인 카드다."},
        { 124, "알파벳 Q가 쓰인 카드다."},
        { 125, "알파벳 A가 쓰인 카드다."},
        { 131, "이 문은 어디로 통하는 문일까?"},
        { 132, "이 문이 열리면 어디로 갈 수 있을까?"},

        { 201, "손전등을 발견했다. 어디에 써야할까?" },
        { 202, "모니터에 무슨 정보가 있을 것 같다."+ System.Environment.NewLine + "한 번 켜보자." },
        { 203, "캡틴의 액자다." },
        { 204, "Eva의 액자다." },
        { 205, "William의 액자다." },
        { 206,"Conan의 액자다." },
        { 208,"비밀번호를 입력해야하는 것 같다." },
        { 209,"이 문은 어디로 이동하는 문일까?" },
        
        { 300, "캡틴의 ID 카드다." },
        { 301, "Conan의 ID 카드다." },
        { 302, "William의 ID 카드다." },
        { 303, "Mac의 ID 카드다." },
        { 304, "Eva의 ID 카드다." },
        { 305, "비밀번호를 입력해야하는 것 같다."+ System.Environment.NewLine + "이것만 풀면 탈출할 수 있다." }
    };

    public GameObject scriptPanel;
    public Image itemImage; public Text nameText;   public Text explainText;

    public Button get;  public Button exit;

    GameObject item;    GameObject itemParent;  ObjectData data;    
    GameObject player;

    Inventory inven;
    InGameUICtrl gui;

    void Start()
    {
        exit.onClick.AddListener(() => CloseScript());
        get.onClick.AddListener(() => GetItem());
        inven = GetComponent<Inventory>();
        gui = GetComponent<InGameUICtrl>();
        player = GameObject.FindWithTag("PLAYER");
        itemParent = GameObject.Find("Item");
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo = new RaycastHit();
            
            if (Physics.Raycast(ray, out hitInfo) && Vector3.Distance(player.transform.position, hitInfo.transform.position) < 4.0f)
            {
                GameObject hit = hitInfo.transform.gameObject;

                if (hit.CompareTag("ITEM"))
                    ShowScript(hit);
                else if (hit.layer == 3 << 1)
                {
                    int id = hit.GetComponent<ObjectData>().objectId;
                    gui.OnNotification(Script[id]);
                }
            }

        }
    }

    public void ShowScript(GameObject item)
    {
        GameManager.instance.isShowScript = true;

        this.item = item;
        data = item.GetComponent<ObjectData>();
        
        scriptPanel.SetActive(true);
        nameText.text = data.objectName;
        explainText.text = Script[data.objectId];

        itemImage.sprite = Resources.Load<Sprite>("ItemImage/"+data.objectId);
        itemImage.rectTransform.sizeDelta = new Vector2(itemImage.sprite.rect.width, itemImage.sprite.rect.height);
        itemImage.rectTransform.localScale = new Vector3(0.4f, 0.4f, 0.4f);


    }

    public void CloseScript()
    {
        GameManager.instance.isShowScript = false;
        scriptPanel.SetActive(false);
    }

    public void GetItem()
    {
        inven.AddItem(data);
        item.transform.parent = itemParent.transform;
        scriptPanel.SetActive(false);
        item.SetActive(false);
        GameManager.instance.isShowScript = false;

    }
}
