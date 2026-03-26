using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExtraMainMenuScript : MonoBehaviour
{
    public void StartGame(){
        SceneManager.LoadScene("MainMenu");
    }

    public void ClearData(){
        PlayerPrefs.DeleteAll();
    }

    public void ClearAll(){
        DeleteDirectory(Application.persistentDataPath);
    }


    void DeleteDirectory(string path){
        if(Directory.Exists(path)){
            foreach (string file in Directory.GetFiles(path)){
                File.Delete(file);
            }
            foreach(string dir in Directory.GetDirectories(path)){
                DeleteDirectory(dir);
            }
            Directory.Delete(path);
        }
    }
}
