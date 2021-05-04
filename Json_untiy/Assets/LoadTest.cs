using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

public class LoadTest : MonoBehaviour // ������ �ҷ��� Ŭ����
{
    string filePath;

    void Start()
    {
        filePath = Application.persistentDataPath + @"\saves\save.json"; // C:\Users\DMC CONET\AppData\LocalLow\DefaultCompany\Json_untiy +@"\saves\save.json"
    }

    public void LoadDate() // Data�� �ε����ִ� �޼���
    {
        if(File.Exists(filePath)) // ������ �����ϸ�
        {
            var stringdate = File.ReadAllText(filePath); // �����͸� �о��
            var data = JsonConvert.DeserializeObject<SaveFormatTest>(stringdate);
            print(data.name);
            print(data.age);
        }
    }
}
