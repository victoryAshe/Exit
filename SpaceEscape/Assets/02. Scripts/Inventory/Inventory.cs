using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class Inventory : MonoBehaviour
{
    public string number;

    private int objectId;

    public List<Button> invenUI = new List<Button>();

    public Dictionary<int, int>
    inventory = new Dictionary<int, int>();

    public Vector3 itemPos;

    public bool InvenActive;

    /* button~ 추가 */

    public Sprite[] Object;
    public bool GetValue;

    // Start is called before the first frame update
    void Start()
    {
        /*
        Image image = uibutton.GetComponent<image>();
        Debug.Log(image.sprite.name);
        */
    }

    // Update is called once per frame
    void Update()
    {


    }

    // 인벤토리에 아이템을 추가한다
    public void AddItem(GameObject item)
    {
        int objectId = item.GetComponent<ObjectData>().objectId;
        item.SetActive(false);

        if (inventory.ContainsKey(objectId))
        {
            inventory[objectId] = inventory[objectId] + 1;
        }

        else
        {
            inventory.Add(objectId, 1);
        }
    }

    // 인벤토리 안에 아이템을 삭제한다
    public void DelItem(GameObject item, int index)
    {
        if (inventory.ContainsKey(objectId))
        {
            inventory[objectId] = inventory[objectId] - 1;
        }
        else
        {
            inventory.Remove(objectId);



        }
    }

    // Q키를 누르면 손에 아이템이 잡힌다
    // 인벤토리상에는 인벤토리 안에 있던 아이템은 사라진다
    public void Holditem(int objectId)
    {
        if (Input.GetKeyDown("Q"))
        {
            InvenActive = true;

        }

    }



    public void GetId()
    {
        if (Input.GetKeyDown("R"))
        {
            InvenActive = false;
        }

        if (Input.GetKeyDown("0"))
        {


        }

        if (Input.GetKeyDown("1"))
        {




        }

        if (Input.GetKeyDown(number))
        {
            //TODO: 해당 number순서에 있는 아이템의 objectId를 받아온다.
            int index = int.Parse(number);
            Debug.Log(index);
        }

    }


}
