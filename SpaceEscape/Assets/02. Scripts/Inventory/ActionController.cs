using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionController : MonoBehaviour
{
    [SerializeField]
    // 아이템 습득 가능한 최대 거리
    private float range;

    private bool pickupActivated = false; //습득 가능: true, 습득 불가능: false


    private RaycastHit hitinfo; // 충돌체 정보 저장

    [SerializeField]
    private LayerMask layerMask; // 아이템 레이어에만 반응하도록 레이어 설정


    [SerializeField]
    private Text actionText;  // 필요한 컴포넌트
    // 인벤토리 받아오는 함수
    [SerializeField]
    private Inventory theInventory;
    

    // Update is called once per frame
    void Update()
    {
        TryAction(); // Q키가 눌리는 지 확인
        CheckItem();
    }

    private void TryAction()
    {
        if(Input.GetKeyDown(KeyCode.Q)) // Q버튼을 누르면
        {
            CheckItem();
            CanPickUp(); // Q키를 누르면 작동하는 함수
        }

    }

    private void CheckItem()
    {
        // 방향 설정하고 충격체의 정보를 받아온다
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hitinfo, range, layerMask))
        {
            // 조건에 만족하는 것들만 가져올 수 있도록
            if(hitinfo.transform.tag == "Item")
            {
                ItemInfoAppear();
            }
        }

        // 보이지 않는 것들은 정보를 사라지게 만든다 
        else
        {
            InfoDisappear();
        }
    }

    private void ItemInfoAppear()
    {
        // 주울 수 있는 경우
        pickupActivated = true;
        // 텍스트 활성화
        actionText.gameObject.SetActive(true);
        // 텍스트 띄우기
        actionText.text = hitinfo.transform.GetComponent<ItemPickUp>().item.itemName + "획득 Q키";
    }

    private void InfoDisappear()
    {
        // 주울 수 없는 경우
        pickupActivated = false;
        // 텍스트 활성화
        actionText.gameObject.SetActive(true);
        
    }

    private void CanPickUp()
    {
        if(pickupActivated) // pickupActivated가 true일 때
        {
            if(hitinfo.transform != null)
            {
                // 아이템 주으면 없애버린다
                Destroy(hitinfo.transform.gameObject);
                // 출력했던 정보 사라지게 만듬
                InfoDisappear();
                // 획득 성공했다고 알려주기
                Debug.Log(hitinfo.transform.GetComponent<ItemPickUp>().item.itemName + "획득 성공");
                theInventory.AcquireItem(hitinfo.transform.GetComponent<ItemPickUp>().item);
            }
        }
    }
}
