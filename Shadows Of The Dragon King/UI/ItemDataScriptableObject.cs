using System;
using System.Collections;
using System.Collections.Generic;
using Kryz.CharacterStats;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "ItemData", menuName = "MDG/ScriptableObjects/ItemDataScriptableObject")]
public class ItemDataScriptableObject : ScriptableObject
{
    public String itemName;
    public Sprite icon;
    public ItemType itemType;
    public EquipmentType equipmentType;
    public bool isStackable;
    public int quantity;
    public bool isEquipped;
    public int price;
    public bool isSoldOut;

    public enum ItemType{
        Equipment,
        Consumable,
    }

    public enum EquipmentType{
        Head,
        Body,
        Pant,
        Boot,
        Neckless,
        Glove,
        Ring,
        Belt,
    }


    [Serializable]
    public class Stats
    {
        public StatName statName;
        public StatModType statType;
        public float statAmount;

        public enum StatName{
            health,
            defence,
            damage,
            critDamage,
            critChance,
            attackSpeed,
            strength,
            xpGain,
        }
    }

    public List<Stats> ItemStatBuff;
}
