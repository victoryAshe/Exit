using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 7f;
    public float jumpPower = 10f; public bool isJumping = false;
    private float gravity = -20f;   // �߷� ����
    private float yVelocity = 0;    // ���� �ӷ� ����

    public int hp = 20; int maxHp = 20;

    CharacterController cc; //CharacterController ĳ��ó�� ����
    Animator anim;          //Animator ����

    void Start()
    {
        cc = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        //if (GameManager.gm.gState != GameManager.GameState.Run) return;

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(h, 0, v);
        dir = dir.normalized;

        //���� ī�޶� �������� ���� ��ȯ
        dir = Camera.main.transform.TransformDirection(dir);

        //anim.SetFloat("MoveMotion", dir.magnitude);
        //���� ���̾���, �ٽ� �ٴڿ� �����ߴٸ�
        if (isJumping && cc.collisionFlags == CollisionFlags.Below)
        {
            isJumping = false;
            yVelocity = 0;
        }

        //Jump: ĳ���� ���� �ӵ��� �߷� �� ����
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            yVelocity = jumpPower;
            isJumping = true;
        }

        //ĳ���� ���� �ӵ��� �߷� ���� ����
        yVelocity += gravity * Time.deltaTime;
        dir.y = yVelocity;

        //�̵�
        cc.Move(dir * moveSpeed * Time.deltaTime);

        //hpSlider.value = (float)hp / (float)maxHp;
    }
}
