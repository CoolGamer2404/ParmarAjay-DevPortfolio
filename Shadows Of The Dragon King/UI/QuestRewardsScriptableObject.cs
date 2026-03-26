using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Quest1Rewards", menuName = "MDG/ScriptableObjects/QuestRewardsScriptableObject")]
public class QuestRewardsScriptableObject : ScriptableObject
{
    public List<QuestReward> QuestRewards;
    [Serializable]
    public class QuestReward{
        public int questPhase;
        public int coins;
        public RewardXpType rewardXpType;

        [Serializable]
        public enum RewardXpType{
            strengthXP,
            attackXP,
            agilityXP,
            moraleXP,
            disciplineXP,
            speedXP,
            defenceXp
        }
        public int RewardAmount;
    }
}
