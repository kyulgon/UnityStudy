using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject missilePrefabs; // �̻��� ������
    public Transform firePosition; // �̻��� ���� ��ġ

    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Fire();
        }

    }


    void Fire()
    {
        Instantiate(missilePrefabs, firePosition.position, Quaternion.identity);
    }


}
