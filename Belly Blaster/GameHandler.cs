using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class GameHandler : MonoBehaviour
{
    // Game variables
    public int weight = 0;
    public Sprite[] bellySprites;
    public Image bellyImage;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI weightText;
    public TextMeshProUGUI winPanelWeightText;
    public TextMeshProUGUI losePanelWeightText;
    public TextMeshProUGUI winPanelTimeText;
    public GameObject winScreen;
    public GameObject loseScreen;
    public AudioClip eatSound;
    public AudioSource audioSource;
    public ItemSpawner itemSpawner;

    // Timer variables
    private float timer = 120f; // 2 minutes
    private float startTime;

    private void Start()
    {
        // Initialize game
        // StartGame();
    }

    // Start game
    public void StartGame()
    {
        // Reset weight
        weight = 50;

        // Reset belly sprite
        UpdateBellySprite();

        // Reset weight text
        UpdateWeightText();

        // Reset timer
        timer = 120f;
        startTime = Time.time;

        // Reset item spawner
        itemSpawner.DestroyAllObjects();
        itemSpawner.enabled = true;

        // Reset win and lose screens
        winScreen.SetActive(false);
        loseScreen.SetActive(false);

        // Reset time scale
        Time.timeScale = 1f;

        // Start timer coroutine
        StartCoroutine(UpdateTimerCoroutine());
    }

    // Add weight to player's belly
    public void AddWeight(int amount, AudioClip soundToPlay)
    {
        // Increase weight
        weight += amount;

        // Update belly sprite
        UpdateBellySprite();

        // Update weight text
        UpdateWeightText();

        // Check win condition
        if (weight >= 250)
        {
            WinGame();
        }
        // Check lose condition
        else if (weight <= 0)
        {
            LoseGame();
        }

        // Play eat sound
        audioSource.PlayOneShot(soundToPlay);
    }

    // Timer coroutine
    private IEnumerator UpdateTimerCoroutine()
    {
        float elapsedTime = 0f;
        while (elapsedTime < timer)
        {
            // Wait for next frame
            yield return null;

            // Increase elapsed time
            elapsedTime += Time.deltaTime;

            // Calculate minutes and seconds
            int minutes = (int)(timer - elapsedTime) / 60;
            int seconds = (int)(timer - elapsedTime) % 60;

            // Update timer text
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }

        // Check lose condition
        LoseGame();
    }
    // Update belly sprite
    private void UpdateBellySprite()
    {
        // Calculate belly index
        int bellyIndex = Mathf.Clamp((weight - 50) / 50, 0, bellySprites.Length - 1);

        // Update belly sprite
        bellyImage.sprite = bellySprites[bellyIndex];
    }

    // Update weight text
    private void UpdateWeightText()
    {
        // Update weight text
        weightText.text = $"Weight: {weight}KG";
    }

    // Win game
    private void WinGame()
    {
        // Calculate used time
        float usedTime = Time.time - startTime;

        // Calculate minutes and seconds
        int minutes = (int)usedTime / 60;
        int seconds = (int)usedTime % 60;

        // Update win panel weight text
        winPanelWeightText.text = $"Weight: {weight}KG";

        // Update win panel time text
        winPanelTimeText.text = $"Time: {minutes} Min {seconds} Seconds";

        // Show win screen
        winScreen.SetActive(true);

        // Disable item spawner
        itemSpawner.enabled = false;

        // Stop time
        Time.timeScale = 0f;
        itemSpawner.DestroyAllObjects();
        itemSpawner.enabled = false;
    }

    // Lose game
    private void LoseGame()
    {
        // Update lose panel weight text
        losePanelWeightText.text = $"Weight: {weight}KG";

        // Show lose screen
        loseScreen.SetActive(true);

        // Disable item spawner
        itemSpawner.enabled = false;

        // Stop time
        Time.timeScale = 0f;
        itemSpawner.DestroyAllObjects();
        itemSpawner.enabled = false;
    }
}