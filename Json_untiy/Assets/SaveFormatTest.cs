using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ������ ������ ���� �����͸� ���� Ŭ����
[System.Serializable]
public class SaveFormatTest
{
    public string name;
    public int age;

    public SaveFormatTest(string name, int age)
    {
        this.name = name;
        this.age = age;
    }

}
