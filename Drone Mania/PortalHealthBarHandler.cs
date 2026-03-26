using UnityEngine;
using UnityEngine.UI;

public class PortalHealthBarHandler : MonoBehaviour
{
    [SerializeField] private Image _healthBarImage;
    [SerializeField] private float _reduceSpeed = 2;

    [SerializeField] private GameObject healthBarCanvas;

    private PortalHealthBarHandler portalHealthBarHandler;

    private Camera _mainCamera;
    private float _target = 1;

    private float disableTime = 15f;

    //private float health = 1000;

    void OnEnable()
    {
        disableTime = 15f;
        healthBarCanvas.SetActive(true);
    }
    private void Start()
    {
        _mainCamera = Camera.main;
        portalHealthBarHandler = transform.GetComponent<PortalHealthBarHandler>();
    }

    public void UpdateHealthBar(float maxHealth, float currentHealth)
    {
        _target = currentHealth / maxHealth;
    }
    private void Update()
    {
        //Remove this funtion after debugiing
        /*if (Input.GetKeyDown(KeyCode.V))
        {
            if (health >= 100)
            {
                health -= 100;
                UpdateHealthBar(1000, health);
            }
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            if (health <= 900)
            {
                health += 100;
                UpdateHealthBar(1000, health);
            }
        }*/

        transform.rotation = Quaternion.LookRotation(transform.position - _mainCamera.transform.position);
        _healthBarImage.fillAmount = Mathf.MoveTowards(_healthBarImage.fillAmount, _target, _reduceSpeed * Time.deltaTime);

        if (disableTime >= 0.1f)
        {
            disableTime -= Time.deltaTime;
        }
        if (disableTime <= .1f)
        {
            portalHealthBarHandler.enabled = false;
            healthBarCanvas.SetActive(false);
        }

    }
}
