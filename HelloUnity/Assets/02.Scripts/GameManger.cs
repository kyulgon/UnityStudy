using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManger : MonoBehaviour
{
    public GameObject gameoverText;// ���ӿ��� �г�
    public GameManger spawnerPrefabs; // ������ ������
    public Text timeText; // ���� �ð�
    public Text recordText; //�ְ� ����� ����
    

    private float surviveTime; // �����ð�
    private bool isGameover; // ���ӿ���

    [SerializeField] GameObject enemey;
    [SerializeField] Transform[] createEnemy;
    [SerializeField] float create_time;
    

    void Start()
    {
        InvokeRepeating("creat", 0, create_time);

        surviveTime = 0;
        isGameover = false;
       
    }

    void Update()
    {
        if(!isGameover) // ���� �ʾ����� ���� ����
        {
            surviveTime += Time.deltaTime;
            timeText.text = "Time:" + (int)surviveTime;
                        
            
        }
        else // �׾����� R ������ �ٽ� ���� �ε���
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("SampleScene");
            }
        }
    }

    public void EndGame()
    {
        isGameover = true;
        gameoverText.SetActive(true);

        float bestTime = PlayerPrefs.GetFloat("BestTime");

        if(surviveTime > bestTime)
        {
            bestTime = surviveTime;
            PlayerPrefs.SetFloat("BestTime", bestTime);
        }

        recordText.text = "Best Time:" + (int)bestTime;
    }

    void creat()
    {
        int i = Random.Range(0, 8);

        Instantiate(enemey, createEnemy[i].position, createEnemy[i].rotation);


    }
}
