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


    //Dictionary<int questId, Talk[]>: questId에 따라 objectId별로 talk을 선언
    public Dictionary<int, Talk[]> Script = new Dictionary<int, Talk[]>()
    {
        { 0, new Talk[]{ new Talk(0, "체력을 15 회복시켜주는 아이템이다.") } }
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
        nameText.text = item.name;
        explainText.text = Script[qm.questId][data.objectId].talk;

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
