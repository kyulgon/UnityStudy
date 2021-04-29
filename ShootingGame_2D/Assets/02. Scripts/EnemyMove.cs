using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private float EnemySpeed = 5f;
    Vector3 dir;

    void Start()
    {
        // ���⺯��
       

        // ���� �Լ��� ����Ͽ� 0���� 9�ȿ��� ���� int ��
        int Ran = Random.Range(0, 10);

        // 30�۴� player������ �̵�
        if(Ran % 3 == 0)
        {
            // �÷��̾ ã��
            GameObject Target = GameObject.Find("Player");

            // ���ⱸ�ϱ� : �÷��̾� ���� (Player������ - Enemy������) ���⺤��
            dir = Target.transform.position - transform.position;

            // ����ũ�⺤�� 1�� �����
            dir.Normalize();
        }
        else
        {
            // �������� �Ʒ���
            dir = Vector3.down;
        }        
    }

    
    void Update()
    {
        transform.Translate(dir * EnemySpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);

        Destroy(gameObject);
    }
}
