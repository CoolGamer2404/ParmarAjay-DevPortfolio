using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [Header("Audio Sources")]
    public AudioSource musicSource;
    public AudioSource sfxSource1;
    public AudioSource sfxSource2;

    private bool toggleSFXSource = false;

    [Header("Music")]
    public AudioClip backgroundMusic;

    [Header("SFX Clips")]
    public AudioClip shootClip;
    public AudioClip bulletHitClip;
    public AudioClip jumpClip;
    public AudioClip walkClip;
    public AudioClip hurtClip;
    public AudioClip gravityChangeClip;
    public AudioClip enemyDieClip;
    public AudioClip playerDieClip;
    public AudioClip buttonClickClip;

    private Coroutine pitchCoroutine;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    void Start()
    {
        if (musicSource != null && backgroundMusic != null)
        {
            musicSource.clip = backgroundMusic;
            musicSource.loop = true;
            musicSource.Play();
        }
    }

    // === SFX Functions ===

    public void PlaySFX(AudioClip clip)
    {
        if (clip == null) return;

        if (toggleSFXSource && sfxSource1 != null)
            sfxSource1.PlayOneShot(clip);
        else if (sfxSource2 != null)
            sfxSource2.PlayOneShot(clip);

        toggleSFXSource = !toggleSFXSource;
    }

    public void PlayShoot() => PlaySFX(shootClip);
    public void PlayBulletHit() => PlaySFX(bulletHitClip);
    public void PlayJump() => PlaySFX(jumpClip);
    public void PlayWalk() => PlaySFX(walkClip);
    public void PlayHurt() => PlaySFX(hurtClip);
    public void PlayGravityChange() => PlaySFX(gravityChangeClip);
    public void PlayEnemyDie() => PlaySFX(enemyDieClip);
    public void PlayPlayerDie() => PlaySFX(playerDieClip);
    public void PlayButtonClick() => PlaySFX(buttonClickClip);
    public void PlayOneShotCustom(AudioClip clip) => PlaySFX(clip);

    // === Music Pitch Control ===

    public void SmoothSetMusicPitch(float targetPitch, float duration)
    {
        if (musicSource == null) return;

        if (pitchCoroutine != null)
            StopCoroutine(pitchCoroutine);

        pitchCoroutine = StartCoroutine(LerpMusicPitch(targetPitch, duration));
    }

    private IEnumerator LerpMusicPitch(float targetPitch, float duration)
    {
        float startPitch = musicSource.pitch;
        float timeElapsed = 0f;

        while (timeElapsed < duration)
        {
            float t = timeElapsed / duration;
            musicSource.pitch = Mathf.Lerp(startPitch, targetPitch, t);
            timeElapsed += Time.unscaledDeltaTime;
            yield return null;
        }

        musicSource.pitch = targetPitch;
    }
}
