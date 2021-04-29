using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    private int colorNum = 1;
    Renderer mat;

    public float m_fSpeed = 5.0f;
    Vector3 m_vecTarget;
    void Start()
    {
        mat = GetComponent<Renderer>();
        m_vecTarget = transform.position;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // ī�޶� ���ؿ� ���콺 �����ǰ��� ray�� �־���
            RaycastHit hit; // �浹�� �κ��� hit���� ������
            if (Physics.Raycast(ray, out hit, 10000f)) // Raycast �߻�
            {
                m_vecTarget = hit.point; // Ÿ���� �浹 ����Ʈ�� ����
                SwitchColor();

            }
        }

        transform.position = Vector3.MoveTowards(transform.position, m_vecTarget, m_fSpeed * Time.deltaTime); // �̵��ϱ�

    }


    void SwitchColor()
    {
        switch (colorNum)
        {
            case 0:
                mat.material.color = Color.white;
                break;
            case 1:
                mat.material.color = Color.green;
                break;
            case 2:
                mat.material.color = Color.blue;
                break;
            case 3:
                mat.material.color = Color.black;
                break;
            case 4:
                mat.material.color = Color.grey;
                break;
            case 5:
                mat.material.color = Color.yellow;
                break;

        }
        colorNum++;
        if (colorNum > 6)
        {
            colorNum -= 7;
        }
    }
}
