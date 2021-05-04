using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

// ������ �õ��� Ŭ����
public class SaveImageTest : MonoBehaviour
{
    string folderpath;
    string filepath;
    public Image imageSource;

    void Start()
    {
        folderpath = Application.persistentDataPath + @"\saveimage";
        filepath = @"\i.png";
    }

    public void SaveImage()
    {
        if(!Directory.Exists(folderpath))
        {
            Debug.Log("tets");
            Directory.CreateDirectory(folderpath);
        }

        SaveImageFormatTest test = new SaveImageFormatTest();
        test.images = imageSource.sprite.texture;
        var bytes = test.images.EncodeToPNG();
        File.WriteAllBytes(folderpath + filepath, bytes);
    }

}
