using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionController : MonoBehaviour
{
    [SerializeField]
    // ������ ���� ������ �ִ� �Ÿ�
    private float range;

    private RaycastHit hitinfo; // �浹ü ���� ����

    [SerializeField]
    private LayerMask layerMask; // ������ ���̾�� �����ϵ��� ���̾� ����

    public GameObject actionTextbg;

    [SerializeField]
    private Text actionText;  // �ʿ��� ������Ʈ
    // �κ��丮 �޾ƿ��� �Լ�
    [SerializeField]
    private Inventory inven;


    void Start()
    {
        inven = GameObject.Find("Inventory").GetComponent<Inventory>();
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) // Q��ư�� ������
        {
            CanPickUp(); // QŰ�� ������ �۵��ϴ� �Լ�
        }
            
        CheckItem();
    }



    private void CheckItem()
    {


        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hited;
        if (Physics.Raycast(ray, out hited))
        {
            GameObject target = hited.transform.gameObject;
            if (Vector3.Distance(transform.position, hited.transform.position) <= range&& target.layer == 3 << 1)
            {
                ItemInfoAppear(target);
                StartCoroutine(DisabletheText());

            }
        }


    }

    void ItemInfoAppear(GameObject item)
    {

        // �ؽ�Ʈ Ȱ��ȭ
        actionTextbg.SetActive(true);
        // �ؽ�Ʈ ����
        actionText.text = item.name + "ȹ�� [QŰ]";

    }
    IEnumerator DisabletheText()
    {
        yield return new WaitForSeconds(2);
        actionTextbg.SetActive(false);
    }


    private void CanPickUp()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hited;
        if (Physics.Raycast(ray, out hited))
        {
            GameObject target = hited.transform.gameObject;

            if (Vector3.Distance(transform.position, hited.transform.position) <= range&& target.layer == 3 << 1)
            {
                Destroy(target);
                // ȹ�� �����ߴٰ� �˷��ֱ�
                actionText.text = target.name+ "ȹ�� ����";
                actionTextbg.SetActive(true);
                inven.AcquireItem(target);

                StartCoroutine(DisabletheText());

            }
        }

    }
}
