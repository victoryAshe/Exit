using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseToLight : MonoBehaviour
{
    public GameObject Light;
    Material mat;
    public Texture targetT;
    public Texture originT;

    public bool changing;

    InGameUICtrl gui;
    
    void Start()
    {
        Light = GameObject.Find(GetComponent<ObjectData>().keyId.ToString());
        mat = gameObject.GetComponent<MeshRenderer>().material;

        mat.EnableKeyword("_DETAIL_MULX2");

        gui = GameObject.Find("GameManager").GetComponent<InGameUICtrl>();
        
    }

    void Update()
    {
        if (Light && Vector3.Distance(transform.position, Light.transform.position) < 3.0f)
            CheckChanging();
    }

    void CheckChanging()
    {
        if (changing)
            return;
        else
        {
            StartCoroutine(ChangeMaterial());
        }
    }

    IEnumerator ChangeMaterial()
    {
        changing = true;
        mat.SetTexture("_EmissionMap", targetT);
        mat.SetTexture("_DetailAlbedoMap", targetT);


        while (Vector3.Distance(transform.position, Light.transform.position) < 3.0f)
        {
            yield return new WaitForSeconds(0.1f);
            mat.SetFloat("_Metallic", mat.GetFloat("_Metallic") + 0.01f);
        }
        gui.OnNotification("캡틴의 액자에서 빛이 난다." + System.Environment.NewLine + "무슨 의미가 있는 것 같다.");

        StartCoroutine(ReturnMaterial());
        changing = false;

    }

    IEnumerator ReturnMaterial()
    {
        while (mat.GetFloat("_Metallic")>0)
        {
            yield return new WaitForSeconds(0.01f);
            mat.SetFloat("_Metallic", mat.GetFloat("_Metallic") - 0.1f);
        }

        mat.SetTexture("_EmissionMap", null);
        mat.SetTexture("_DetailAlbedoMap", null);
 
        
    }
}
