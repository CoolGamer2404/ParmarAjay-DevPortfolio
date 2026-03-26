using UnityEngine;
using UnityEngine.UI;

public class ItemSpawner : MonoBehaviour
{
    public GameObject itemPrefab;
    public Item[] items;
    public float spawnInterval = 1f;
    public Transform itemParent;
    public GameHandler gameHandler;

    private Item selectedItem;
    private float nextSpawnTime;

    private void Start()
    {
        nextSpawnTime = Time.time + spawnInterval;
        SelectRandomItem();
    }

    private void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnItem();
            nextSpawnTime += spawnInterval;
        }
    }

    private void SpawnItem()
    {
        // Spawn the item within the boundary rect
        GameObject spawnedItem = Instantiate(itemPrefab, Vector3.zero, Quaternion.identity);
        spawnedItem.GetComponent<RectTransform>().localScale = Vector3.one;

        // Set the parent of the spawned item
        spawnedItem.transform.SetParent(itemParent);

        // Assign the selected item's properties to the spawned item
        ItemComponent itemComponent = spawnedItem.GetComponent<ItemComponent>();
        itemComponent.item = selectedItem;
        itemComponent.itemImage.sprite = selectedItem.itemSprite; 
        itemComponent.gameHandler = gameHandler;

        // Position the item within the boundaries of the spawn location
        RectTransform itemRect = spawnedItem.GetComponent<RectTransform>();
        RectTransform parentRect = itemParent.GetComponent<RectTransform>();
        Vector2 randomPosition = GetRandomPositionWithinBoundary(parentRect.rect.size, itemRect.rect.size);
        itemRect.anchoredPosition = randomPosition;

        SelectRandomItem();
    }

    private Vector2 GetRandomPositionWithinBoundary(Vector2 parentSize, Vector2 itemSize)
    {
        float x = Random.Range(-parentSize.x / 2 + itemSize.x / 2, parentSize.x / 2 - itemSize.x / 2);
        float y = Random.Range(-parentSize.y / 2 + itemSize.y / 2, parentSize.y / 2 - itemSize.y / 2);
        return new Vector2(x, y);
    }

    private void SelectRandomItem()
    {
        selectedItem = items[Random.Range(0, items.Length)];
    }
    public void DestroyAllObjects()
    {
        foreach (Transform child in itemParent)
        {
            Destroy(child.gameObject);
        }
    }

}