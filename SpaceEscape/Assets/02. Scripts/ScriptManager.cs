using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptManager : MonoBehaviour
{
    public class Talk
    {
        public int objectId;
        public string talk;

        public Talk(int objectId, string talk)
        {
            this.objectId = objectId;
            this.talk = talk;
        }

    }


    //Dictionary<int objectId, Talk[]>: questId에 따라 objectId별로 talk을 선언
    public Dictionary<int, Talk[]> Script = new Dictionary<int, Talk[]>()
    {
        { 0, new Talk[]{ new Talk(0, "체력을 15 회복시켜주는 아이템이다."), new Talk(1, "체력을 15 회복시켜주는 아이템이다."), new Talk(2, "체력을 15 회복시켜주는 아이템이다."), new Talk(3, "체력을 15 회복시켜주는 아이템이다.")} },
        { 100, new Talk[]{ new Talk(1, "나무판을 발견했다. 이건 어디에 쓰는 판일까?") } },
        { 111, new Talk[]{ new Talk(1, "퍼즐 조각을 발견했다.") } },
        { 112, new Talk[]{ new Talk(1, "이 퍼즐 조각은 뭐지? 흠...") } },
        { 113, new Talk[]{ new Talk(1, "어디엔가 쓰임이 있을 것 같다.") } },
        { 114, new Talk[]{ new Talk(1, "이 퍼즐 조각이 단서일까?") } },
        
        { 201, new Talk[]{ new Talk(2, "손전등을 발견했다. 어디에 써야할까?") } },
        { 202, new Talk[]{ new Talk(2, "모니터에 무슨 정보가 있을 것 같다. 한 번 켜보자.") } },
        { 203, new Talk[]{ new Talk(2, "캡틴의 액자다.") } },
        { 204, new Talk[]{ new Talk(2, "Eva의 액자다.") } },
        { 205, new Talk[]{ new Talk(2, "William의 액자다.") } },
        { 206, new Talk[]{ new Talk(2, "Conan의 액자다.") } },
        { 207, new Talk[]{ new Talk(2, "비밀번호를 입력해야하는 것 같다.") } },
        
        { 300, new Talk[]{ new Talk(0, "캡틴의 ID 카드다."), new Talk(1, "캡틴의 ID 카드다."), new Talk(2, "캡틴의 ID 카드다."), new Talk(3, "캡틴의 ID 카드다.")} },
        { 301, new Talk[]{ new Talk(0, "Conan의 ID 카드다."), new Talk(1, "Conan의 ID 카드다."), new Talk(2, "Conan의 ID 카드다."), new Talk(3, "Conan의 ID 카드다.") } },
        { 302, new Talk[]{ new Talk(0, "William의 ID 카드다."), new Talk(1, "William의 ID 카드다."), new Talk(2, "William의 ID 카드다."), new Talk(3, "William의 ID 카드다.") } },
        { 303, new Talk[]{ new Talk(0, "Mac의 ID 카드다."),  new Talk(1, "Mac의 ID 카드다."),  new Talk(2, "Mac의 ID 카드다."),  new Talk(3, "Mac의 ID 카드다.") } },
        { 304, new Talk[]{ new Talk(0, "Eva의 ID 카드다."), new Talk(1, "Eva의 ID 카드다."), new Talk(2, "Eva의 ID 카드다."), new Talk(3, "Eva의 ID 카드다.") } },
        { 305, new Talk[]{ new Talk(3, "비밀번호를 입력해야하는 것 같다. 이것만 풀면 탈출할 수 있다.") } }
    };

    public GameObject scriptPanel;
    public Image itemImage;
    public Text nameText;
    public Text explainText;

    public Button get;
    public Button exit;

    QuestManager qm;

    void Start()
    {
        exit.onClick.AddListener(() => CloseScript());
        qm = GetComponent<QuestManager>();

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo = new RaycastHit();
            
            if(Physics.Raycast(ray, out hitInfo)&& hitInfo.transform.gameObject.CompareTag("ITEM"))
            {
                ShowScript(hitInfo.transform.gameObject);
            }
        }
    }

    public void ShowScript(GameObject item)
    {
        GameManager.instance.isShowScript = true;
        ObjectData data = item.GetComponent<ObjectData>();
        
        scriptPanel.SetActive(true);
        nameText.text = data.objectName;
        explainText.text = Script[data.objectId][qm.questId].talk;

        itemImage.sprite = Resources.Load<Sprite>("ItemImage/"+data.objectId);
        itemImage.rectTransform.sizeDelta = new Vector2(itemImage.sprite.rect.width, itemImage.sprite.rect.height);
        itemImage.rectTransform.localScale = new Vector3(0.4f, 0.4f, 0.4f);


    }

    public void CloseScript()
    {
        GameManager.instance.isShowScript = false;
        scriptPanel.SetActive(false);
    }
}
