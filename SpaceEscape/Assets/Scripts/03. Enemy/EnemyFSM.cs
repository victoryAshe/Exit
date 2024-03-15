using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EnemyFSM : MonoBehaviour
{
    enum EnemyState
    {
        Idle, Move, Attack, Damaged, Die
    }
    EnemyState m_State;
    public int level;
    public Text lvText;

    //## Idle ##
    public float findDistance = 8f;
    Transform player;

    //## Move ##
    public float attackDistance = 2f;
    public float moveSpeed = 5f;

    //## Attack ##
    float currentTime = 0; float attackDelay = 2f;
    public int attackPower;

    public Slider hpSlider;
    public int hp; int maxHp;

    //## DropItem ##
    public GameObject[] Items = new GameObject[] { };

    public AudioClip damagedSFx; public AudioClip dieSFx; public AudioClip hitSFx; public AudioClip idleSFx;
    private new AudioSource audio;  //AudioSource Component 저장 변수


    CharacterController cc;
    Animator anim;


    void Start()
    {
        m_State = EnemyState.Idle;

        player = GameObject.FindWithTag("PLAYER").transform;

        cc = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();

        level = Random.Range(1, 5);
        maxHp = level * 15; hp = maxHp;
        attackPower = level * 3;
        lvText.text = "LV. " + level.ToString();
        audio = GetComponent<AudioSource>();

    }

    void Update()
    {
        if (GameManager.instance.isGameOver || GameManager.instance.isGamePaused) return;

        //DisplayHp
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

        }

    }

    void Idle()
    {
        m_State = EnemyState.Move;
        anim.SetTrigger("IdleToMove");
    }

    void Move()
    {
        if (cc.enabled == false) return;

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
            if (currentTime > attackDelay)
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
        audio.PlayOneShot(hitSFx, 0.1f);
        player.GetComponent<PlayerMove>().DamageAction(attackPower);
    }

    void Damaged()
    {
        audio.PlayOneShot(damagedSFx, 0.2f);
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
        audio.loop = false;
        audio.Pause();
        audio.PlayOneShot(dieSFx, 1.0f);
        cc.enabled = false;

        yield return new WaitForSeconds(2.0f);

        PlayerMove pm = GameObject.FindWithTag("PLAYER").GetComponent<PlayerMove>();
        pm.GetComponent<PlayerMove>().killCount += 1;
        pm.LevelUp();

        //Drop Item
        int index = Random.Range(0, Items.Length - 1);
        GameObject item = Instantiate(Items[index], transform.position, transform.rotation);
        item.name = Items[index].name;

        Destroy(gameObject);
    }
}
