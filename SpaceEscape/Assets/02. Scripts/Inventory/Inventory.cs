using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class Inventory : MonoBehaviour
{
    public int number;
    public int objectId;
    public List<Button> invenUI = new List<Button>();
    
    public bool InvenActive;

    public GameObject ItemPos;

    //����
    public AudioClip selectSfx; public AudioClip deselectSfx; 
    public AudioClip holdSfx; public AudioClip addSfx;  //delItem�� deselect�� �״�� ���
    private new AudioSource audio;  //AudioSource Component ���� ����

    private int healPower = 15;
    PlayerMove pm;

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
        pm = GameObject.FindWithTag("PLAYER").GetComponent<PlayerMove>();
        audio = GetComponent<AudioSource>();

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
                audio.PlayOneShot(deselectSfx, 0.1f);
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
        if (!inventory.ContainsKey(data.objectId))
        {
            audio.PlayOneShot(addSfx, 2.0f);
            inventory.Add(data.objectId, new itemData(data, 1)); // ���ڸ� ã�Ƽ� �־��ֱ�

            Image itemImage = invenUI[inventory.Count-1].GetComponent<Image>();
            itemImage.sprite = Resources.Load<Sprite>("ItemImage/" + data.objectId);
            itemImage.rectTransform.sizeDelta = new Vector2(itemImage.sprite.rect.width, itemImage.sprite.rect.height);
            itemImage.rectTransform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
        }

            
    }

    // R ������: DelItem �Լ� ȣ��
    public void DelItem()
    {
        // ������ ������ 0�� ���ϸ� �κ��丮���� ����
        if (inventory[objectId].quantity <= 1)
        {
            audio.PlayOneShot(deselectSfx, 0.1f);
            if (objectId == 0) pm.OnHeal(healPower);
            
            Destroy(GameObject.Find(objectId.ToString()));
            inventory.Remove(objectId);
            invenUI[number].GetComponent<Image>().sprite = null;
            invenUI[number].GetComponent<Image>().rectTransform.localScale = new Vector3(1, 1, 1);  //���� ������� �ǵ��� �ֱ�

        }

        GameManager.instance.isShowScript = false;
        InvenActive = false;

    }

    // Q ������: HoldItem ȣ��
    public void HoldItem()
    {
        if (GameObject.Find("Item").transform.Find(objectId.ToString()))
        {
            audio.PlayOneShot(holdSfx, 0.1f);
            GameObject item = GameObject.Find("Item").transform.Find(objectId.ToString()).gameObject;
            Vector3 originScale = item.transform.localScale;
            item.transform.localScale = new Vector3(originScale.x*0.1f, originScale.y*0.1f, originScale.z*0.1f);
            item.SetActive(true);
            item.transform.position = ItemPos.transform.position;
            item.transform.parent = ItemPos.transform;
            
        }

        GameManager.instance.isShowScript = false;
        InvenActive = false;

    }



}



