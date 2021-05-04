using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

public class SaveTest : MonoBehaviour
{
    string filePath; // ��� �־��� ����
    string files; // ���� �־��� ����

    void Start()
    {
        filePath = Application.persistentDataPath + @"\saves"; // C:\Users\DMC CONET\AppData\LocalLow\DefaultCompany\Json_untiy
        files = @"\save.json"; // ���� �̸� ����
    }

    public void SaveFile() // ���̺����� �޼���
    {
        if(!Directory.Exists(filePath)) // ���ϰ�ο� ���丮�� �������� ������
        {
            Directory.CreateDirectory(filePath); // ���ϰ�ο� ���丮 �����
        }
        
        SaveFormatTest test = new SaveFormatTest("Ant", 5); // saveFormatTest�� �Ķ���͸� �־��༭ ����

        var t = JsonUtility.ToJson(test); // t�� Json���� ��ȯ
        var t2 = JsonConvert.SerializeObject(test); // JSON ���ڿ��� ����� ���ؼ��� JsonConvert.SerializeObject() �޼��带 ���
        File.WriteAllText(filePath + files, t); // t������ filePath ������ �־ Text�� ����
    }
}
