using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetId : MonoBehaviour
{
    public List<Button> invenUI;
    public string number;

    Inventory inven;
    // Start is called before the first frame update
    void Start()
    {
        inven = GameObject.Find("GameManager").GetComponent<Inventory>();
        invenUI = inven.invenUI;
    }

    // Update is called once per frame
    void Update()
    {
        Get();
    }
    
    public void Get()
    {
        if(Input.GetKeyDown(number))
        {
            int index = int.Parse(number)-1;
            if (index < 0) index = invenUI.Count-1;

            if (invenUI[index].GetComponent<Image>().sprite)
            {
                inven.InvenActive = true;
                GameManager.instance.isShowScript = true;
                string name = invenUI[index].GetComponent<Image>().sprite.name;
                int objectId = int.Parse(invenUI[index].GetComponent<Image>().sprite.name);
                inven.objectId = objectId;
                inven.number = index;
            }


        }
    }
    

}

