using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Inventory2 : MonoBehaviour
{
    public string number;
    //private int objectId;
    public List<Button> invenUI = new List<Button>();
    public Vector3 itemPos;
    public bool InvenActive;
 
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
    // AddItem �Լ��� ȣ���ؼ� ���̵� �ش��ϴ� ������ �����ش�
    // �̶� �������� 0������ ����(�����)
    public void AddItem(int objectId, int count)
    {
        if(Input.GetButtonDown("E"))
        {
            InvenActive = false;

            // �������� �߰��ϸ� �κ��丮 ��Ͽ� �߰��Ѵ�
            if (inventory.ContainsKey(objectId) == false)
                inventory.Add(objectId, 0); // �ʱ� ������ 0��

            // �������� ������ ������Ų��
            inventory[objectId] += count;
        }
    }

    // R��ư�� ������
    // DelItem �Լ��� ȣ���ؼ� ���̵� �ش��ϴ� ������ ���ش�
    public void DelItem(int objectId, int count)
    {
        if(Input.GetButtonDown("R"))
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
           inventory[objectId] -= count;
        }   
    }

    // Q��ư�� ������
    // ������ �κ��丮 �ȿ� �ִ� �������� �տ� ���
    public void HoldItem(string objectId, int count)
    {

    }

}


