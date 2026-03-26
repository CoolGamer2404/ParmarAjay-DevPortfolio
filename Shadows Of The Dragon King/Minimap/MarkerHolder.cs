using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkerHolder : MonoBehaviour
{
    public GameObject playerObject;
    public RectTransform markerParentRectTransform;
    public Camera minimapCamera;

    public GameObject questMarker,sideQuestMarker,villageMarker,shopMarker,slayerMarker,rangeQuestMarker,settlementMarker,targetMarker,dragonMarker;

    private List<(ObjectivePosition objectivePosition, RectTransform markerRectTransform)> currentObjectives;

    // Start is called before the first frame update
    void Awake()
    {
        currentObjectives = new List<(ObjectivePosition objectivePosition, RectTransform markerRectTransform)>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach ((ObjectivePosition objectivePosition, RectTransform markerRectTransform) marker in currentObjectives) {
            Vector3 offset = Vector3.ClampMagnitude(marker.objectivePosition.transform.position - playerObject.transform.position, minimapCamera.orthographicSize);
            offset = offset / minimapCamera.orthographicSize * (markerParentRectTransform.rect.width / 2f);
            marker.markerRectTransform.anchoredPosition = new Vector2(-offset.x, -offset.z);
        }
    }

RectTransform rectTransform;
    public void AddObjectiveMarker(ObjectivePosition sender,MarkerType markerType) {
        switch (markerType)
        {
            case MarkerType.QuestMarker:
                rectTransform = Instantiate(questMarker, markerParentRectTransform).GetComponent<RectTransform>();
                currentObjectives.Add((sender, rectTransform));
            break;
            case MarkerType.SideQuestMarker:
                rectTransform = Instantiate(sideQuestMarker, markerParentRectTransform).GetComponent<RectTransform>();
                currentObjectives.Add((sender, rectTransform));
            break;
            case MarkerType.RangedQuestMarker:
                rectTransform = Instantiate(rangeQuestMarker, markerParentRectTransform).GetComponent<RectTransform>();
                currentObjectives.Add((sender, rectTransform));
            break;
            case MarkerType.SettlementMarker:
                rectTransform = Instantiate(settlementMarker, markerParentRectTransform).GetComponent<RectTransform>();
                currentObjectives.Add((sender, rectTransform));
            break;
            case MarkerType.ShopMarker:
                rectTransform = Instantiate(shopMarker, markerParentRectTransform).GetComponent<RectTransform>();
                currentObjectives.Add((sender, rectTransform));
            break;
            case MarkerType.SlayerMarker:
                rectTransform = Instantiate(slayerMarker, markerParentRectTransform).GetComponent<RectTransform>();
                currentObjectives.Add((sender, rectTransform));
            break;
            case MarkerType.VillageMarker:
                rectTransform = Instantiate(villageMarker, markerParentRectTransform).GetComponent<RectTransform>();
                currentObjectives.Add((sender, rectTransform));
            break;
            case MarkerType.TargetMarker:
                rectTransform = Instantiate(targetMarker, markerParentRectTransform).GetComponent<RectTransform>();
                currentObjectives.Add((sender, rectTransform));
            break;
            case MarkerType.DragonMarker:
                rectTransform = Instantiate(dragonMarker, markerParentRectTransform).GetComponent<RectTransform>();
                currentObjectives.Add((sender, rectTransform));
            break;
        }
    }

    public void RemoveObjectiveMarker(ObjectivePosition sender) {
        if (!currentObjectives.Exists(objective => objective.objectivePosition == sender))
            return;
        (ObjectivePosition pos, RectTransform rectTrans) foundObj = currentObjectives.Find(objective => objective.objectivePosition == sender);
        Destroy(foundObj.rectTrans.gameObject);
        currentObjectives.Remove(foundObj);
    }
}


public enum MarkerType{
        QuestMarker,
        RangedQuestMarker,
        SettlementMarker,
        ShopMarker,
        SlayerMarker,
        SideQuestMarker,
        VillageMarker,
        TargetMarker,
        DragonMarker
    }
