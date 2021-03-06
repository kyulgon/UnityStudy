using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    //이동속도
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
        // Input 키값 받기
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(h, v, 0);

        //방향
       // Vector3 dir = new Vector3(variableJoystick.Horizontal, variableJoystick.Vertical, 0);

        //이동
        //transform.Translate(dir * speed * Time.deltaTime);

        //P = P0 + vt(현재위치 + 가속도*시간)
        transform.position = transform.position + dir * speed * Time.deltaTime;
    }
}

