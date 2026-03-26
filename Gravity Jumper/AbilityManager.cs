using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public enum AbilityType
{
    None,
    TimeSlow,
    Invisibility,
    ThirdEye
}

public class AbilityManager : MonoBehaviour
{
    public static AbilityManager instance;

    [Header("References")]
    public MagneBoyController player;
    public Image abilityIcon;
    public GameObject abilityBackground;

    [Header("Icons")]
    public Sprite iconTimeSlow;
    public Sprite iconInvisibility;
    public Sprite iconThirdEye;

    [Header("Ability Timings")]
    public float timeSlowDuration = 5f;
    public float timeSlowCooldown = 10f;

    public float invisibilityDuration = 3f;
    public float invisibilityCooldown = 10f;

    public float thirdEyeDuration = 6f;
    public float thirdEyeCooldown = 10f;

    [Header("Ability Settings")]
    public KeyCode useKey = KeyCode.E;

    private AbilityType currentAbility = AbilityType.None;
    private float currentCooldownTime;
    private float currentUseTime;
    private bool isAbilityActive = false;
    private bool isOnCooldown = false;

    private float cooldownTimer = 0f;
    private float useTimer = 0f;

    private Coroutine currentAbilityRoutine;

    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(gameObject);
        else
            instance = this;
    }

    private void Start()
    {
        abilityIcon.fillAmount = 0f;
        abilityBackground.SetActive(false);
    }

    private void Update()
    {
        HandleInput();
        UpdateUI();
        UpdateTimers();
    }

    void HandleInput()
    {
        if (Input.GetKeyDown(useKey) && !isOnCooldown && currentAbility != AbilityType.None)
        {
            ActivateAbility();
        }
    }

    public void SetAbility(AbilityType type)
    {
        ResetAbility(); // 👈 Reset previous ability effects

        currentAbility = type;
        abilityBackground.SetActive(true);

        switch (currentAbility)
        {
            case AbilityType.TimeSlow:
                abilityIcon.sprite = iconTimeSlow;
                currentCooldownTime = timeSlowCooldown;
                currentUseTime = timeSlowDuration;
                break;

            case AbilityType.Invisibility:
                abilityIcon.sprite = iconInvisibility;
                currentCooldownTime = invisibilityCooldown;
                currentUseTime = invisibilityDuration;
                break;

            case AbilityType.ThirdEye:
                abilityIcon.sprite = iconThirdEye;
                currentCooldownTime = thirdEyeCooldown;
                currentUseTime = thirdEyeDuration;
                break;

            default:
                abilityBackground.SetActive(false);
                abilityIcon.sprite = null;
                currentCooldownTime = 0f;
                currentUseTime = 0f;
                break;
        }

        abilityIcon.fillAmount = 1f;
        isOnCooldown = false;
        isAbilityActive = false;
    }

    void ActivateAbility()
    {
        if (currentAbility == AbilityType.None || isOnCooldown) return;

        if (currentAbilityRoutine != null)
            StopCoroutine(currentAbilityRoutine);

        currentAbilityRoutine = StartCoroutine(HandleAbility());
    }

    IEnumerator HandleAbility()
    {
        isAbilityActive = true;

        switch (currentAbility)
        {
            case AbilityType.TimeSlow:
                Time.timeScale = 0.4f;
                AudioManager.instance?.SmoothSetMusicPitch(0.8f, 0.3f); // 🎵 Slow music
                break;

            case AbilityType.Invisibility:
                player.SetExternalInvincibility(true);
                break;

            case AbilityType.ThirdEye:
                Debug.Log("Third Eye enabled");
                break;
        }

        useTimer = currentUseTime;
        cooldownTimer = currentCooldownTime;
        isOnCooldown = true;

        while (useTimer > 0f)
        {
            useTimer -= Time.unscaledDeltaTime;
            yield return null;
        }

        ResetAbilityEffects(); // End effects
        isAbilityActive = false;
    }

    void ResetAbilityEffects()
    {
        if (currentAbility == AbilityType.TimeSlow)
        {
            Time.timeScale = 1f;
            AudioManager.instance?.SmoothSetMusicPitch(1f, 0.3f); // 🎵 Restore music
        }

        if (currentAbility == AbilityType.Invisibility)
        {
            player.SetExternalInvincibility(false);
        }

        Debug.Log("All active ability effects reset");
    }

    public void ResetAbility()
    {
        if (currentAbilityRoutine != null)
        {
            StopCoroutine(currentAbilityRoutine);
            currentAbilityRoutine = null;
        }

        ResetAbilityEffects();
        isOnCooldown = false;
        isAbilityActive = false;
        cooldownTimer = 0f;
        useTimer = 0f;
        abilityIcon.fillAmount = 1f;
    }

    void UpdateTimers()
    {
        if (isOnCooldown && !isAbilityActive)
        {
            if (cooldownTimer > 0f)
            {
                cooldownTimer -= Time.unscaledDeltaTime;
            }
            else
            {
                isOnCooldown = false;
                cooldownTimer = 0f;
            }
        }
    }

    void UpdateUI()
    {
        if (currentAbility == AbilityType.None)
        {
            abilityBackground.SetActive(false);
            return;
        }

        if (isAbilityActive)
        {
            abilityIcon.color = new Color(1f, 1f, 1f, 0.4f);
            abilityIcon.fillAmount = 1f;
        }
        else
        {
            abilityIcon.color = Color.white;
            if (isOnCooldown)
                abilityIcon.fillAmount = 1f - (cooldownTimer / currentCooldownTime);
            else
                abilityIcon.fillAmount = 1f;
        }
    }
}
