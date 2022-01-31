using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // 인벤토리 사용할 때에는 플레이어의 움직임 불가능
    public static bool inventoryActivated = false;

    // 필요한 컴포넌트
    [SerializeField]
    public GameObject go_InventoryBase;
    [SerializeField]
    public GameObject go_SlotsParent; // 슬롯들 들어있는 content

    // 슬롯들
    private Slot[] slots;



    // Start is called before the first frame update
    void Start()
    {
        slots = go_SlotsParent.GetComponentsInChildren<Slot>(); //슬롯들 배열 안에 모든 슬롯들을 들어가게 함

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 슬롯에 아이템 채워넣기
    public void AcquireItem(Item _item, int _count = 1)
    {
        if (Item.ItemType.Medicine == _item.itemType)
        {
            for (int i = 0; i < slots.Length; i++)
            {
                if (slots[i].item != null) // null이 아닐때만 비교
                { 

                    // 이미 존재하는 아이템이 있으면 갯수만 증가
                    if (slots[i].item.itemName == _item.itemName) // 아이템 이름이랑 슬롯에 들어있는 아이템이 같으면 
                    {
                        slots[i].SetSlotCount(_count);
                        return;
                    }
                }
            }
        
        }

        for (int i = 0; i < slots.Length; i++)
        {
            // 이미 존재하는 아이템이 없다면
            if (slots[i].item.itemName == "")
            {
                slots[i].AddItem(_item, _count); // 빈자리 찾아서 넣어주기
                return;
            }
        }
    }





}
