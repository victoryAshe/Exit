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

    //음원
    public AudioClip selectSfx; public AudioClip deselectSfx; 
    public AudioClip holdSfx; public AudioClip addSfx;  //delItem은 deselect를 그대로 사용
    private new AudioSource audio;  //AudioSource Component 저장 변수

    private int healPower = 15;
    PlayerMove pm;

    // 인벤토리 안에 각 칸을 딕셔너리로 설정
    public Dictionary<int, itemData> inventory = new Dictionary<int, itemData>();

    public class itemData
    {
        // 수량과 ObjectData를 관리해주는 클래스
        public int quantity;
        public ObjectData data;

        public itemData(ObjectData data, int quantity)
        {
            this.quantity = quantity; this.data = data;
        }

    }
    // 원하는 칸 활성화 위해서
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


    // 가져오기 버튼 누르면 인벤토리에 아이템 추가
    // AddItem 함수 호출
    public void AddItem(ObjectData data)
    {
        // 이미 존재하는 아이템이 없다면... 
        //원래 else로 quantity+=1 해주려고 했는데, 게임 난이도를 위해 넣지 않았음
        if (!inventory.ContainsKey(data.objectId))
        {
            audio.PlayOneShot(addSfx, 2.0f);
            inventory.Add(data.objectId, new itemData(data, 1)); // 빈자리 찾아서 넣어주기

            Image itemImage = invenUI[inventory.Count-1].GetComponent<Image>();
            itemImage.sprite = Resources.Load<Sprite>("ItemImage/" + data.objectId);
            itemImage.rectTransform.sizeDelta = new Vector2(itemImage.sprite.rect.width, itemImage.sprite.rect.height);
            itemImage.rectTransform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
        }

            
    }

    // R 누르면: DelItem 함수 호출
    public void DelItem()
    {
        // 아이템 갯수가 0개 이하면 인벤토리에서 삭제
        if (inventory[objectId].quantity <= 1)
        {
            audio.PlayOneShot(deselectSfx, 0.1f);
            if (objectId == 0) pm.OnHeal(healPower);
            
            Destroy(GameObject.Find(objectId.ToString()));
            inventory.Remove(objectId);
            invenUI[number].GetComponent<Image>().sprite = null;
            invenUI[number].GetComponent<Image>().rectTransform.localScale = new Vector3(1, 1, 1);  //원래 사이즈로 되돌려 주기

        }

        GameManager.instance.isShowScript = false;
        InvenActive = false;

    }

    // Q 누르면: HoldItem 호출
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



