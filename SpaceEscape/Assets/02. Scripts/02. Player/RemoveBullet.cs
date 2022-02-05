using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveBullet : MonoBehaviour
{
    public GameObject sparkEffect;

    private void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.CompareTag("WORLD"))
        {
            //첫 충돌 지점의 정보 추출
            ContactPoint cp = coll.GetContact(0);

            //충돌 청알의 법선 벡터를 Quaternion Type으로 변환
            Quaternion rot = Quaternion.LookRotation(-cp.normal);

            //VFX의 동적 생성
            GameObject spark = Instantiate(sparkEffect, cp.point, rot);
            Destroy(spark, 0.5f);

            Destroy(gameObject);

        }
    }
}
