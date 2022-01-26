using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 7f;
    public float jumpPower = 10f; public bool isJumping = false;
    private float gravity = -20f;   // �߷� ����
    private float yVelocity = 0;    // ���� �ӷ� ����

    public int hp = 20; int maxHp = 20;
    public Image hpImage;

    CharacterController cc; //CharacterController ĳ��ó�� ����
    private Animation anim;

    void Start()
    {
        cc = GetComponent<CharacterController>();
        anim = GetComponent<Animation>();

        anim.Play("Idle");
    }

    void Update()
    {
        //if (GameManager.gm.gState != GameManager.GameState.Run) return;

        Move();

        UpdateHP();
    }

    void Move()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(h, 0, v);
        dir = dir.normalized;


        //���� ī�޶� �������� ���� ��ȯ
        dir = Camera.main.transform.TransformDirection(dir);

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
        PlayerAnim(h, v);
    }

    void PlayerAnim(float h, float v)
    {
        if (v >= 0.1f) anim.CrossFade("RunF", 0.25f);
        else if (v <= -0.1f) anim.CrossFade("RunB", 0.25f);
        else if (h >= 0.1f) anim.CrossFade("RunR", 0.25f);
        else if (h <= -0.1f) anim.CrossFade("RunL", 0.25f);
        else anim.CrossFade("Idle", 0.25f);
    }

    public void DamageAction(int damage)
    {
        hp -= damage;

    }

    public void OnHeal(int value)
    {
        hp += value;
        if (hp > maxHp)
        {
            hp -= (hp - maxHp);
        }

    }

    void UpdateHP()
    {
        int x = (800 / maxHp) * (maxHp - hp);
        hpImage.rectTransform.anchoredPosition = new Vector3(-x, 0, 0);
    }
}
