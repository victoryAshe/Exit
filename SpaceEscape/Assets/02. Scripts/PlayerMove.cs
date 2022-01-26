using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 7f;
    public float jumpPower = 10f; public bool isJumping = false;
    private float gravity = -20f;   // 중력 변수
    private float yVelocity = 0;    // 수직 속력 변수

    public int hp = 20; int maxHp = 20;

    CharacterController cc; //CharacterController 캐시처리 변수
    Animator anim;          //Animator 변수

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

        //메인 카메라를 기준으로 방향 변환
        dir = Camera.main.transform.TransformDirection(dir);

        //anim.SetFloat("MoveMotion", dir.magnitude);
        //점프 중이었고, 다시 바닥에 착지했다면
        if (isJumping && cc.collisionFlags == CollisionFlags.Below)
        {
            isJumping = false;
            yVelocity = 0;
        }

        //Jump: 캐릭터 수직 속도에 중력 값 적용
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            yVelocity = jumpPower;
            isJumping = true;
        }

        //캐릭터 수직 속도에 중력 값을 적용
        yVelocity += gravity * Time.deltaTime;
        dir.y = yVelocity;

        //이동
        cc.Move(dir * moveSpeed * Time.deltaTime);

        //hpSlider.value = (float)hp / (float)maxHp;
    }
}
