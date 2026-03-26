using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Item")]
public class Item : ScriptableObject
{
    public string itemName;
    public Sprite itemSprite;
    public int fatGain;
    public AudioClip eatSound; // New field for audio clip
}