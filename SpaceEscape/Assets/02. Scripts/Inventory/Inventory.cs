using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public string number;
    public int objectId;
    public Sprite itemImage;
    public List<Button> invenUI = new List<Button>();
    public bool InvenActive;
    public GameObject ItemPos;

    // �κ��丮 ����� ������ �÷��̾��� ������ �Ұ���
    public static bool inventoryActivated = false;

    // �κ��丮 �ȿ� �� ĭ�� ��ųʸ��� ����
    public Dictionary<int, itemData> inventory = new Dictionary<int, itemData>();

    public class itemData
    {
        // ������ ObjectData�� �������ִ� Ŭ����
        public int quantity;
        public ObjectData data;

        public itemData(ObjectData data, int quantity)
        {
            this.quantity = quantity; this.data = data;
        }

    }
    // ���ϴ� ĭ Ȱ��ȭ ���ؼ�
    //public ObjectData[] _itemData;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(InvenActive)
        {
            if (Input.GetKeyDown(KeyCode.Q)) HoldItem();
            if (Input.GetKeyDown(KeyCode.R)) DelItem();
            if (Input.GetKeyDown(KeyCode.E)) InvenActive = false;
        }
    }


    // �������� ��ư ������ �κ��丮�� ������ �߰�
    // AddItem �Լ� ȣ��
    public void AddItem(int objectId, ObjectData data)
    {

        // �̹� �����ϴ� �������� ���ٸ�
        if (!inventory.ContainsKey(objectId)) 
            inventory.Add(objectId, new itemData(data, 1)); // ���ڸ� ã�Ƽ� �־��ֱ�

        // ȭ��󿡼� ���� ������Ʈ ���ֱ�-> ScriptManager���� ���ֱ�(SetActive false)
        //Destroy(this.gameObject);


    }

    // R��ư�� ������
    // DelItem �Լ� ȣ��
    public void DelItem()
    {

        
        // ������ ������ 0�� ���ϸ� �κ��丮���� ����
        if (inventory[objectId].quantity <= 0)
        {
            inventory.Remove(objectId);
        }

        // �������� �̹� 0���� 0�� ����
        if (inventory.ContainsKey(objectId) == false)
        {
            return;
        }

        // �������� 0�� �̻��̸� ���� ���ҽ�Ų��
        inventory[objectId].quantity = inventory[objectId].quantity - 1;


        InvenActive = false;


    }

    // Q��ư�� ������
    // HoldItem ȣ��
    public void HoldItem()
    {
        GameObject parent = GameObject.Find("Item");
        //GameObject Item = parent.transform.Find();
        //Item.transform.parent = ItemPos.transform;
        ItemPos.SetActive(true);



        GameObject inven = null; // �ӽÿ�����Ʈ ����
        inven = GameObject.Find(objectId.ToString());
        inven = GameObject.FindWithTag("ITEM");

        
        InvenActive = false;

    }



}



