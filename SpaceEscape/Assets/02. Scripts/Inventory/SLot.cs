using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IPointerClickHandler, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
{
    private Vector3 originPos;

    public Item item; // 획득한 아이템
    public int itemCount; // 획득한 아이템 개수
    public Image itemImage; // 아이템 이미지

    [SerializeField]
    private Text text_Count;
    [SerializeField]
    private GameObject go_CountImage;

    // 아이템 버리기위한 변수 선언
    private Rect baseRect;

    void start()
    {
        baseRect = transform.parent.parent.GetComponent<RectTransform>().rect;
        originPos = transform.position;
    }


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
        text_Count.text = itemCount.ToString(); // 텍스트 카운트를 아이템 카운트로 바꿈

        if (itemCount <= 0) // 만약 아이템이 없다면
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

        text_Count.text = "0"; // 텍스트 카운트 0으로 초기화
        go_CountImage.SetActive(false);

    }

    // 인벤토리 위에서 마우스 오른쪽 버튼을 누르면 들기
    // HoldItem이랑 똑같은 거
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            if (item != null) // null이 아니면
            {
                if (item.itemType == Item.ItemType.Use) // 단서가 되는 오브젝트라면
                {
                    // 들기

                }
            }
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (item != null)
        {
            DragSlot.instance.dragSlot = this;
            DragSlot.instance.DragSetImage(itemImage);

            DragSlot.instance.transform.position = eventData.position;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (item != null)
        {
            DragSlot.instance.transform.position = eventData.position;
        }

    }

    // 인벤토리 창을 벗어나면 인벤토리에서 삭제됨
    public void OnEndDrag(PointerEventData eventData)
    {
        if (item != null)
        {
            if (DragSlot.instance.transform.localPosition.x < baseRect.xMin || DragSlot.instance.transform.localPosition.x > baseRect.xMax
                 || DragSlot.instance.transform.localPosition.y < baseRect.yMin || DragSlot.instance.transform.localPosition.y > baseRect.yMax)
            {
                // 원하는 위치에 떨어트리기 - 원하는 컴포넌트 위치에
                //Instantiate(DragSlot.instance.dragSlot.item.itemPrefab, Inventory.transform.position, Quaternion.identity);
                DragSlot.instance.dragSlot.ClearSlot();

            }
            DragSlot.instance.SetColor(0);
            DragSlot.instance.dragSlot = null;

        }

    }

    public void OnDrop(PointerEventData eventData)
    {
        if (DragSlot.instance.dragSlot != null)
        {
            ChangeSlot();
        }

    }

    private void ChangeSlot()
    {
        Item _tempItem = item;
        int _tempItemCount = itemCount;

        AddItem(DragSlot.instance.dragSlot.item, DragSlot.instance.dragSlot.itemCount);

        if (_tempItem != null)
        {
            DragSlot.instance.dragSlot.AddItem(_tempItem, _tempItemCount);
        }
        else
        {
            DragSlot.instance.dragSlot.ClearSlot();
        }

    }




}
