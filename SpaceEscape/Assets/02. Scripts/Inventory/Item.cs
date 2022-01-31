using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Item : MonoBehaviour
{
    public string itemName; // 아이템 이름
    public ItemType itemType; // 아이템 유형
    public Sprite itemImage; // 아이템 이미지
    public GameObject itemPrefab; // 아이템 프리팹

    public enum ItemType
    {
        Use,
        UnUse,
        Gun,
        Medicine
    }



}
