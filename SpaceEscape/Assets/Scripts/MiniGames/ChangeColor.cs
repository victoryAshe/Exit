using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeColor : MonoBehaviour
{
    public Image image;
    public Color coco;
    public Button button;
    

    void Start()
    {
        image = GetComponent<Image>();
        coco = new Color(100/255f, 100/255f, 100/255f,255/255f);
        button = GetComponent<Button>();

        button.onClick.AddListener(() => OnClickthis());

    }

    void Update()
    {


    }

    public void OnClickthis()
    {

        if (image.color != coco)
        {
            image.color = coco;
        }
        else
        {
            image.color = Color.white;
        }

    }
}
