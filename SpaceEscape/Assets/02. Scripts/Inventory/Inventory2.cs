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


    // 인벤토리 안에 각 칸을 딕셔너리로 설정
    public Dictionary<int, int> inventory = new Dictionary<int, int>();
    // 아이템의 아이디, 갯수
    public Dictionary<int, int> item = new Dictionary<int, int>();

    // E버튼을 누르면
    // AddItem 함수를 호출해서 아이디에 해당하는 갯수를 더해준다
    // 이때 아이템은 0개부터 시작(양수만)
    public void AddItem(int objectId, int count)
    {
        if(Input.GetButtonDown("E"))
        {
            InvenActive = false;

            // 아이템을 추가하면 인벤토리 목록에 추가한다
            if (inventory.ContainsKey(objectId) == false)
                inventory.Add(objectId, 0); // 초기 개수는 0개

            // 아이템의 갯수를 증가시킨다
            inventory[objectId] += count;
        }
    }

    // R버튼을 누르면
    // DelItem 함수를 호출해서 아이디에 해당하는 갯수를 빼준다
    public void DelItem(int objectId, int count)
    {
        if(Input.GetButtonDown("R"))
        {
            InvenActive = false;
        
            // 아이템 갯수가 0개 이하면 인벤토리에서 삭제
            if (inventory[objectId] < 0)
            {
               inventory.Remove(objectId);
            }
                
            // 아이템이 이미 0개면 0개 유지
            if (inventory.ContainsKey(objectId) == false)
            {
               return;
            }

           // 아이템이 0개 이상이면 갯수 감소시킨다
           inventory[objectId] -= count;
        }   
    }

    // Q버튼을 누르면
    // 선택한 인벤토리 안에 있는 아이템을 손에 든다
    public void HoldItem(string objectId, int count)
    {

    }

}


