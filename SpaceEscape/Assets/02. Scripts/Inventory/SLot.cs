using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{

    public Item item; // ȹ���� ������
    public int itemCount; // ȹ���� ������ ����
    public Image itemImage; // ������ �̹���

    [SerializeField]
    private Text text_Count;
    [SerializeField]
    private GameObject go_CountImage;

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
        text_Count.text = itemCount.ToString; // �ؽ�Ʈ ī��Ʈ�� ������ ī��Ʈ�� �ٲ�

        if(itemCount <= 0) // ���� �������� ���ٸ�
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

        go_CountImage.SetActive(false);
        text_Count.text = "0"; // �ؽ�Ʈ ī��Ʈ 0���� �ʱ�ȭ
    }



}
