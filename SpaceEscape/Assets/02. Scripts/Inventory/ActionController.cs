using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionController : MonoBehaviour
{
    [SerializeField]
    // 아이템 습득 가능한 최대 거리
    private float range;

    private RaycastHit hitinfo; // 충돌체 정보 저장

    [SerializeField]
    private LayerMask layerMask; // 아이템 레이어에만 반응하도록 레이어 설정

    public GameObject actionTextbg;

    [SerializeField]
    private Text actionText;  // 필요한 컴포넌트
    // 인벤토리 받아오는 함수
    [SerializeField]
    private Inventory inven;


    void Start()
    {
        inven = GameObject.Find("Inventory").GetComponent<Inventory>();
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) // Q버튼을 누르면
        {
            CanPickUp(); // Q키를 누르면 작동하는 함수
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

        // 텍스트 활성화
        actionTextbg.SetActive(true);
        // 텍스트 띄우기
        actionText.text = item.name + "획득 [Q키]";

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
                // 획득 성공했다고 알려주기
                actionText.text = target.name+ "획득 성공";
                actionTextbg.SetActive(true);
                inven.AcquireItem(target);

                StartCoroutine(DisabletheText());

            }
        }

    }
}
