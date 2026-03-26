using System;
using System.IO;
using UnityEngine;

// THIS CALSS HANDLES ENCRYPT AND DECRYPT OF PROVIDED SCRIPTABLE OBJECT //
public class DronesStatDataHandler : MonoBehaviour
{
    [SerializeField]
    private bool useEncryption;

    public DroneStatData LoadData(string FILE_KEY, string DECRYPT_KEY)
    {
        string path = Path.Combine(Application.persistentDataPath, FILE_KEY);
        DroneStatData data = new DroneStatData();

        if (File.Exists(path))
        {
            try
            {
                string dataToLoad = "";
                using (FileStream stream = new FileStream(path, FileMode.Open))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        dataToLoad = reader.ReadToEnd();
                        if (useEncryption)
                            dataToLoad = EncryptDecrypt(dataToLoad, DECRYPT_KEY);
                    }

                    data = JsonUtility.FromJson<DroneStatData>(dataToLoad);
                }
            }
            catch (Exception e)
            {
                Debug.Log("");
            }
        }
        return data;
    }

    public void SaveData(DroneStatData data)
    {
        string path = Path.Combine(Application.persistentDataPath, data.DRONE_KEY);

        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(path));

            string dataToStore = JsonUtility.ToJson(data, true);

            if (useEncryption)
                dataToStore = EncryptDecrypt(dataToStore, data.DRONE_ENCRYPT_KEY);

            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write(dataToStore);
                    Debug.Log("Data Stored AT:" + path.ToString());
                }
            }
        }
        catch (Exception e)
        {
            Debug.LogError("Error occured when trying to save data at path : " + path + "\n" + e);
        }
    }

    private string EncryptDecrypt(string data, string key)
    {
        string modifiedData = "";
        for (int i = 0; i < data.Length; i++)
        {
            modifiedData += (char)(data[i] ^ key[i % key.Length]);
        }
        return modifiedData;
    }
}
