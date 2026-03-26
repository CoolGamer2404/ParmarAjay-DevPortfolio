using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool IsGravityFlipped { get; private set; } = false;

    void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    public void SetGravityFlipped(bool flipped)
    {
        IsGravityFlipped = flipped;
    }
}
