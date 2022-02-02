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

    // 인벤토리 사용할 때에는 플레이어의 움직임 불가능
    public static bool inventoryActivated = false;

    // 인벤토리 안에 각 칸을 딕셔너리로 설정
    public Dictionary<int, itemData> inventory = new Dictionary<int, itemData>();

    public class itemData
    {
        // 수량과 ObjectData를 관리해주는 클래스
        public int quantity;
        public ObjectData data;

        public itemData(ObjectData data, int quantity)
        {
            this.quantity = quantity; this.data = data;
        }

    }
    // 원하는 칸 활성화 위해서
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


    // 가져오기 버튼 누르면 인벤토리에 아이템 추가
    // AddItem 함수 호출
    public void AddItem(int objectId, ObjectData data)
    {

        // 이미 존재하는 아이템이 없다면
        if (!inventory.ContainsKey(objectId)) 
            inventory.Add(objectId, new itemData(data, 1)); // 빈자리 찾아서 넣어주기

        // 화면상에서 게임 오브젝트 없애기-> ScriptManager에서 해주기(SetActive false)
        //Destroy(this.gameObject);


    }

    // R버튼을 누르면
    // DelItem 함수 호출
    public void DelItem()
    {

        
        // 아이템 갯수가 0개 이하면 인벤토리에서 삭제
        if (inventory[objectId].quantity <= 0)
        {
            inventory.Remove(objectId);
        }

        // 아이템이 이미 0개면 0개 유지
        if (inventory.ContainsKey(objectId) == false)
        {
            return;
        }

        // 아이템이 0개 이상이면 갯수 감소시킨다
        inventory[objectId].quantity = inventory[objectId].quantity - 1;


        InvenActive = false;


    }

    // Q버튼을 누르면
    // HoldItem 호출
    public void HoldItem()
    {
        GameObject parent = GameObject.Find("Item");
        //GameObject Item = parent.transform.Find();
        //Item.transform.parent = ItemPos.transform;
        ItemPos.SetActive(true);



        GameObject inven = null; // 임시오브젝트 생성
        inven = GameObject.Find(objectId.ToString());
        inven = GameObject.FindWithTag("ITEM");

        
        InvenActive = false;

    }



}



