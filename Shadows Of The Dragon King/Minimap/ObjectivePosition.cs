using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectivePosition : MonoBehaviour
{
    [SerializeField]private bool isAddMarkerOnStart=true;
    [SerializeField]private MarkerType markerType;
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<MeshRenderer>().enabled=false;
        if(isAddMarkerOnStart==true){
            FindObjectOfType<MarkerHolder>().AddObjectiveMarker(this,markerType);
        }
    }

    public void AddMarker(){
        FindObjectOfType<MarkerHolder>().AddObjectiveMarker(this,markerType);
    }
    public void RemoveMarker(){
        FindObjectOfType<MarkerHolder>().RemoveObjectiveMarker(this);
    }


}
