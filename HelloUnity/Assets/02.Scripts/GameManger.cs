using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManger : MonoBehaviour
{
    public GameObject gameoverText;// ���ӿ��� �г�
    public GameObject spawnerPrefabs; // ������ ������
    public Text timeText; // ���� �ð�
    public Text recordText; //�ְ� ����� ����
    

    private float surviveTime; // �����ð�
    private bool isGameover; // ���ӿ���

    public GameObject level; // ���� ���� ������ ����
    public GameObject bullerSpawnerPrefab;
    Vector3[] bulletSpawners = new Vector3[4];
    int spawnCounter = 0;

    //[SerializeField] GameObject enemey;
    //[SerializeField] Transform[] createEnemy;
    //[SerializeField] float create_time;


    void Start()
    {
        //InvokeRepeating("creat", 0, create_time);

        surviveTime = 0;
        isGameover = false;

       // �迭�� �� ����
        bulletSpawners[0].x = -8f;
        bulletSpawners[0].y = 1f;
        bulletSpawners[0].z = 8f;

        bulletSpawners[1].x = 8f;
        bulletSpawners[1].y = 1f;
        bulletSpawners[1].z = 8f;

        bulletSpawners[2].x = 8f;
        bulletSpawners[2].y = 1f;
        bulletSpawners[2].z = -8f;

        bulletSpawners[3].x = -8f;
        bulletSpawners[3].y = 1f;
        bulletSpawners[3].z = -8f;


    }

    void Update()
    {
        if(!isGameover) // ���� �ʾ����� ���� ����
        {
            surviveTime += Time.deltaTime;
            timeText.text = "Time:" + (int)surviveTime;

            if (surviveTime < 5f && spawnCounter == 0)
            {
                GameObject bulletSpawner = Instantiate(bullerSpawnerPrefab, bulletSpawners[spawnCounter], Quaternion.identity);
                bulletSpawner.transform.parent = level.transform;
                bulletSpawner.transform.localPosition = bulletSpawners[spawnCounter];
                level.GetComponent<Roator>().rotationSpeed += 15;
                spawnCounter++;
            }
            else if (surviveTime >= 5f && surviveTime < 10f && spawnCounter == 1)
            {
                GameObject bulletSpawner = Instantiate(bullerSpawnerPrefab, bulletSpawners[spawnCounter], Quaternion.identity);
                bulletSpawner.transform.parent = level.transform;
                bulletSpawner.transform.localPosition = bulletSpawners[spawnCounter];
                level.GetComponent<Roator>().rotationSpeed += 15;
                spawnCounter++;
            }
            else if (surviveTime >= 10f && surviveTime < 15f && spawnCounter == 2)
            {
                GameObject bulletSpawner = Instantiate(bullerSpawnerPrefab, bulletSpawners[spawnCounter], Quaternion.identity);
                bulletSpawner.transform.parent = level.transform;
                bulletSpawner.transform.localPosition = bulletSpawners[spawnCounter];
                level.GetComponent<Roator>().rotationSpeed += 15;
                spawnCounter++;
            }
            else if (surviveTime >= 15f && surviveTime < 20f && spawnCounter == 3)
            {
                GameObject bulletSpawner = Instantiate(bullerSpawnerPrefab, bulletSpawners[spawnCounter], Quaternion.identity);
                bulletSpawner.transform.parent = level.transform;
                bulletSpawner.transform.localPosition = bulletSpawners[spawnCounter];
                level.GetComponent<Roator>().rotationSpeed += 15;
                spawnCounter++;
            }

        }
        else // �׾����� R ������ �ٽ� ���� �ε���
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("SampleScene");
            }
        }
    }

    public void EndGame() // ������ ������ ���� ����
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

    //void creat() // InvokeRepeating�� �־��� �Լ�
    //{
    //    int i = Random.Range(0, 8);

    //    Instantiate(enemey, createEnemy[i].position, createEnemy[i].rotation);
    //}
}
