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
            //ù �浹 ������ ���� ����
            ContactPoint cp = coll.GetContact(0);

            //�浹 û���� ���� ���͸� Quaternion Type���� ��ȯ
            Quaternion rot = Quaternion.LookRotation(-cp.normal);

            //VFX�� ���� ����
            GameObject spark = Instantiate(sparkEffect, cp.point, rot);
            Destroy(spark, 0.5f);

            Destroy(gameObject);

        }
    }
}
