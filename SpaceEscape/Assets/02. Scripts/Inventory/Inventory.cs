using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // �κ��丮 ����� ������ �÷��̾��� ������ �Ұ���
    public static bool inventoryActivated = false;

    // �ʿ��� ������Ʈ
    [SerializeField]
    public GameObject go_InventoryBase;
    [SerializeField]
    public GameObject go_SlotsParent; // ���Ե� ����ִ� content

    // ���Ե�
    private Slot[] slots;



    // Start is called before the first frame update
    void Start()
    {
        slots = go_SlotsParent.GetComponentsInChildren<Slot>(); //���Ե� �迭 �ȿ� ��� ���Ե��� ���� ��

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // ���Կ� ������ ä���ֱ�
    public void AcquireItem(Item _item, int _count = 1)
    {
        if (Item.ItemType.Medicine == _item.itemType)
        {
            for (int i = 0; i < slots.Length; i++)
            {
                if (slots[i].item != null) // null�� �ƴҶ��� ��
                { 

                    // �̹� �����ϴ� �������� ������ ������ ����
                    if (slots[i].item.itemName == _item.itemName) // ������ �̸��̶� ���Կ� ����ִ� �������� ������ 
                    {
                        slots[i].SetSlotCount(_count);
                        return;
                    }
                }
            }
        
        }

        for (int i = 0; i < slots.Length; i++)
        {
            // �̹� �����ϴ� �������� ���ٸ�
            if (slots[i].item.itemName == "")
            {
                slots[i].AddItem(_item, _count); // ���ڸ� ã�Ƽ� �־��ֱ�
                return;
            }
        }
    }





}
