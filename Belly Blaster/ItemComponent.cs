using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemComponent : MonoBehaviour, IPointerClickHandler
{
    public Item item;
    public Image itemImage;
    public GameHandler gameHandler;
    public float minFallSpeed = 1f;
    public float maxFallSpeed = 3f;
    private float fallSpeed;

    private void Start()
    {
        // Initialize the item image
        itemImage.sprite = item.itemSprite;

        // Choose a random fall speed
        fallSpeed = Random.Range(minFallSpeed, maxFallSpeed);
    }

    private void Update()
    {
        // Make the item fall
        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        // Call the AddFat method on the GameHandler script
        gameHandler.AddWeight(item.fatGain, item.eatSound);

        // Destroy the item game object
        Destroy(gameObject);
    }
}