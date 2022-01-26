using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyFSM : MonoBehaviour
{
    enum EnemyState
    {
        Idle, Move, Attack, Damaged, Die
    }
    EnemyState m_State;

    //## Idle ##
    public float findDistance = 8f;
    Transform player;

    //## Move ##
    public float attackDistance = 2f;
    public float moveSpeed = 5f;

    //## Attack ##
    float currentTime = 0;  float attackDelay = 2f;
    public int attackPower = 3;

    public Slider hpSlider;
    public int hp = 15; int maxHp = 15;

    CharacterController cc;
    Animator anim;

    void Start()
    {
        m_State = EnemyState.Idle;
        player = GameObject.FindWithTag("PLAYER").transform;

        cc = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();

    }

    void Update()
    {
        hpSlider.value = (float)hp / (float)maxHp;

        switch (m_State)
        {
            case EnemyState.Idle:
                Idle();
                break;
            case EnemyState.Move:
                Move();
                break;
            case EnemyState.Attack:
                Attack();
                break;
            case EnemyState.Damaged:
                Damaged();
                break;
            case EnemyState.Die:
                Die();
                break;
        }

    }

    void Idle()
    {
        if (Vector3.Distance(transform.position, player.position) < findDistance)
        {
            m_State = EnemyState.Move;
            anim.SetTrigger("IdleToMove");

        }
    }

    void Move()
    {
        if (Vector3.Distance(transform.position, player.position) > attackDistance)
        {
            Vector3 dir = (player.position - transform.position).normalized;
            cc.Move(dir * moveSpeed * Time.deltaTime);
            transform.forward = dir;

        }
        else
        {
            m_State = EnemyState.Attack;

            currentTime = attackDelay;
            anim.SetTrigger("MoveToAttackDelay");

        }
    }

    void Attack()
    {
        if (Vector3.Distance(transform.position, player.position) < attackDistance)
        {
            currentTime += Time.deltaTime;
            if(currentTime>attackDelay)
            {
                //player.GetComponent<PlayerMove>().DamageAction(attackPower);
                currentTime = 0;
                anim.SetTrigger("StartAttack");

            }
        }
        else
        {
            m_State = EnemyState.Move;
            currentTime = 0;
            anim.SetTrigger("AttackToMove");
        }
    }

    public void AttackAction()
    {
        player.GetComponent<PlayerMove>().DamageAction(attackPower);
    }

    void Damaged()
    {
        StartCoroutine(DamageProcess());
    }

    IEnumerator DamageProcess()
    {
        yield return new WaitForSeconds(1.0f);

        m_State = EnemyState.Move;

    }

    public void HitEnemy(int hitPower)
    {
        if (m_State == EnemyState.Damaged || m_State == EnemyState.Die)
            return;

        hp -= hitPower;
        
        if (hp > 0)
        {
            m_State = EnemyState.Damaged;
            anim.SetTrigger("Damaged");
            Damaged();
        }
        else
        {
            m_State = EnemyState.Die;
            anim.SetTrigger("Die");
            Die();
        }
    }

    void Die()
    {
        StartCoroutine(DieProcess());
    }

    IEnumerator DieProcess()
    {
        cc.enabled = false;
        
        yield return new WaitForSeconds(2.0f);
        Destroy(gameObject);

    }
}
