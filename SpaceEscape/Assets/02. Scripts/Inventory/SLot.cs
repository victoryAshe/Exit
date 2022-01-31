using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IPointerClickHandler, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
{
    private Vector3 originPos;

    public Item item; // ȹ���� ������
    public int itemCount; // ȹ���� ������ ����
    public Image itemImage; // ������ �̹���

    [SerializeField]
    private Text text_Count;
    [SerializeField]
    private GameObject go_CountImage;

    // ������ ���������� ���� ����
    private Rect baseRect;

    void start()
    {
        baseRect = transform.parent.parent.GetComponent<RectTransform>().rect;
        originPos = transform.position;
    }


    // �̹����� ���� ����
    // ���� ������ �� ���� 0���� ����� �Լ� (�����ϰ�)
    public void SetColor(float _alpha)
    {
        Color color = itemImage.color;
        color.a = _alpha; // ���� ���� ����
        itemImage.color = color;


    }

    // ������ Ȯ���ϴ� �Լ�
    public void AddItem(Item _item, int _count = 1) // �⺻������ ������ �ϳ��� ȹ���ϴϱ� 1�� ����
    {
        item = _item;
        itemCount = _count; //  count ���� itemcount�� �Ҵ��ϱ�
        itemImage.sprite = item.itemImage; // ������ ��������Ʈ�� ������ �̹����� �־���

        // �������� medicine�� ���
        if (item.itemType != Item.ItemType.Medicine)
        {
            // ī��Ʈ �̹��� Ȱ��ȭ �����ֱ�
            go_CountImage.SetActive(true);
            // ������ ī��Ʈ��ŭ �ؽ�Ʈ �ٲ��ְ� int�� ����ȯ 
            text_Count.text = itemCount.ToString();
        }
        else
        {
            text_Count.text = "0"; // 0���� �ʱ�ȭ
            go_CountImage.SetActive(false); // ��, �ܼ����� ��ġ�°� ��� Ȱ��ȭ ����

        }

    }

    // �������� ������ �����ϴ� �Լ�
    public void SetSlotCount(int _count)
    {
        itemCount += _count;
        text_Count.text = itemCount.ToString(); // �ؽ�Ʈ ī��Ʈ�� ������ ī��Ʈ�� �ٲ�

        if (itemCount <= 0) // ���� �������� ���ٸ�
        {
            ClearSlot();
        }

    }

    //���� ����ִ� �Լ�(�ʱ�ȭ)
    public void ClearSlot()
    {
        item = null;
        itemCount = 0;
        itemImage.sprite = null;
        SetColor(0); // �����ϰ� ����

        text_Count.text = "0"; // �ؽ�Ʈ ī��Ʈ 0���� �ʱ�ȭ
        go_CountImage.SetActive(false);

    }

    // �κ��丮 ������ ���콺 ������ ��ư�� ������ ���
    // HoldItem�̶� �Ȱ��� ��
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            if (item != null) // null�� �ƴϸ�
            {
                if (item.itemType == Item.ItemType.Use) // �ܼ��� �Ǵ� ������Ʈ���
                {
                    // ���

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

    // �κ��丮 â�� ����� �κ��丮���� ������
    public void OnEndDrag(PointerEventData eventData)
    {
        if (item != null)
        {
            if (DragSlot.instance.transform.localPosition.x < baseRect.xMin || DragSlot.instance.transform.localPosition.x > baseRect.xMax
                 || DragSlot.instance.transform.localPosition.y < baseRect.yMin || DragSlot.instance.transform.localPosition.y > baseRect.yMax)
            {
                // ���ϴ� ��ġ�� ����Ʈ���� - ���ϴ� ������Ʈ ��ġ��
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
