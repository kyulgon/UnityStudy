using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    //�̵��ӵ�
    public float speed = 5;
    public VariableJoystick variableJoystick;


    // Start is called before the first frame update
    void Start()
    {
#if UNITY_EDITOR || UNITY_STANDALONE
        variableJoystick.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Input Ű�� �ޱ�
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(h, v, 0);

        //����
       // Vector3 dir = new Vector3(variableJoystick.Horizontal, variableJoystick.Vertical, 0);

        //�̵�
        //transform.Translate(dir * speed * Time.deltaTime);

        //P = P0 + vt(������ġ + ���ӵ�*�ð�)
        transform.position = transform.position + dir * speed * Time.deltaTime;
    }
}

