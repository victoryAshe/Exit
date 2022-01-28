using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    private int objectId;

    public List<Button> invenUI = new List<Button>();

    public Dictionary<int, int>
    inventory = new Dictionary<int, int>();

    public Vector3 itemPos;

    public bool InvenActive;

    /* button~ 추가 */
    

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
        GetValue();

     
    }

   
    public void AddItem(GameObject item)
    {
        int objectId = item.GetComponent<ObjectData>().objectId;
        item.SetActive(false);

        if(inventory.ContainsKey(objectId))
        {
            inventory[objectId] = inventory[objectId] + 1;
        }

        else
        {
            inventory.Add(objectId, 1);
        }
    }

    
    public void DelItem(GameObject item)
    {
        if(inventory.ContainsKey(objectId))
        {
            inventory[objectId] = inventory[objectId] - 1;
        }
        else
        {
            inventory.Remove(objectId);
        }
    }


    // Q 버튼을 누르면 오브젝트에 있는 item 을 손에 잡고 있는다.
    /*    public void HoldItem(int objectId)
        {

        }
    */


    public void GetValue()
    {
        if (Input.GetKeyDown("R"))
        {
            InvenActive = false;
        }

        if (Input.GetKeyDown("0"))
        {
            Image itemImage = invenUI[9].GetComponent<Image>();

            string GameObject = "";
            GameObject = int GameObject;
                       

        }



    }

    /*void ()
    {
        ButtonClick(this.gameObject);
    }
    */
}
