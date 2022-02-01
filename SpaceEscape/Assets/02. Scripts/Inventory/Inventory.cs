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
    public int itemCount; // 획득한 아이템 개수
 


    // 인벤토리 사용할 때에는 플레이어의 움직임 불가능
    public static bool inventoryActivated = false;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    // 인벤토리 안에 각 칸을 딕셔너리로 설정
    public Dictionary<int, int> inventory = new Dictionary<int, int>();

    // 아이템의 아이디, 갯수
    public Dictionary<int, int> item = new Dictionary<int, int>();


    // 가져오기 버튼 누르면 인벤토리에 아이템 추가
    // AddItem 함수 호출
    public void AddItem(int objectId, int count)
    {
        if (Input.GetButtonDown("")) // 가져오기 버튼이랑 연결
        {
            
                // 이미 존재하는 아이템이 없다면
                if (!inventory.ContainsKey(objectId))
                {
                    inventory.Add(objectId, 1); // 빈자리 찾아서 넣어주기
                    InvenActive = false;    // 성공하면 invenactive false로
                }
                // 화면상에서 게임 오브젝트 없애기
                Destroy(this.gameObject);
            
        }
    }

    // R버튼을 누르면
    // DelItem 함수 호출
    public void DelItem(int objectId, int count)
    {

        // 아이템 갯수가 0개 이하면 인벤토리에서 삭제
        if (inventory[objectId] <= 0)
        {
            inventory.Remove(objectId);
        }

        // 아이템이 이미 0개면 0개 유지
        if (inventory.ContainsKey(objectId) == false)
        {
            return;
        }

        // 아이템이 0개 이상이면 갯수 감소시킨다
        inventory[objectId] = inventory[objectId] - 1;

    }

    // Q버튼을 누르면
    // HoldItem 호출
    public void HoldItem(string objectId, int count)
    {
        // 선택한 칸의 objectId 가져오기

        // 선택한 칸의 objectId 데이터 가져오기

        // 화면상의 이미지 삭제

        // objectId 해당하는 Item의 Prefab을 Player의 왼손에


        /*GameObject inven = null; // 임시오브젝트 생성
        inven = GameObject.Find(objectId.ToString());
        inven = GameObject.FindWithTag("ITEM");

        inven.SetActive(false);*/

    }

    // 원하는 칸 활성화 위해서
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
            // 원하는 칸 활성화
            
            
          
            // 해당 number순서에 있는 아이템의 objectId를 받아온다.
            
            int index = int.Parse(number); // string을 int형으로 변환

        }
        
        // DelItem 호출
        if (Input.GetKeyDown(KeyCode.R))
        {
            InvenActive = false;

            DelItem(objectId, itemCount); // DelItem 호출
        }

        // HoldItem 호출
        if (Input.GetKeyDown(KeyCode.Q))
        {
            InvenActive = false;
            string holditem = objectId.ToString();
            HoldItem(holditem, itemCount); // HoldItem 호출
        }


        

    }



}



