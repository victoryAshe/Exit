using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptManager : MonoBehaviour
{

    //Dictionary<int objectId, Talk[]>: questId�� ���� objectId���� talk�� ����
    public Dictionary<int, string> Script = new Dictionary<int, string>()
    {
        { 0, "ü���� 15 ȸ�������ִ� �������̴�." },
        { 100, "�������� �߰��ߴ�."+ System.Environment.NewLine + "�̰� ��� ���� ���ϱ�?" },
        { 120, "���ĺ����� ���� ���̴�."+ System.Environment.NewLine + "���� �ǹ̰� ������?"},
        { 121, "���ĺ� M�� ���� ī���."},
        { 122, "���ĺ� S�� ���� ī���."},
        { 123, "���ĺ� H�� ���� ī���."},
        { 124, "���ĺ� Q�� ���� ī���."},
        { 125, "���ĺ� A�� ���� ī���."},
        { 131, "�� ���� ���� ���ϴ� ���ϱ�?"},
        { 132, "�� ���� ������ ���� �� �� ������?"},

        { 201, "�������� �߰��ߴ�. ��� ����ұ�?" },
        { 202, "����Ϳ� ���� ������ ���� �� ����."+ System.Environment.NewLine + "�� �� �Ѻ���." },
        { 203, "ĸƾ�� ���ڴ�." },
        { 204, "Eva�� ���ڴ�." },
        { 205, "William�� ���ڴ�." },
        { 206,"Conan�� ���ڴ�." },
        { 208,"��й�ȣ�� �Է��ؾ��ϴ� �� ����." },
        { 209,"�� ���� ���� �̵��ϴ� ���ϱ�?" },
        
        { 300, "ĸƾ�� ID ī���." },
        { 301, "Conan�� ID ī���." },
        { 302, "William�� ID ī���." },
        { 303, "Mac�� ID ī���." },
        { 304, "Eva�� ID ī���." },
        { 305, "��й�ȣ�� �Է��ؾ��ϴ� �� ����."+ System.Environment.NewLine + "�̰͸� Ǯ�� Ż���� �� �ִ�." }
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
