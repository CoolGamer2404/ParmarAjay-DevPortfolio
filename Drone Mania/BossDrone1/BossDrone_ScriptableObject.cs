using UnityEngine;

[CreateAssetMenu(fileName = "BossDrone1", menuName = "MDG/ScriptableObjects/BossDroneStatsScriptableObject")]
public class BossDrone_ScriptableObject : ScriptableObject
{
    public int baseHealth;
    public int currentHealth;
    public int phase;
    public int[] currentDamagePerPhase;
    public int[] baseDamagePerPhase;
    public string[] attackName;
    public float[] attackChance;
}
