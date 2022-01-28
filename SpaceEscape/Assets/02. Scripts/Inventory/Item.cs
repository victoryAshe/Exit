using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    [SerializeField] Text pickUpText;
    bool isPickUp;



    // Start is called before the first frame update
    void Start()
    {
        pickUpText.gameObject.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {
        if(isPickUp && Input.GetKeyDown(KeyCode.Space))
        {
            PickUp();
        }

    }
    private void OntriggerEnter3D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            pickUpText.gameObject.SetActive(true);
            isPickUp = true;
        }
    }

    private void OnTriggerExit3D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            pickUpText.gameObject.SetActive(false);
            isPickUp = false;
        }
    }

    void PickUp()
    {
        Destroy(gameObject);
    }

}
