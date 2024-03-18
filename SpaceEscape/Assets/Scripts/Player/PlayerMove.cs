using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(AudioSource))]
public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 7f;
    public float jumpPower = 10f; public bool isJumping = false;
    private float gravity = -20f;   // �߷� ����
    private float yVelocity = 0;    // ���� �ӷ� ����

    public int level = 1;   public TextMeshProUGUI LvText;
    public int killCount = 0;
    public TextMeshProUGUI hpText;
    public int hp = 20; public int maxHp = 20;
    public Image hpImage;
    public GameObject bulletPrefab;

    public AudioClip damagedSfx;       //����
    public AudioClip dieSfx; public AudioClip lvupSFx;
    public AudioClip healSFx;   
    private new AudioSource audio;  //AudioSource Component ���� ����

    CharacterController cc; //CharacterController ĳ��ó�� ����
    private Animation anim;

    void Start()
    {
        cc = GetComponent<CharacterController>();
        anim = GetComponent<Animation>();
        audio = GetComponent<AudioSource>();

        anim.Play("Idle");
    }

    void Update()
    {
        if (GameManager.instance.IsGameOver || GameManager.instance.isGamePaused || GameManager.instance.isShowScript) return;

        Move();

        DisplayHp();
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
        audio.PlayOneShot(damagedSfx, 1.0f);
        if (hp <= 0)
        {
            hp = 0;  DisplayHp();
            audio.PlayOneShot(dieSfx, 2.0f);
            GameManager.instance.EndKey = false;
            GameManager.instance.IsGameOver = true;
        }

    }

    public void OnHeal(int value)
    {
        hp += value;
        audio.PlayOneShot(healSFx, 1.2f);
        if (hp > maxHp)
        {
            hp = maxHp;
        }
        DisplayHp();

    }

    void DisplayHp()
    {
        int x = (800 / maxHp) * (maxHp - hp);
        hpImage.rectTransform.anchoredPosition = new Vector3(-x, 0, 0);
        hpText.text = "<size=80><b>"+hp+ "</b></size><color=#00FFD0><b>/</b></color>"+maxHp;
        

    }

    public void LevelUp()
    {
        if (level * 3 == killCount)
        {
            audio.PlayOneShot(lvupSFx, 3.5f);
            level += 1; killCount = 0;
            maxHp = 20 * level; hp = maxHp;
            LvText.text = level.ToString();

        }
    }
}
