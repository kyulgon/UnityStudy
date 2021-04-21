using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterCtrl : MonoBehaviour
{
    public enum MonsterState // ���� ���������� �ִ� Enum
    {
        idle,
        trace,
        attack,
        die
    }

    // ������ ���� ���� ������ ���� �� Enum ����
    public MonsterState monsterState = MonsterState.idle; 

    // �ӵ� ����� ���� ���� ������Ʈ�� ������ �Ҵ�
    private Transform monsterTr;
    private Transform playerTr;
    private NavMeshAgent nvAgent;
    private Animator animator;
    private int hp = 100;

    public float traceDist = 6.0f; // ���� �����Ÿ�
    public float attackDist = 2.0f; // ���� �����Ÿ�
    public bool isDie = false; // ���� ��� ����

    

    

    void Start()
    {
        monsterTr = GetComponent<Transform>();
        playerTr = GameObject.FindWithTag("Player").GetComponent<Transform>();
        nvAgent = this.gameObject.GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        // ��������� ��ġ�� �����ϸ� �ٷ� ���� ����
        // nvAgent.destination = playerTr.position;

        StartCoroutine(this.CheckMonsterState()); // ���� �������� ������ �ൿ ���¸� üũ�ϴ� �ڷ�ƾ �Լ�
        StartCoroutine(this.MonsterAction()); // ������ ���¿� ���� �����ϴ� ��ƾ�� ����
        
    }

    void Update()
    {
        nvAgent.destination = playerTr.position;
        animator.SetBool("IsTrace", true);
    }

    IEnumerator CheckMonsterState()
    {
        while(!isDie)
        {
            yield return new WaitForSeconds(0.2f);

            // ���Ϳ� �÷��̾� ������ �Ÿ� ����
            float dist = Vector3.Distance(playerTr.position, monsterTr.position);

            if(dist <= attackDist && !FindObjectOfType<GameManger>().isGameOver) // ���ݰŸ� ���� �̳��� ���Դ���
            {
                monsterState = MonsterState.attack;
            }
            else if(dist <= traceDist)
            {
                monsterState = MonsterState.trace;
            }
            else
            {
                monsterState = MonsterState.idle;
            }
        }
    }

    IEnumerator MonsterAction()
    {
        while(!isDie)
        {
            switch(monsterState)
            {
                case MonsterState.idle: // idle ����
                    nvAgent.isStopped = true;
                    animator.SetBool("IsTrace", false);
                    break;
                case MonsterState.trace: // ���� ����
                    nvAgent.destination = playerTr.position;
                    nvAgent.isStopped = false;
                    animator.SetBool("IsAttack", false);
                    animator.SetBool("IsTrace", true);
                    break;
                case MonsterState.attack:
                    nvAgent.isStopped = true;
                    animator.SetBool("IsAttack", true);
                    break;
            }
            yield return null;
        }
    }

    public void GetDamage(float amounnt)
    {
        hp -= (int)(amounnt / 2.0f);
        animator.SetTrigger("IsHit");

        if(hp <=0)
        {
            MonsterDie();
        }
    }

    private void MonsterDie()
    {
        if (isDie == true)
            return;

        StopAllCoroutines();
        isDie = true;
        monsterState = MonsterState.die;
        nvAgent.isStopped = true;
        animator.SetTrigger("IsDie");

        gameObject.GetComponentInChildren<CapsuleCollider>().enabled = false;
        foreach (Collider coll in GetComponentsInChildren<CapsuleCollider>())
        {
            coll.enabled = false;
        }

        FindObjectOfType<GameManger>().GetScored(2);
    }
}
