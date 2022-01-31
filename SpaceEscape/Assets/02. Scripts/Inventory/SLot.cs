using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{

    public Item item; // 획득한 아이템
    public int itemCount; // 획득한 아이템 개수
    public Image itemImage; // 아이템 이미지

    [SerializeField]
    private Text text_Count;
    [SerializeField]
    private GameObject go_CountImage;

    // 이미지의 투명도 조절
    // 슬롯 지워줄 때 색상 0으로 만드는 함수 (투명하게)
    public void SetColor(float _alpha)
    {
        Color color = itemImage.color;
        color.a = _alpha; // 알파 값만 변경
        itemImage.color = color;


    }

    // 아이템 확득하는 함수
    public void AddItem(Item _item, int _count = 1) // 기본적으로 아이템 하나씩 획득하니까 1로 설정
    {
        item = _item;
        itemCount = _count; //  count 세서 itemcount에 할당하기
        itemImage.sprite = item.itemImage; // 아이템 스프라이트에 아이템 이미지를 넣어줌

        // 아이템이 medicine일 경우
        if (item.itemType != Item.ItemType.Medicine)
        {
            // 카운트 이미지 활성화 시켜주기
            go_CountImage.SetActive(true);
            // 아이템 카운트만큼 텍스트 바꿔주고 int로 형변환 
            text_Count.text = itemCount.ToString();
        }
        else
        {
            text_Count.text = "0"; // 0으로 초기화
            go_CountImage.SetActive(false); // 총, 단서들은 겹치는게 없어서 활성화 안함

        }

    }

    // 아이템의 개수를 변경하는 함수
    public void SetSlotCount(int _count)
    {
        itemCount += _count;
        text_Count.text = itemCount.ToString; // 텍스트 카운트를 아이템 카운트로 바꿈

        if(itemCount <= 0) // 만약 아이템이 없다면
        {
            ClearSlot();
        }

    }

    //슬롯 비워주는 함수(초기화)
    public void ClearSlot()
    {
        item = null;
        itemCount = 0;
        itemImage.sprite = null;
        SetColor(0); // 투명하게 만듬

        go_CountImage.SetActive(false);
        text_Count.text = "0"; // 텍스트 카운트 0으로 초기화
    }



}
