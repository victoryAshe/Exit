using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionController : MonoBehaviour
{
    [SerializeField]
    // ������ ���� ������ �ִ� �Ÿ�
    private float range;

    private bool pickupActivated = false; //���� ����: true, ���� �Ұ���: false


    private RaycastHit hitinfo; // �浹ü ���� ����

    [SerializeField]
    private LayerMask layerMask; // ������ ���̾�� �����ϵ��� ���̾� ����


    [SerializeField]
    private Text actionText;  // �ʿ��� ������Ʈ
    // �κ��丮 �޾ƿ��� �Լ�
    [SerializeField]
    private Inventory theInventory;
    

    // Update is called once per frame
    void Update()
    {
        TryAction(); // QŰ�� ������ �� Ȯ��
        CheckItem();
    }

    private void TryAction()
    {
        if(Input.GetKeyDown(KeyCode.Q)) // Q��ư�� ������
        {
            CheckItem();
            CanPickUp(); // QŰ�� ������ �۵��ϴ� �Լ�
        }

    }

    private void CheckItem()
    {
        // ���� �����ϰ� ���ü�� ������ �޾ƿ´�
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hitinfo, range, layerMask))
        {
            // ���ǿ� �����ϴ� �͵鸸 ������ �� �ֵ���
            if(hitinfo.transform.tag == "Item")
            {
                ItemInfoAppear();
            }
        }

        // ������ �ʴ� �͵��� ������ ������� ����� 
        else
        {
            InfoDisappear();
        }
    }

    private void ItemInfoAppear()
    {
        // �ֿ� �� �ִ� ���
        pickupActivated = true;
        // �ؽ�Ʈ Ȱ��ȭ
        actionText.gameObject.SetActive(true);
        // �ؽ�Ʈ ����
        actionText.text = hitinfo.transform.GetComponent<ItemPickUp>().item.itemName + "ȹ�� QŰ";
    }

    private void InfoDisappear()
    {
        // �ֿ� �� ���� ���
        pickupActivated = false;
        // �ؽ�Ʈ Ȱ��ȭ
        actionText.gameObject.SetActive(true);
        
    }

    private void CanPickUp()
    {
        if(pickupActivated) // pickupActivated�� true�� ��
        {
            if(hitinfo.transform != null)
            {
                // ������ ������ ���ֹ�����
                Destroy(hitinfo.transform.gameObject);
                // ����ߴ� ���� ������� ����
                InfoDisappear();
                // ȹ�� �����ߴٰ� �˷��ֱ�
                Debug.Log(hitinfo.transform.GetComponent<ItemPickUp>().item.itemName + "ȹ�� ����");
                theInventory.AcquireItem(hitinfo.transform.GetComponent<ItemPickUp>().item);
            }
        }
    }
}
