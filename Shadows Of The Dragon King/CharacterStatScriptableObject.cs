using UnityEngine;
using Kryz.CharacterStats;

[CreateAssetMenu(fileName = "Character1Stats", menuName = "MDG/ScriptableObjects/CharacterStatsScriptableObject")]
public class CharacterStatScriptableObject : ScriptableObject
{
    public CharacterStat Health;//thia is health
    public CharacterStat Defence;//decrese damage by this amount
    public CharacterStat Speed;//speed of walking 
    public CharacterStat SprintSpeed;// sprint speed will be multiplied by 1.5 of base speed
    public CharacterStat CrouchSpeed;// sprint speed will be divided by .5 of base speed
    public CharacterStat AttackSpeed;//speed of attacks
    public CharacterStat Damage;//damage
    public CharacterStat CritChance;//chance to do crit damage
    public CharacterStat CritDamage;//DMG == damage+crit damage
    public CharacterStat Power;//breaking power of blocks
}
