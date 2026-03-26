using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManagement : MonoBehaviour
{
    public int SceneNumber;

    public void SetActiveScene()
    {
        SceneManager.LoadScene(SceneNumber);
    }
}
