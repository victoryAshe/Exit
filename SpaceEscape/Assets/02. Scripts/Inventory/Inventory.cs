using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Inventory : MonoBehaviour
{
    public string number;
    private int objectId;
    public Sprite itemImage;
    public List<Button> invenUI = new List<Button>();
    public Vector3 itemPos;
    public bool InvenActive;
    private Item[] items;
    public int itemCount; // ȹ���� ������ ����
 


    // �κ��丮 ����� ������ �÷��̾��� ������ �Ұ���
    public static bool inventoryActivated = false;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    // �κ��丮 �ȿ� �� ĭ�� ��ųʸ��� ����
    public Dictionary<int, int> inventory = new Dictionary<int, int>();

    // �������� ���̵�, ����
    public Dictionary<int, int> item = new Dictionary<int, int>();


    // �������� ��ư ������ �κ��丮�� ������ �߰�
    // AddItem �Լ� ȣ��
    public void AddItem(int objectId, int count)
    {
        if (Input.GetButtonDown("")) // �������� ��ư�̶� ����
        {
            
                // �̹� �����ϴ� �������� ���ٸ�
                if (!inventory.ContainsKey(objectId))
                {
                    inventory.Add(objectId, 1); // ���ڸ� ã�Ƽ� �־��ֱ�
                    InvenActive = false;    // �����ϸ� invenactive false��
                }
                // ȭ��󿡼� ���� ������Ʈ ���ֱ�
                Destroy(this.gameObject);
            
        }
    }

    // R��ư�� ������
    // DelItem �Լ� ȣ��
    public void DelItem(int objectId, int count)
    {

        // ������ ������ 0�� ���ϸ� �κ��丮���� ����
        if (inventory[objectId] <= 0)
        {
            inventory.Remove(objectId);
        }

        // �������� �̹� 0���� 0�� ����
        if (inventory.ContainsKey(objectId) == false)
        {
            return;
        }

        // �������� 0�� �̻��̸� ���� ���ҽ�Ų��
        inventory[objectId] = inventory[objectId] - 1;

    }

    // Q��ư�� ������
    // HoldItem ȣ��
    public void HoldItem(string objectId, int count)
    {
        // ������ ĭ�� objectId ��������

        // ������ ĭ�� objectId ������ ��������

        // ȭ����� �̹��� ����

        // objectId �ش��ϴ� Item�� Prefab�� Player�� �޼տ�


        /*GameObject inven = null; // �ӽÿ�����Ʈ ����
        inven = GameObject.Find(objectId.ToString());
        inven = GameObject.FindWithTag("ITEM");

        inven.SetActive(false);*/

    }

    // ���ϴ� ĭ Ȱ��ȭ ���ؼ�
    public ObjectData[] _itemData;
    public Button Button0;
    public Button Button1;
    public Button Button2;
    public Button Button3;
    public Button Button4;
    public Button Button5;
    public Button Button6;
    public Button Button7;
    public Button Button8;
    public Button Button9;
    

    public void GetId()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            // ���ϴ� ĭ Ȱ��ȭ
            
            
          
            // �ش� number������ �ִ� �������� objectId�� �޾ƿ´�.
            
            int index = int.Parse(number); // string�� int������ ��ȯ

        }
        
        // DelItem ȣ��
        if (Input.GetKeyDown(KeyCode.R))
        {
            InvenActive = false;

            DelItem(objectId, itemCount); // DelItem ȣ��
        }

        // HoldItem ȣ��
        if (Input.GetKeyDown(KeyCode.Q))
        {
            InvenActive = false;
            string holditem = objectId.ToString();
            HoldItem(holditem, itemCount); // HoldItem ȣ��
        }


        

    }



}



