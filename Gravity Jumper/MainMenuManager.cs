using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    // Loads the game scene by index
    public void StartGame(int sceneIndex)
    {
        PlayButtonClick();
        SceneManager.LoadScene(sceneIndex);
    }

    // Quits the game (works only in build)
    public void QuitGame()
    {
        PlayButtonClick();
        Debug.Log("Quitting the game...");
        Application.Quit();
    }

    // Optional: play button click sound if AudioManager is present
    public void PlayButtonClick()
    {
        if (AudioManager.instance != null)
        {
            AudioManager.instance.PlayButtonClick();
        }
    }
}
