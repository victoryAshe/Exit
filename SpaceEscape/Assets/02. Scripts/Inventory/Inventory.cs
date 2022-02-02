using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public int number;
    public int objectId;
    public List<Button> invenUI = new List<Button>();
    
    public bool InvenActive;

    public GameObject ItemPos;

    // �κ��丮 �ȿ� �� ĭ�� ��ųʸ��� ����
    public Dictionary<int, itemData> inventory = new Dictionary<int, itemData>();

    public class itemData
    {
        // ������ ObjectData�� �������ִ� Ŭ����
        public int quantity;
        public ObjectData data;

        public itemData(ObjectData data, int quantity)
        {
            this.quantity = quantity; this.data = data;
        }

    }
    // ���ϴ� ĭ Ȱ��ȭ ���ؼ�
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
            if (Input.GetKeyDown(KeyCode.E))
            {
                GameManager.instance.isShowScript = false;
                InvenActive = false;
            }
            
        }
    }


    // �������� ��ư ������ �κ��丮�� ������ �߰�
    // AddItem �Լ� ȣ��
    public void AddItem(ObjectData data)
    {

        // �̹� �����ϴ� �������� ���ٸ�... 
        //���� else�� quantity+=1 ���ַ��� �ߴµ�, ���� ���̵��� ���� ���� �ʾ���
        //
        if (!inventory.ContainsKey(data.objectId))
        {
            inventory.Add(data.objectId, new itemData(data, 1)); // ���ڸ� ã�Ƽ� �־��ֱ�

            Image itemImage = invenUI[number].GetComponent<Image>();
            itemImage.sprite = Resources.Load<Sprite>("ItemImage/" + data.objectId);
            itemImage.rectTransform.sizeDelta = new Vector2(itemImage.sprite.rect.width, itemImage.sprite.rect.height);
            itemImage.rectTransform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
        }

            
    }

    // R��ư�� ������
    // DelItem �Լ� ȣ��
    public void DelItem()
    {
        // ������ ������ 0�� ���ϸ� �κ��丮���� ����
        if (inventory[objectId].quantity <= 1)
        {
            Destroy(GameObject.Find(objectId.ToString()));
            inventory.Remove(objectId);
            invenUI[number].GetComponent<Image>().sprite = null;
            invenUI[number].GetComponent<Image>().rectTransform.localScale = new Vector3(1, 1, 1);  //���� ������� �ǵ��� �ֱ�

        }

        GameManager.instance.isShowScript = false;
        InvenActive = false;

    }

    // Q��ư�� ������
    // HoldItem ȣ��
    public void HoldItem()
    {
        if (GameObject.Find("Item"))
        {
            GameObject item = GameObject.Find("Item").transform.Find(objectId.ToString()).gameObject;
            item.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            item.SetActive(true);
            item.transform.position = ItemPos.transform.position;
            item.transform.parent = ItemPos.transform;
            
        }

        GameManager.instance.isShowScript = false;
        InvenActive = false;

    }



}



