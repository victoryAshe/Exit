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


    //Dictionary<int objectId, Talk[]>: questId�� ���� objectId���� talk�� ����
    public Dictionary<int, Talk[]> Script = new Dictionary<int, Talk[]>()
    {
        { 0, new Talk[]{ new Talk(0, "ü���� 15 ȸ�������ִ� �������̴�."), new Talk(1, "ü���� 15 ȸ�������ִ� �������̴�."), new Talk(2, "ü���� 15 ȸ�������ִ� �������̴�."), new Talk(3, "ü���� 15 ȸ�������ִ� �������̴�.")} },
        { 100, new Talk[]{ new Talk(1, "�������� �߰��ߴ�. �̰� ��� ���� ���ϱ�?") } },
        { 111, new Talk[]{ new Talk(1, "���� ������ �߰��ߴ�.") } },
        { 112, new Talk[]{ new Talk(1, "�� ���� ������ ����? ��...") } },
        { 113, new Talk[]{ new Talk(1, "��𿣰� ������ ���� �� ����.") } },
        { 114, new Talk[]{ new Talk(1, "�� ���� ������ �ܼ��ϱ�?") } },
        
        { 201, new Talk[]{ new Talk(2, "�������� �߰��ߴ�. ��� ����ұ�?") } },
        { 202, new Talk[]{ new Talk(2, "����Ϳ� ���� ������ ���� �� ����. �� �� �Ѻ���.") } },
        { 203, new Talk[]{ new Talk(2, "ĸƾ�� ���ڴ�.") } },
        { 204, new Talk[]{ new Talk(2, "Eva�� ���ڴ�.") } },
        { 205, new Talk[]{ new Talk(2, "William�� ���ڴ�.") } },
        { 206, new Talk[]{ new Talk(2, "Conan�� ���ڴ�.") } },
        { 207, new Talk[]{ new Talk(2, "��й�ȣ�� �Է��ؾ��ϴ� �� ����.") } },
        
        { 300, new Talk[]{ new Talk(0, "ĸƾ�� ID ī���."), new Talk(1, "ĸƾ�� ID ī���."), new Talk(2, "ĸƾ�� ID ī���."), new Talk(3, "ĸƾ�� ID ī���.")} },
        { 301, new Talk[]{ new Talk(0, "Conan�� ID ī���."), new Talk(1, "Conan�� ID ī���."), new Talk(2, "Conan�� ID ī���."), new Talk(3, "Conan�� ID ī���.") } },
        { 302, new Talk[]{ new Talk(0, "William�� ID ī���."), new Talk(1, "William�� ID ī���."), new Talk(2, "William�� ID ī���."), new Talk(3, "William�� ID ī���.") } },
        { 303, new Talk[]{ new Talk(0, "Mac�� ID ī���."),  new Talk(1, "Mac�� ID ī���."),  new Talk(2, "Mac�� ID ī���."),  new Talk(3, "Mac�� ID ī���.") } },
        { 304, new Talk[]{ new Talk(0, "Eva�� ID ī���."), new Talk(1, "Eva�� ID ī���."), new Talk(2, "Eva�� ID ī���."), new Talk(3, "Eva�� ID ī���.") } },
        { 305, new Talk[]{ new Talk(3, "��й�ȣ�� �Է��ؾ��ϴ� �� ����. �̰͸� Ǯ�� Ż���� �� �ִ�.") } }
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
