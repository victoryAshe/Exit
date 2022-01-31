using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : MonoBehaviour
{
    public float damage = 20.0f;    //�Ѿ� �ı���
    private float force = 1500.0f;  //�߻��ϴ� ��
    private Rigidbody rb;

    public int weaponPower;
    PlayerMove pm;

    void Start()
    {
        pm = GameObject.FindWithTag("PLAYER").GetComponent<PlayerMove>();
        weaponPower = pm.level * 3;

        rb = GetComponent<Rigidbody>();

        //�Ѿ��� ���� �������� Force�� ����
        rb.AddForce(transform.forward * force);

        Destroy(gameObject, 3.0f);
    }

    private void OnCollisionEnter(Collision coll)
    {
        if(coll.transform.CompareTag("ENEMY"))
        {
            EnemyFSM eFSM = coll.transform.GetComponent<EnemyFSM>();
            eFSM.HitEnemy(weaponPower);
            Destroy(gameObject);
                
        }
    }
}
