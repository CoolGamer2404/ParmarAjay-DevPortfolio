using UnityEngine;

[CreateAssetMenu(fileName = "ResourcesAvailableData", menuName = "MDG/ScriptableObjects/ResourcesAvailableData")]
public class DownloadedResourcesScriptableObject : ScriptableObject
{
    public SkinsScriptableGameObject[] drone1Skins;
    public SkinsScriptableGameObject[] drone2Skins;
    public SkinsScriptableGameObject[] drone3Skins;
    public SkinsScriptableGameObject[] drone4Skins;
    public SkinsScriptableGameObject[] drone5Skins;
    public int[] dronesSkinsDownloadProgress;

}
