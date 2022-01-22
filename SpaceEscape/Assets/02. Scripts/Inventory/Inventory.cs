using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public int objectId;

    public List<Image> invenUI = new List<Image>();

    public Dictionary<int, int>
    inventory = new Dictionary<int, int>();
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

     
    }

   
    public void AddItem(int objectId)
    {
        if(inventory.ContainsKey(objectId))
        {
            inventory[objectId] = inventory[objectId] + 1;
        }

        else
        {
            inventory.Add(objectId, 1);
        }
    }

    public void DelItem(int objectId)
    {

    }

    public void HoldItem(int objectId)
    {

    }

}
