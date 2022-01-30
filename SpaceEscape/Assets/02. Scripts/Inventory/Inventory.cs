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

    /* button~ �߰� */

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

    // �κ��丮�� �������� �߰��Ѵ�
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

    // �κ��丮 �ȿ� �������� �����Ѵ�
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

    // QŰ�� ������ �տ� �������� ������
    // �κ��丮�󿡴� �κ��丮 �ȿ� �ִ� �������� �������
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
            //TODO: �ش� number������ �ִ� �������� objectId�� �޾ƿ´�.
            int index = int.Parse(number);
            Debug.Log(index);
        }

    }


}
