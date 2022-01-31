using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Item : MonoBehaviour
{
    public string itemName; // ������ �̸�
    public ItemType itemType; // ������ ����
    public Sprite itemImage; // ������ �̹���
    public GameObject itemPrefab; // ������ ������

    public enum ItemType
    {
        Use,
        UnUse,
        Gun,
        Medicine
    }



}
