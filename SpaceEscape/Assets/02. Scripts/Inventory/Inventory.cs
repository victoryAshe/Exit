using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Inventory2 : MonoBehaviour
{
    public string number;
    private int objectId;
    public List<Button> invenUI = new List<Button>();
    public Vector3 itemPos;
    public bool InvenActive;

    // �κ��丮 ����� ������ �÷��̾��� ������ �Ұ���
    public static bool inventoryActivated = false;

    private Item[] items;

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


    // E��ư�� ������
    // AddItem �Լ��� ȣ���ؼ� ���̵� �ش��ϴ� ������ �����ش�.
    // �̶� �������� 0������ ����(�����)
    public void AddItem(int objectId, int count)
    {
        if (Input.GetButtonDown("E"))
        {
            InvenActive = false;

            // �������� �߰��ϸ� �κ��丮 ��Ͽ� �߰��Ѵ�
            if (inventory.ContainsKey(objectId) == false)
            {
                inventory.Add(objectId, 0); // �ʱ� ������ 0��
            }
            else
            {
                return;
            }
            
            // �������� ������ ������Ų��
            inventory[objectId] = inventory[objectId] + 1;
        }
    }

    // R��ư�� ������
    // DelItem �Լ��� ȣ���ؼ� ���̵� �ش��ϴ� ������ ���ش�
    public void DelItem(int objectId, int count)
    {
        if (Input.GetButtonDown("R"))
        {
            InvenActive = false;

            // ������ ������ 0�� ���ϸ� �κ��丮���� ����
            if (inventory[objectId] < 0)
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
    }

    // Q��ư�� ������
    // ������ �κ��丮 �ȿ� �ִ� �������� �տ� ���
    public void HoldItem(string objectId, int count)
    {
        GameObject inven = null; // �ӽÿ�����Ʈ ����
        inven = GameObject.Find(objectId.ToString());
        inven = GameObject.FindWithTag("ITEM");
        

    

        inven.SetActive(false);
    }


    public void GetId()
    {
        
        if (Input.GetKeyDown(KeyCode.R))
        {
            InvenActive = false;

            if(InvenActive)
            {

            }


        }


        if (Input.GetKeyDown(number))
        {
            // �ش� number������ �ִ� �������� objectId�� �޾ƿ´�.
            GameObject inven = null; // �ӽÿ�����Ʈ ����
            inven = GameObject.Find(objectId.ToString());




            int index = int.Parse(number); // string�� int������ ��ȯ
            



        }

    }

}


