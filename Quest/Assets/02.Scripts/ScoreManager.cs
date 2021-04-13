using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    
        public GameObject gameoverText; // ���ӿ��� �� Ȱ��ȭ�� �ؽ�Ʈ ���� ������Ʈ
        private float score; // ���ھ� ���� ����
        private Text scoreTxt;  // ���ھ� �ؽ�Ʈ
        private bool isGameover;    // ���ӿ��� ����

        void Start()
        {
            // ���� �ð��� ���ӿ��� ���� �ʱ�ȭ
            score = 0;
            isGameover = false;
        }


        void Update()
        {
            if (!isGameover)    // ���ӿ����� �ƴ� ����
            {
                // �ð� ���� �Լ� ����
            }

            else
            {
                if (Input.GetKeyDown(KeyCode.R))    // ���ӿ��� ���¿��� RŰ�� ���� ���
                {
                    SceneManager.LoadScene("SampleScene");  // SampleScene ������ �ε�
                }
            }

        }

        public void EndGame()   // ���� ������ ���ӿ��� ���·� �����ϴ� �޼���
        {
            isGameover = true;  // ���� ���¸� ���ӿ��� ���·� ��ȯ
            gameoverText.SetActive(true);   // ���ӿ��� �ؽ�Ʈ ���� ������Ʈ�� Ȱ��ȭ


             scoreTxt.text = "Score :" + (int)score; // �ְ����� recordText �ؽ�Ʈ ������Ʈ�� �̿��� ǥ��
        }
}
